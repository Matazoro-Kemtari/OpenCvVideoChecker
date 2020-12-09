using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace FeatureTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var _videoCapture = new VideoCapture(1);

            var referenceTime = DateTime.Now;
            var cnt = 0;
            while (true)
            {
                /*
                 * 通常の撮像は 1600 * 1200 Fps 5
                 * 処理速度の都合
                 * テンプレート画像の撮像は 2592 * 1944 Fps 2(FA 2592 * 1944 Fps 6)
                 */
                var frameWidth = 2592;
                var frameHeight = 1944;
                var fps = 6;
                if (_videoCapture.Fps != fps)
                    _videoCapture.Fps = fps;
                if (_videoCapture.FrameWidth != frameWidth)
                    _videoCapture.FrameWidth = frameWidth;
                if (_videoCapture.FrameHeight != frameHeight)
                    _videoCapture.FrameHeight = frameHeight;

                cnt++;
                Console.WriteLine("設定書き込み {0}回目 {1}秒", cnt, (DateTime.Now - referenceTime).TotalSeconds);

                if (_videoCapture.FrameWidth == frameWidth && _videoCapture.FrameHeight == frameHeight && Math.Abs(_videoCapture.Fps - fps) < 1)
                    break;

                if ((DateTime.Now - referenceTime).TotalSeconds > 30)
                    throw new TimeoutException("videoCaptureのフレームサイズの設定がタイムアウトしました");
            }
            int posMsec = (int)(1000 * 1 / _videoCapture.Fps);
            _videoCapture.Set(VideoCaptureProperties.PosMsec, posMsec);

            // 特徴点マッチャー
            DescriptorMatcher matcher = DescriptorMatcher.Create("BruteForce");

            // 特徴量検出アルゴリズム
            using var _temp = new Mat("escalator1st_20201119115525242.bmp");
            // 特徴量計算
            (var _temp_keypoint, var _temp_featureImage) = FeatureCommand(_temp);

            while (true)
            {
                using var frame = new Mat();
                _videoCapture.Read(frame);

                // 特徴量計算
                (var _frame_keypoint, var _frame_descriptor) = FeatureCommand(frame);

                // 特徴量マッチング 上位2位
                DMatch[][] matches = matcher.KnnMatch(_temp_featureImage, _frame_descriptor, 2);

                // 閾値で対応点を絞り込む
                List<DMatch> goodMatches;
                List<Point2f> goodTemplateKeyPoints, goodSourceKeyPoints;
                (goodMatches, goodTemplateKeyPoints, goodSourceKeyPoints) =
                FilterMatchGoodScore(_temp_keypoint, _frame_keypoint, matches);

                //マッチングした特徴量同士を線でつなぐ
                Mat output3 = new Mat();
                Cv2.DrawMatches(_temp, _temp_keypoint, frame, _frame_keypoint, goodMatches, output3);

                Cv2.ImShow("feature", output3);
                Cv2.WaitKey();

            }
        }

        static (KeyPoint[], Mat) FeatureCommand(Mat source)
        {
            // 特徴量検出アルゴリズム
            var feature = KAZE.Create();

            var magnification = 2;
            using var _ex = source.Resize(new Size(source.Width * magnification, source.Height * magnification));
            // ガンマ補正
            var gamma = 1.8;
            byte[] _gammaLut = new byte[256];
            for (int i = 0; i < _gammaLut.Length; i++)
            {
                _gammaLut[i] = (byte)(255d * Math.Pow(i / 255d, 1d / gamma));
            }
            using Mat _temp_gammaImage = new Mat();
            Cv2.LUT(_ex, _gammaLut, _temp_gammaImage);
            // 特徴量計算
            KeyPoint[] keyPoints;            // 特徴点
            Mat descriptor = new Mat();      // 特徴量
            feature.DetectAndCompute(_temp_gammaImage, null, out keyPoints, descriptor);
            //var _featureImage = new Mat();
            //Cv2.DrawKeypoints(_temp_gammaImage, _keypoint, _featureImage);

            return (keyPoints, descriptor);
        }

        /// <summary>
        /// 閾値で対応点を絞り込む
        /// </summary>
        /// <param name="templateKeyPoints"></param>
        /// <param name="sourceKeyPoints"></param>
        /// <param name="matches"></param>
        /// <param name="thresholdValue">対応点のしきい値</param>
        /// <returns></returns>
        static (List<DMatch> goodMatches, List<Point2f> goodTemplateKeyPoints, List<Point2f> goodSourceKeyPoints) FilterMatchGoodScore
            (KeyPoint[] templateKeyPoints,
             KeyPoint[] sourceKeyPoints,
             DMatch[][] matches)
        {
            var goodMatches = new List<DMatch>();
            var goodTemplateKeyPoints = new List<Point2f>();
            var goodSourceKeyPoints = new List<Point2f>();
            foreach (var match in matches)
            {
                var canKeeped = false;
                //if (match.Length >= 2)
                //{
                //    double distance1st = match[0].Distance;
                //    double distance2nd = match[1].Distance;

                //    // 良い点を残す（最も類似する点と次に類似する点の類似度から）
                //    if (distance1st <= distance2nd * thresholdValue)
                //    {
                //        canKeeped = true;
                //    }
                //}
                //else
                canKeeped = true;

                if (canKeeped)
                {
                    goodMatches.Add(match[0]);
                    goodTemplateKeyPoints.Add(templateKeyPoints[match[0].QueryIdx].Pt);
                    goodSourceKeyPoints.Add(sourceKeyPoints[match[0].TrainIdx].Pt);
                }
            }
            return (goodMatches, goodTemplateKeyPoints, goodSourceKeyPoints);

        }
    }
}
