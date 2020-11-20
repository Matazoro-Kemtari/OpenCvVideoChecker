﻿using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace FeatureLive
{
    class Program
    {
        static VideoCapture camera = new VideoCapture(0);

        static void Main(string[] args)
        {
            // カメラの初期設定
            SetCamera(camera);

            // テンプレート画像
            var _path = Path.Combine(
                @"..\..\..\..",
                @"OpenCvVideoTester\bin\Debug\netcoreapp3.1",
                "parking1fast_20201109102637777.bmp");
            using var tempImg = new Mat(_path);

            Mat tempDst = new Mat();
            using var tempWin = new Window("Template");
            tempWin.CreateTrackbar("Gamma", 180, 200, (pos) =>
            {
                double gammaPower = pos / 100d;
                // ガンマ補正
                tempDst = AdjustGamma(tempImg, gammaPower);
                tempWin.ShowImage(tempDst);
            });


            var dst = new Mat();

            double gammaPower = 1.8;
            double distanceThreshold = 0.8;
            using var win = new Window("feature");
            win.CreateTrackbar("Gamma", 180, 200, (pos) =>
            {
                gammaPower = pos / 100d;
                dst = MatcheWindow(tempDst, gammaPower, distanceThreshold);
                win.ShowImage(dst);
            });
            win.CreateTrackbar("Distance", 80, 100, (pos) =>
            {
                distanceThreshold = pos / 100d;
                dst = MatcheWindow(tempDst, gammaPower, distanceThreshold);
                win.ShowImage(dst);
                // win.Image = dst; // ShowImageのかわりにこう書いてもOK
            });

            Cv2.WaitKey();
        }

        static Mat MatcheWindow(Mat template,
                                double gammaPower,
                                double distanceThreshold)
        {
            using var source = new Mat();
            // カメラ画像取り込み
            camera.Read(source);

            // ガンマ補正
            using var gammaDst = AdjustGamma(source, gammaPower);

            // テンプレート画像の特徴量計算
            (var tempKey, var tempDesc) = FeatureCommand(template);
            // カメラ画像の特徴量計算
            (var srcKey, var srcDesc) = FeatureCommand(gammaDst);

            // 特徴点マッチャー
            DescriptorMatcher matcher = DescriptorMatcher.Create("BruteForce");
            // 特徴量マッチング 上位2位
            DMatch[][] matches = matcher.KnnMatch(tempDesc, srcDesc, 2);

            distanceThreshold = distanceThreshold / 100d;
            // 閾値で対応点を絞り込む
            List<DMatch> goodMatches;
            List<Point2f> goodTemplateKeyPoints, goodSourceKeyPoints;
            (goodMatches, goodTemplateKeyPoints, goodSourceKeyPoints) =
            FilterMatchGoodScore(tempKey, srcKey, matches, distanceThreshold);

            //マッチングした特徴量同士を線でつなぐ
            var output = new Mat();
            Cv2.DrawMatches(template, tempKey, gammaDst, srcKey, goodMatches, output);

            return output;
        }

        static void SetCamera(VideoCapture videoCapture)
        {
            var referenceTime = DateTime.Now;
            var cnt = 0;
            while (true)
            {
                /*
                 * 通常の撮像は 1600 * 1200 Fps 5
                 * 処理速度の都合
                 * テンプレート画像の撮像は 2592 * 1944 Fps 2(FA 2592 * 1944 Fps 6)
                 */
                var frameWidth = 800;
                var frameHeight = 600;
                var fps = 30;
                if (videoCapture.Fps != fps)
                    videoCapture.Fps = fps;
                if (videoCapture.FrameWidth != frameWidth)
                    videoCapture.FrameWidth = frameWidth;
                if (videoCapture.FrameHeight != frameHeight)
                    videoCapture.FrameHeight = frameHeight;

                cnt++;
                Console.WriteLine("設定書き込み {0}回目 {1}秒", cnt, (DateTime.Now - referenceTime).TotalSeconds);

                if (videoCapture.FrameWidth == frameWidth && videoCapture.FrameHeight == frameHeight && Math.Abs(videoCapture.Fps - fps) < 1)
                    break;

                if ((DateTime.Now - referenceTime).TotalSeconds > 30)
                    throw new TimeoutException("videoCaptureのフレームサイズの設定がタイムアウトしました");
            }
        }

        static (KeyPoint[], Mat) FeatureCommand(Mat source)
        {
            // 特徴量検出アルゴリズム
            var feature = AKAZE.Create();

            var magnification = 1;
            using var _ex = source.Resize(new Size(source.Width * magnification, source.Height * magnification));

            // 特徴量計算
            KeyPoint[] keyPoints;            // 特徴点
            Mat descriptor = new Mat();      // 特徴量
            feature.DetectAndCompute(_ex, null, out keyPoints, descriptor);
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
             DMatch[][] matches,
             double thresholdValue)
        {
            var goodMatches = new List<DMatch>();
            var goodTemplateKeyPoints = new List<Point2f>();
            var goodSourceKeyPoints = new List<Point2f>();
            foreach (var match in matches)
            {
                var canKeeped = false;
                if (match.Length >= 2)
                {
                    double distance1st = match[0].Distance;
                    double distance2nd = match[1].Distance;

                    // 良い点を残す（最も類似する点と次に類似する点の類似度から）
                    if (distance1st <= distance2nd * thresholdValue)
                    {
                        canKeeped = true;
                    }
                }
                else
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

        /// <summary>
        /// ガンマ補正
        /// </summary>
        /// <param name="source"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        static Mat AdjustGamma(Mat source, double power)
        {
            byte[] gammaLut = new byte[256];
            for (int i = 0; i < gammaLut.Length; i++)
            {
                gammaLut[i] = (byte)(255d * Math.Pow(i / 255d, 1d / power));
            }
            Mat gammaImage = new Mat();
            Cv2.LUT(source, gammaLut, gammaImage);
            return gammaImage;
        }
    }
}
