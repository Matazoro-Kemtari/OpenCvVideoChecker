using OpenCvSharp;
using System;
using System.IO;

namespace OpenCvVideoTester
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

            #region FourCCの実験
            //Console.WriteLine("{0}:{1}", "1978", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("1978")));
            //Console.WriteLine("{0}:{1}", "2VUY", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("2VUY")));
            //Console.WriteLine("{0}:{1}", "3IV0", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("3IV0")));
            //Console.WriteLine("{0}:{1}", "3IV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("3IV1")));
            //Console.WriteLine("{0}:{1}", "3IV2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("3IV2")));
            //Console.WriteLine("{0}:{1}", "3IVD", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("3IVD")));
            //Console.WriteLine("{0}:{1}", "3IVX", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("3IVX")));
            //Console.WriteLine("{0}:{1}", "8BPS", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("8BPS")));
            //Console.WriteLine("{0}:{1}", "AAS4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AAS4")));
            //Console.WriteLine("{0}:{1}", "AASC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AASC")));
            //Console.WriteLine("{0}:{1}", "ABYR", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ABYR")));
            //Console.WriteLine("{0}:{1}", "ACTL", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ACTL")));
            //Console.WriteLine("{0}:{1}", "ADV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ADV1")));
            //Console.WriteLine("{0}:{1}", "ADVJ", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ADVJ")));
            //Console.WriteLine("{0}:{1}", "AEIK", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AEIK")));
            //Console.WriteLine("{0}:{1}", "AEMI", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AEMI")));
            //Console.WriteLine("{0}:{1}", "AFLC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AFLC")));
            //Console.WriteLine("{0}:{1}", "AFLI", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AFLI")));
            //Console.WriteLine("{0}:{1}", "AHDV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AHDV")));
            //Console.WriteLine("{0}:{1}", "AJPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AJPG")));
            //Console.WriteLine("{0}:{1}", "AMPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AMPG")));
            //Console.WriteLine("{0}:{1}", "ANIM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ANIM")));
            //Console.WriteLine("{0}:{1}", "AP41", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AP41")));
            //Console.WriteLine("{0}:{1}", "AP42", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AP42")));
            //Console.WriteLine("{0}:{1}", "ASLC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ASLC")));
            //Console.WriteLine("{0}:{1}", "ASV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ASV1")));
            //Console.WriteLine("{0}:{1}", "ASV2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ASV2")));
            //Console.WriteLine("{0}:{1}", "ASVX", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ASVX")));
            //Console.WriteLine("{0}:{1}", "ATM4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ATM4")));
            //Console.WriteLine("{0}:{1}", "AUR2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AUR2")));
            //Console.WriteLine("{0}:{1}", "AURA", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AURA")));
            //Console.WriteLine("{0}:{1}", "AVC1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AVC1")));
            //Console.WriteLine("{0}:{1}", "AVRN", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("AVRN")));
            //Console.WriteLine("{0}:{1}", "BA81", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("BA81")));
            //Console.WriteLine("{0}:{1}", "BINK", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("BINK")));
            //Console.WriteLine("{0}:{1}", "BLZ0", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("BLZ0")));
            //Console.WriteLine("{0}:{1}", "BT20", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("BT20")));
            //Console.WriteLine("{0}:{1}", "BTCV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("BTCV")));
            //Console.WriteLine("{0}:{1}", "BW10", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("BW10")));
            //Console.WriteLine("{0}:{1}", "BYR1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("BYR1")));
            //Console.WriteLine("{0}:{1}", "BYR2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("BYR2")));
            //Console.WriteLine("{0}:{1}", "CC12", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CC12")));
            //Console.WriteLine("{0}:{1}", "CDVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CDVC")));
            //Console.WriteLine("{0}:{1}", "CFCC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CFCC")));
            //Console.WriteLine("{0}:{1}", "CGDI", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CGDI")));
            //Console.WriteLine("{0}:{1}", "CHAM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CHAM")));
            //Console.WriteLine("{0}:{1}", "CJPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CJPG")));
            //Console.WriteLine("{0}:{1}", "CMYK", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CMYK")));
            //Console.WriteLine("{0}:{1}", "CPLA", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CPLA")));
            //Console.WriteLine("{0}:{1}", "CRAM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CRAM")));
            //Console.WriteLine("{0}:{1}", "CSCD", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CSCD")));
            //Console.WriteLine("{0}:{1}", "CTRX", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CTRX")));
            //Console.WriteLine("{0}:{1}", "CVID", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CVID")));
            //Console.WriteLine("{0}:{1}", "CWLT", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CWLT")));
            //Console.WriteLine("{0}:{1}", "CXY1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CXY1")));
            //Console.WriteLine("{0}:{1}", "CXY2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CXY2")));
            //Console.WriteLine("{0}:{1}", "CYUV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CYUV")));
            //Console.WriteLine("{0}:{1}", "CYUY", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("CYUY")));
            //Console.WriteLine("{0}:{1}", "D261", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("D261")));
            //Console.WriteLine("{0}:{1}", "D263", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("D263")));
            //Console.WriteLine("{0}:{1}", "DAVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DAVC")));
            //Console.WriteLine("{0}:{1}", "DCL1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DCL1")));
            //Console.WriteLine("{0}:{1}", "DCL2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DCL2")));
            //Console.WriteLine("{0}:{1}", "DCL3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DCL3")));
            //Console.WriteLine("{0}:{1}", "DCL4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DCL4")));
            //Console.WriteLine("{0}:{1}", "DCL5", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DCL5")));
            //Console.WriteLine("{0}:{1}", "DIV3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DIV3")));
            //Console.WriteLine("{0}:{1}", "DIV4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DIV4")));
            //Console.WriteLine("{0}:{1}", "DIV5", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DIV5")));
            //Console.WriteLine("{0}:{1}", "DIVX", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DIVX")));
            //Console.WriteLine("{0}:{1}", "DM4V", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DM4V")));
            //Console.WriteLine("{0}:{1}", "DMB1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DMB1")));
            //Console.WriteLine("{0}:{1}", "DMB2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DMB2")));
            //Console.WriteLine("{0}:{1}", "DMK2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DMK2")));
            //Console.WriteLine("{0}:{1}", "DSVD", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DSVD")));
            //Console.WriteLine("{0}:{1}", "DUCK", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DUCK")));
            //Console.WriteLine("{0}:{1}", "DV25", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DV25")));
            //Console.WriteLine("{0}:{1}", "DV50", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DV50")));
            //Console.WriteLine("{0}:{1}", "DVAN", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVAN")));
            //Console.WriteLine("{0}:{1}", "DVCS", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVCS")));
            //Console.WriteLine("{0}:{1}", "DVE2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVE2")));
            //Console.WriteLine("{0}:{1}", "DVH1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVH1")));
            //Console.WriteLine("{0}:{1}", "DVHD", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVHD")));
            //Console.WriteLine("{0}:{1}", "DVSD", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVSD")));
            //Console.WriteLine("{0}:{1}", "DVSL", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVSL")));
            //Console.WriteLine("{0}:{1}", "DVX1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVX1")));
            //Console.WriteLine("{0}:{1}", "DVX2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVX2")));
            //Console.WriteLine("{0}:{1}", "DVX3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DVX3")));
            //Console.WriteLine("{0}:{1}", "DX50", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DX50")));
            //Console.WriteLine("{0}:{1}", "DXGM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DXGM")));
            //Console.WriteLine("{0}:{1}", "DXTC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DXTC")));
            //Console.WriteLine("{0}:{1}", "DXTN", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("DXTN")));
            //Console.WriteLine("{0}:{1}", "EKQ0", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("EKQ0")));
            //Console.WriteLine("{0}:{1}", "ELK0", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ELK0")));
            //Console.WriteLine("{0}:{1}", "EM2V", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("EM2V")));
            //Console.WriteLine("{0}:{1}", "ES07", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ES07")));
            //Console.WriteLine("{0}:{1}", "ESCP", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ESCP")));
            //Console.WriteLine("{0}:{1}", "ETV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ETV1")));
            //Console.WriteLine("{0}:{1}", "ETV2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ETV2")));
            //Console.WriteLine("{0}:{1}", "ETVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ETVC")));
            //Console.WriteLine("{0}:{1}", "FFV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("FFV1")));
            //Console.WriteLine("{0}:{1}", "FLJP", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("FLJP")));
            //Console.WriteLine("{0}:{1}", "FMP4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("FMP4")));
            //Console.WriteLine("{0}:{1}", "FMVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("FMVC")));
            //Console.WriteLine("{0}:{1}", "FPS1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("FPS1")));
            //Console.WriteLine("{0}:{1}", "FRWA", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("FRWA")));
            //Console.WriteLine("{0}:{1}", "FRWD", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("FRWD")));
            //Console.WriteLine("{0}:{1}", "FVF1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("FVF1")));
            //Console.WriteLine("{0}:{1}", "GEOX", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("GEOX")));
            //Console.WriteLine("{0}:{1}", "GJPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("GJPG")));
            //Console.WriteLine("{0}:{1}", "GLZW", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("GLZW")));
            //Console.WriteLine("{0}:{1}", "GPEG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("GPEG")));
            //Console.WriteLine("{0}:{1}", "GWLT", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("GWLT")));
            //Console.WriteLine("{0}:{1}", "H260", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H260")));
            //Console.WriteLine("{0}:{1}", "H261", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H261")));
            //Console.WriteLine("{0}:{1}", "H262", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H262")));
            //Console.WriteLine("{0}:{1}", "H263", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H263")));
            //Console.WriteLine("{0}:{1}", "H264", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H264")));
            //Console.WriteLine("{0}:{1}", "H265", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H265")));
            //Console.WriteLine("{0}:{1}", "H266", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H266")));
            //Console.WriteLine("{0}:{1}", "H267", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H267")));
            //Console.WriteLine("{0}:{1}", "H268", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H268")));
            //Console.WriteLine("{0}:{1}", "H269", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("H269")));
            //Console.WriteLine("{0}:{1}", "HDYC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("HDYC")));
            //Console.WriteLine("{0}:{1}", "HEVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("HEVC")));
            //Console.WriteLine("{0}:{1}", "HFYU", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("HFYU")));
            //Console.WriteLine("{0}:{1}", "HMCR", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("HMCR")));
            //Console.WriteLine("{0}:{1}", "HMRR", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("HMRR")));
            //Console.WriteLine("{0}:{1}", "I263", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("I263")));
            //Console.WriteLine("{0}:{1}", "ICLB", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ICLB")));
            //Console.WriteLine("{0}:{1}", "IGOR", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IGOR")));
            //Console.WriteLine("{0}:{1}", "IJLV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IJLV")));
            //Console.WriteLine("{0}:{1}", "IJPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IJPG")));
            //Console.WriteLine("{0}:{1}", "ILVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ILVC")));
            //Console.WriteLine("{0}:{1}", "ILVR", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ILVR")));
            //Console.WriteLine("{0}:{1}", "IPDV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IPDV")));
            //Console.WriteLine("{0}:{1}", "IPMA", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IPMA")));
            //Console.WriteLine("{0}:{1}", "IR21", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IR21")));
            //Console.WriteLine("{0}:{1}", "IRAW", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IRAW")));
            //Console.WriteLine("{0}:{1}", "ISME", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ISME")));
            //Console.WriteLine("{0}:{1}", "IV30", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV30")));
            //Console.WriteLine("{0}:{1}", "IV31", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV31")));
            //Console.WriteLine("{0}:{1}", "IV32", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV32")));
            //Console.WriteLine("{0}:{1}", "IV33", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV33")));
            //Console.WriteLine("{0}:{1}", "IV34", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV34")));
            //Console.WriteLine("{0}:{1}", "IV35", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV35")));
            //Console.WriteLine("{0}:{1}", "IV36", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV36")));
            //Console.WriteLine("{0}:{1}", "IV37", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV37")));
            //Console.WriteLine("{0}:{1}", "IV38", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV38")));
            //Console.WriteLine("{0}:{1}", "IV39", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV39")));
            //Console.WriteLine("{0}:{1}", "IV32", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV32")));
            //Console.WriteLine("{0}:{1}", "IV40", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV40")));
            //Console.WriteLine("{0}:{1}", "IV41", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV41")));
            //Console.WriteLine("{0}:{1}", "IV42", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV42")));
            //Console.WriteLine("{0}:{1}", "IV43", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV43")));
            //Console.WriteLine("{0}:{1}", "IV44", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV44")));
            //Console.WriteLine("{0}:{1}", "IV45", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV45")));
            //Console.WriteLine("{0}:{1}", "IV46", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV46")));
            //Console.WriteLine("{0}:{1}", "IV47", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV47")));
            //Console.WriteLine("{0}:{1}", "IV48", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV48")));
            //Console.WriteLine("{0}:{1}", "IV49", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV49")));
            //Console.WriteLine("{0}:{1}", "IV50", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("IV50")));
            //Console.WriteLine("{0}:{1}", "JBYR", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("JBYR")));
            //Console.WriteLine("{0}:{1}", "JPEG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("JPEG")));
            //Console.WriteLine("{0}:{1}", "JPGL", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("JPGL")));
            //Console.WriteLine("{0}:{1}", "KB2A", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("KB2A")));
            //Console.WriteLine("{0}:{1}", "KB2D", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("KB2D")));
            //Console.WriteLine("{0}:{1}", "KB2F", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("KB2F")));
            //Console.WriteLine("{0}:{1}", "KB2G", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("KB2G")));
            //Console.WriteLine("{0}:{1}", "KMVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("KMVC")));
            //Console.WriteLine("{0}:{1}", "L261", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("L261")));
            //Console.WriteLine("{0}:{1}", "L263", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("L263")));
            //Console.WriteLine("{0}:{1}", "LBYR", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LBYR")));
            //Console.WriteLine("{0}:{1}", "LCMW", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LCMW")));
            //Console.WriteLine("{0}:{1}", "LCW2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LCW2")));
            //Console.WriteLine("{0}:{1}", "LEAD", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LEAD")));
            //Console.WriteLine("{0}:{1}", "LGRY", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LGRY")));
            //Console.WriteLine("{0}:{1}", "LJ11", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LJ11")));
            //Console.WriteLine("{0}:{1}", "LJ22", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LJ22")));
            //Console.WriteLine("{0}:{1}", "LJ2K", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LJ2K")));
            //Console.WriteLine("{0}:{1}", "LJ44", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LJ44")));
            //Console.WriteLine("{0}:{1}", "LJPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LJPG")));
            //Console.WriteLine("{0}:{1}", "LMP2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LMP2")));
            //Console.WriteLine("{0}:{1}", "LMP4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LMP4")));
            //Console.WriteLine("{0}:{1}", "LSVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LSVC")));
            //Console.WriteLine("{0}:{1}", "LSVM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LSVM")));
            //Console.WriteLine("{0}:{1}", "LSVX", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LSVX")));
            //Console.WriteLine("{0}:{1}", "LZO1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("LZO1")));
            //Console.WriteLine("{0}:{1}", "M261", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("M261")));
            //Console.WriteLine("{0}:{1}", "M263", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("M263")));
            //Console.WriteLine("{0}:{1}", "M4CC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("M4CC")));
            //Console.WriteLine("{0}:{1}", "M4S2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("M4S2")));
            //Console.WriteLine("{0}:{1}", "MC12", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MC12")));
            //Console.WriteLine("{0}:{1}", "MCAM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MCAM")));
            //Console.WriteLine("{0}:{1}", "MJ2C", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MJ2C")));
            //Console.WriteLine("{0}:{1}", "MJPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MJPG")));
            //Console.WriteLine("{0}:{1}", "MMES", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MMES")));
            //Console.WriteLine("{0}:{1}", "MP2A", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MP2A")));
            //Console.WriteLine("{0}:{1}", "MP2T", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MP2T")));
            //Console.WriteLine("{0}:{1}", "MP2V", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MP2V")));
            //Console.WriteLine("{0}:{1}", "MP42", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MP42")));
            //Console.WriteLine("{0}:{1}", "MP43", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MP43")));
            //Console.WriteLine("{0}:{1}", "MP4A", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MP4A")));
            //Console.WriteLine("{0}:{1}", "MP4S", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MP4S")));
            //Console.WriteLine("{0}:{1}", "MP4T", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MP4T")));
            //Console.WriteLine("{0}:{1}", "MP4V", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MP4V")));
            //Console.WriteLine("{0}:{1}", "MPEG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MPEG")));
            //Console.WriteLine("{0}:{1}", "MPG4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MPG4")));
            //Console.WriteLine("{0}:{1}", "MPGI", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MPGI")));
            //Console.WriteLine("{0}:{1}", "MR16", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MR16")));
            //Console.WriteLine("{0}:{1}", "MRCA", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MRCA")));
            //Console.WriteLine("{0}:{1}", "MRLE", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MRLE")));
            //Console.WriteLine("{0}:{1}", "MSVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MSVC")));
            //Console.WriteLine("{0}:{1}", "MSZH", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MSZH")));
            //Console.WriteLine("{0}:{1}", "MTX1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MTX1")));
            //Console.WriteLine("{0}:{1}", "MTX2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MTX2")));
            //Console.WriteLine("{0}:{1}", "MTX3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MTX3")));
            //Console.WriteLine("{0}:{1}", "MTX4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MTX4")));
            //Console.WriteLine("{0}:{1}", "MTX5", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MTX5")));
            //Console.WriteLine("{0}:{1}", "MTX6", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MTX6")));
            //Console.WriteLine("{0}:{1}", "MTX7", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MTX7")));
            //Console.WriteLine("{0}:{1}", "MTX8", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MTX8")));
            //Console.WriteLine("{0}:{1}", "MTX9", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MTX9")));
            //Console.WriteLine("{0}:{1}", "MVI1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MVI1")));
            //Console.WriteLine("{0}:{1}", "MVI2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MVI2")));
            //Console.WriteLine("{0}:{1}", "MWV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("MWV1")));
            //Console.WriteLine("{0}:{1}", "NAVI", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NAVI")));
            //Console.WriteLine("{0}:{1}", "NDSC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NDSC")));
            //Console.WriteLine("{0}:{1}", "NDSM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NDSM")));
            //Console.WriteLine("{0}:{1}", "NDSP", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NDSP")));
            //Console.WriteLine("{0}:{1}", "NDSS", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NDSS")));
            //Console.WriteLine("{0}:{1}", "NDXC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NDXC")));
            //Console.WriteLine("{0}:{1}", "NDXH", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NDXH")));
            //Console.WriteLine("{0}:{1}", "NDXP", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NDXP")));
            //Console.WriteLine("{0}:{1}", "NDXS", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NDXS")));
            //Console.WriteLine("{0}:{1}", "NHVU", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NHVU")));
            //Console.WriteLine("{0}:{1}", "NI24", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NI24")));
            //Console.WriteLine("{0}:{1}", "NTN1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NTN1")));
            //Console.WriteLine("{0}:{1}", "NTN2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NTN2")));
            //Console.WriteLine("{0}:{1}", "NVDS", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVDS")));
            //Console.WriteLine("{0}:{1}", "NVHS", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVHS")));
            //Console.WriteLine("{0}:{1}", "NVS0", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVS0")));
            //Console.WriteLine("{0}:{1}", "NVS1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVS1")));
            //Console.WriteLine("{0}:{1}", "NVS2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVS2")));
            //Console.WriteLine("{0}:{1}", "NVS3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVS3")));
            //Console.WriteLine("{0}:{1}", "NVS4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVS4")));
            //Console.WriteLine("{0}:{1}", "NVS5", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVS5")));
            //Console.WriteLine("{0}:{1}", "NVT0", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVT0")));
            //Console.WriteLine("{0}:{1}", "NVT1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVT1")));
            //Console.WriteLine("{0}:{1}", "NVT2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVT2")));
            //Console.WriteLine("{0}:{1}", "NVT3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVT3")));
            //Console.WriteLine("{0}:{1}", "NVT4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVT4")));
            //Console.WriteLine("{0}:{1}", "NVT5", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("NVT5")));
            //Console.WriteLine("{0}:{1}", "PDVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PDVC")));
            //Console.WriteLine("{0}:{1}", "PGVV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PGVV")));
            //Console.WriteLine("{0}:{1}", "PHMO", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PHMO")));
            //Console.WriteLine("{0}:{1}", "PIM1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PIM1")));
            //Console.WriteLine("{0}:{1}", "PIM2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PIM2")));
            //Console.WriteLine("{0}:{1}", "PIMJ", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PIMJ")));
            //Console.WriteLine("{0}:{1}", "PIXL", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PIXL")));
            //Console.WriteLine("{0}:{1}", "PJPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PJPG")));
            //Console.WriteLine("{0}:{1}", "PVEZ", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PVEZ")));
            //Console.WriteLine("{0}:{1}", "PVMM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PVMM")));
            //Console.WriteLine("{0}:{1}", "PVW2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("PVW2")));
            //Console.WriteLine("{0}:{1}", "QPEG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("QPEG")));
            //Console.WriteLine("{0}:{1}", "QPEQ", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("QPEQ")));
            //Console.WriteLine("{0}:{1}", "RGBT", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("RGBT")));
            //Console.WriteLine("{0}:{1}", "RLE4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("RLE4")));
            //Console.WriteLine("{0}:{1}", "RLE8", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("RLE8")));
            //Console.WriteLine("{0}:{1}", "RMP4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("RMP4")));
            //Console.WriteLine("{0}:{1}", "RPZA", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("RPZA")));
            //Console.WriteLine("{0}:{1}", "RT21", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("RT21")));
            //Console.WriteLine("{0}:{1}", "RV20", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("RV20")));
            //Console.WriteLine("{0}:{1}", "RV30", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("RV30")));
            //Console.WriteLine("{0}:{1}", "RV40", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("RV40")));
            //Console.WriteLine("{0}:{1}", "S422", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("S422")));
            //Console.WriteLine("{0}:{1}", "SAN3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SAN3")));
            //Console.WriteLine("{0}:{1}", "SDCC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SDCC")));
            //Console.WriteLine("{0}:{1}", "SEDG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SEDG")));
            //Console.WriteLine("{0}:{1}", "SFMC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SFMC")));
            //Console.WriteLine("{0}:{1}", "SMK2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SMK2")));
            //Console.WriteLine("{0}:{1}", "SMK4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SMK4")));
            //Console.WriteLine("{0}:{1}", "SMKA", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SMKA")));
            //Console.WriteLine("{0}:{1}", "SMP4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SMP4")));
            //Console.WriteLine("{0}:{1}", "SMSC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SMSC")));
            //Console.WriteLine("{0}:{1}", "SMSD", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SMSD")));
            //Console.WriteLine("{0}:{1}", "SMSV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SMSV")));
            //Console.WriteLine("{0}:{1}", "SP40", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SP40")));
            //Console.WriteLine("{0}:{1}", "SP44", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SP44")));
            //Console.WriteLine("{0}:{1}", "SP54", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SP54")));
            //Console.WriteLine("{0}:{1}", "SPIG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SPIG")));
            //Console.WriteLine("{0}:{1}", "SQZ2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SQZ2")));
            //Console.WriteLine("{0}:{1}", "STVA", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("STVA")));
            //Console.WriteLine("{0}:{1}", "STVB", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("STVB")));
            //Console.WriteLine("{0}:{1}", "STVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("STVC")));
            //Console.WriteLine("{0}:{1}", "STVX", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("STVX")));
            //Console.WriteLine("{0}:{1}", "STVY", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("STVY")));
            //Console.WriteLine("{0}:{1}", "SV10", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SV10")));
            //Console.WriteLine("{0}:{1}", "SVQ1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SVQ1")));
            //Console.WriteLine("{0}:{1}", "SVQ3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("SVQ3")));
            //Console.WriteLine("{0}:{1}", "TLMS", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TLMS")));
            //Console.WriteLine("{0}:{1}", "TLST", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TLST")));
            //Console.WriteLine("{0}:{1}", "TM20", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TM20")));
            //Console.WriteLine("{0}:{1}", "TM2X", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TM2X")));
            //Console.WriteLine("{0}:{1}", "TMIC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TMIC")));
            //Console.WriteLine("{0}:{1}", "TMOT", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TMOT")));
            //Console.WriteLine("{0}:{1}", "TR20", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TR20")));
            //Console.WriteLine("{0}:{1}", "TSCC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TSCC")));
            //Console.WriteLine("{0}:{1}", "TV10", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TV10")));
            //Console.WriteLine("{0}:{1}", "TVJP", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TVJP")));
            //Console.WriteLine("{0}:{1}", "TVMJ", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TVMJ")));
            //Console.WriteLine("{0}:{1}", "TY0N", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TY0N")));
            //Console.WriteLine("{0}:{1}", "TY2C", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TY2C")));
            //Console.WriteLine("{0}:{1}", "TY2N", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("TY2N")));
            //Console.WriteLine("{0}:{1}", "UCOD", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("UCOD")));
            //Console.WriteLine("{0}:{1}", "ULTI", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ULTI")));
            //Console.WriteLine("{0}:{1}", "V210", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("V210")));
            //Console.WriteLine("{0}:{1}", "V261", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("V261")));
            //Console.WriteLine("{0}:{1}", "V655", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("V655")));
            //Console.WriteLine("{0}:{1}", "VCR1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VCR1")));
            //Console.WriteLine("{0}:{1}", "VCR2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VCR2")));
            //Console.WriteLine("{0}:{1}", "VCR3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VCR3")));
            //Console.WriteLine("{0}:{1}", "VCR4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VCR4")));
            //Console.WriteLine("{0}:{1}", "VCR5", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VCR5")));
            //Console.WriteLine("{0}:{1}", "VCR6", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VCR6")));
            //Console.WriteLine("{0}:{1}", "VCR7", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VCR7")));
            //Console.WriteLine("{0}:{1}", "VCR8", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VCR8")));
            //Console.WriteLine("{0}:{1}", "VCR9", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VCR9")));
            //Console.WriteLine("{0}:{1}", "VDCT", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VDCT")));
            //Console.WriteLine("{0}:{1}", "VDOM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VDOM")));
            //Console.WriteLine("{0}:{1}", "VDOW", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VDOW")));
            //Console.WriteLine("{0}:{1}", "VDTZ", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VDTZ")));
            //Console.WriteLine("{0}:{1}", "VGPX", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VGPX")));
            //Console.WriteLine("{0}:{1}", "VIDS", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VIDS")));
            //Console.WriteLine("{0}:{1}", "VIFP", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VIFP")));
            //Console.WriteLine("{0}:{1}", "VIVO", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VIVO")));
            //Console.WriteLine("{0}:{1}", "VIXL", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VIXL")));
            //Console.WriteLine("{0}:{1}", "VLV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VLV1")));
            //Console.WriteLine("{0}:{1}", "VP30", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VP30")));
            //Console.WriteLine("{0}:{1}", "VP31", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VP31")));
            //Console.WriteLine("{0}:{1}", "VP40", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VP40")));
            //Console.WriteLine("{0}:{1}", "VP50", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VP50")));
            //Console.WriteLine("{0}:{1}", "VP60", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VP60")));
            //Console.WriteLine("{0}:{1}", "VP61", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VP61")));
            //Console.WriteLine("{0}:{1}", "VP62", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VP62")));
            //Console.WriteLine("{0}:{1}", "VP70", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VP70")));
            //Console.WriteLine("{0}:{1}", "VP80", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VP80")));
            //Console.WriteLine("{0}:{1}", "VQC1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VQC1")));
            //Console.WriteLine("{0}:{1}", "VQC2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VQC2")));
            //Console.WriteLine("{0}:{1}", "VQJC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VQJC")));
            //Console.WriteLine("{0}:{1}", "VSSV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VSSV")));
            //Console.WriteLine("{0}:{1}", "VUUU", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VUUU")));
            //Console.WriteLine("{0}:{1}", "VX1K", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VX1K")));
            //Console.WriteLine("{0}:{1}", "VX2K", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VX2K")));
            //Console.WriteLine("{0}:{1}", "VXSP", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VXSP")));
            //Console.WriteLine("{0}:{1}", "VYU9", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VYU9")));
            //Console.WriteLine("{0}:{1}", "VYUY", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("VYUY")));
            //Console.WriteLine("{0}:{1}", "WBVC", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WBVC")));
            //Console.WriteLine("{0}:{1}", "WHAM", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WHAM")));
            //Console.WriteLine("{0}:{1}", "WINX", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WINX")));
            //Console.WriteLine("{0}:{1}", "WJPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WJPG")));
            //Console.WriteLine("{0}:{1}", "WMV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WMV1")));
            //Console.WriteLine("{0}:{1}", "WMV2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WMV2")));
            //Console.WriteLine("{0}:{1}", "WMV3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WMV3")));
            //Console.WriteLine("{0}:{1}", "WMVA", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WMVA")));
            //Console.WriteLine("{0}:{1}", "WNV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WNV1")));
            //Console.WriteLine("{0}:{1}", "WVC1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("WVC1")));
            //Console.WriteLine("{0}:{1}", "X263", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("X263")));
            //Console.WriteLine("{0}:{1}", "X264", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("X264")));
            //Console.WriteLine("{0}:{1}", "XLV0", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XLV0")));
            //Console.WriteLine("{0}:{1}", "XMPG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XMPG")));
            //Console.WriteLine("{0}:{1}", "XVID", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XVID")));
            //Console.WriteLine("{0}:{1}", "XWV0", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV0")));
            //Console.WriteLine("{0}:{1}", "XWV1", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV1")));
            //Console.WriteLine("{0}:{1}", "XWV2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV2")));
            //Console.WriteLine("{0}:{1}", "XWV3", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV3")));
            //Console.WriteLine("{0}:{1}", "XWV4", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV4")));
            //Console.WriteLine("{0}:{1}", "XWV5", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV5")));
            //Console.WriteLine("{0}:{1}", "XWV6", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV6")));
            //Console.WriteLine("{0}:{1}", "XWV7", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV7")));
            //Console.WriteLine("{0}:{1}", "XWV8", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV8")));
            //Console.WriteLine("{0}:{1}", "XWV9", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XWV9")));
            //Console.WriteLine("{0}:{1}", "XXAN", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("XXAN")));
            //Console.WriteLine("{0}:{1}", "Y411", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("Y411")));
            //Console.WriteLine("{0}:{1}", "Y41P", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("Y41P")));
            //Console.WriteLine("{0}:{1}", "Y444", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("Y444")));
            //Console.WriteLine("{0}:{1}", "YC12", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YC12")));
            //Console.WriteLine("{0}:{1}", "YUV8", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YUV8")));
            //Console.WriteLine("{0}:{1}", "YUV9", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YUV9")));
            //Console.WriteLine("{0}:{1}", "YUVP", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YUVP")));
            //Console.WriteLine("{0}:{1}", "YUY2", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YUY2")));
            //Console.WriteLine("{0}:{1}", "YUYV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YUYV")));
            //Console.WriteLine("{0}:{1}", "YV12", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YV12")));
            //Console.WriteLine("{0}:{1}", "YV16", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YV16")));
            //Console.WriteLine("{0}:{1}", "YV92", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YV92")));
            //Console.WriteLine("{0}:{1}", "ZLIB", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ZLIB")));
            //Console.WriteLine("{0}:{1}", "ZMBV", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ZMBV")));
            //Console.WriteLine("{0}:{1}", "ZPEG", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ZPEG")));
            //Console.WriteLine("{0}:{1}", "ZYGO", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ZYGO")));
            //Console.WriteLine("{0}:{1}", "ZYYY", _videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("ZYYY")));
            #endregion

            //if (!_videoCapture.Set(VideoCaptureProperties.FourCC, VideoWriter.FourCC("YUYV")))
            //    throw new InvalidOperationException("動画フォーマットに対応していません");

            // ビデオキャプチャー設定を表示
            var fourccCode = _videoCapture.Get(VideoCaptureProperties.FourCC);
            var _fourcc = string.Format("({0})", fourccCode);
            if (fourccCode != 22)
                _fourcc = _videoCapture.FourCC + _fourcc;
            var _frameWidth = _videoCapture.Get(VideoCaptureProperties.FrameWidth);
            var _frameHeight = _videoCapture.Get(VideoCaptureProperties.FrameHeight);
            var _fps = _videoCapture.Get(VideoCaptureProperties.Fps);
            Console.WriteLine("ビデオカメラ解像度: {0} x {1} {2}fps FourCC:{3}",
                _frameWidth, _frameHeight, _fps, _fourcc);



            var mat = new Mat();
            _videoCapture.Read(mat);
            Cv2.ImWrite(DateTime.Now.ToString("yyMMddHHmmss") + string.Format("ビデオカメラ解像度{0}x{1}_{2}fps",
                _frameWidth, _frameHeight, _fps) + ".bmp", mat);

            if (_fps == 0)
            {
                _fps = 30;
                Console.WriteLine("ビデオカメラ解像度: {0} x {1} {2}fps FourCC:{3}",
                    _frameWidth, _frameHeight, _fps, _fourcc);
            }

            // 動画保存用
            VideoWriter videoWriter = null;

            // 特徴量検出アルゴリズム
            var feature = KAZE.Create();

            // テンプレート画像トリミング位置
            // エスカレーター
            var escalator1st = new Rect(105, 180, 817, 466);
            var escalator1st_view = new Rect(escalator1st.X / 2, escalator1st.Y / 2, escalator1st.Width / 2, escalator1st.Height / 2);
            var escalator2nd = new Rect(924, 138, 1006, 446);
            var escalator2nd_view = new Rect(escalator2nd.X / 2, escalator2nd.Y / 2, escalator2nd.Width / 2, escalator2nd.Height / 2);
            //var escalator3rd = new Rect(1495, 293, 811, 325);
            //var escalator3rd_view = new Rect(escalator3rd.X / 2, escalator3rd.Y / 2, escalator3rd.Width / 2, escalator3rd.Height / 2);
            // P1
            var parking1fast = new Rect(605, 828, 396, 913);
            var parking1fast_view = new Rect(parking1fast.X / 2, parking1fast.Y / 2, parking1fast.Width / 2, parking1fast.Height / 2);
            //var parking1second = new Rect(118, 897, 301, 604);
            //var parking1second_view = new Rect(parking1second.X / 2, parking1second.Y / 2, parking1second.Width / 2, parking1second.Height / 2);
            // P2
            var parking2fast = new Rect(1185, 828, 396, 913);
            var parking2fast_view = new Rect(parking2fast.X / 2, parking2fast.Y / 2, parking2fast.Width / 2, parking2fast.Height / 2);
            //var parking2second = new Rect(1315, 977, 315, 763);
            //var parking2second_view = new Rect(parking2second.X / 2, parking2second.Y / 2, parking2second.Width / 2, parking2second.Height / 2);
            // P3
            //var parking3fast = new Rect(115, 1119, 625, 281);
            //var parking3fast_view = new Rect(parking3fast.X / 2, parking3fast.Y / 2, parking3fast.Width / 2, parking3fast.Height / 2);
            //var parking3second = new Rect(435, 1370, 190, 430);
            //var parking3second_view = new Rect(parking3second.X / 2, parking3second.Y / 2, parking3second.Width / 2, parking3second.Height / 2);

            while (true)
            {
                using var frame = new Mat();
                _videoCapture.Read(frame);

                // 大きすぎて見えないので表示用に小さくする
                using var frame_view = frame.Resize(new Size(frame.Width / 2, frame.Height / 2));

                // テンプレート画像トリミング位置描画
                // エスカレーター
                frame_view.Rectangle(escalator1st_view, new Scalar(0, 255, 0), 2);
                frame_view.Rectangle(escalator2nd_view, new Scalar(0, 255, 0), 2);
                //frame_view.Rectangle(escalator3rd_view, new Scalar(0, 255, 0), 2);
                frame_view.PutText("Trim to 1", escalator1st_view.Location, HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255));
                frame_view.PutText("Trim to 2", escalator2nd_view.Location, HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255));
                //frame_view.PutText("Trim to 3", escalator3rd_view.Location, HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255));
                // P1
                frame_view.Rectangle(parking1fast_view, new Scalar(0, 255, 0), 2);
                frame_view.PutText("Trim to 3", parking1fast_view.Location, HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255));
                //frame_view.Rectangle(parking1second_view, new Scalar(0, 255, 0), 2);
                //frame_view.PutText("Trim to 5", parking1second_view.Location, HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255));
                // P2
                frame_view.Rectangle(parking2fast_view, new Scalar(0, 255, 0), 2);
                frame_view.PutText("Trim to 4", parking2fast_view.Location, HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255));
                //frame_view.Rectangle(parking2second_view, new Scalar(0, 255, 0), 2);
                //frame_view.PutText("Trim to 7", parking2second_view.Location, HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255));
                // P3
                //frame_view.Rectangle(parking3fast_view, new Scalar(0, 255, 0), 2);
                //frame_view.PutText("Trim to 8", parking3fast_view.Location, HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255));
                //frame_view.Rectangle(parking3second_view, new Scalar(0, 255, 0), 2);
                //frame_view.PutText("Trim to 9", parking3second_view.Location, HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255));

                using var win = new Window("capture", frame_view);

                var key = Cv2.WaitKey(Convert.ToInt32(1 / _fps * 1000));

                if (key == 27)
                    break;
                if (key == 115) // sキー
                    // 画像の保存
                    Cv2.ImWrite(DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".bmp", frame);
                if (key == 109) // mキー
                {
                    if (videoWriter == null)
                        videoWriter = new VideoWriter(
                            DateTime.Now.ToString("yyyyMMddHHmmss") + ".avi",
                            VideoWriter.FourCC("ULRG"),
                            _fps,
                            new Size(_videoCapture.FrameWidth, _videoCapture.FrameHeight));

                    // 動画の保存
                    videoWriter.Write(frame);
                }
                if (key == 102) // fキー
                {
                    var keypoint = feature.Detect(frame);
                    using var featureImage = new Mat();
                    Cv2.DrawKeypoints(frame, keypoint, featureImage);
                    Cv2.ImShow("feature", featureImage);
                }
                if (key == 100) // dキー
                {
                    var directoryPath = @"..\..\..\..\..\..\..\..\200910\template";
                    // ファイル一覧を取得
                    var files = Directory.EnumerateFiles(directoryPath,
                                                             "Dyna*.bmp",
                                                             SearchOption.TopDirectoryOnly);
                    foreach (var file in files)
                    {
                        var debug = Cv2.ImRead(file);
                        var keypoint = feature.Detect(debug);
                        var featureImage = new Mat();
                        Cv2.DrawKeypoints(debug, keypoint, featureImage);
                        Cv2.ImShow(Path.GetFileName(file), featureImage);

                        var expand = 5;
                        var debug_expand = debug.Resize(new Size(debug.Width * expand, debug.Height * expand));
                        var keypoint_expand = feature.Detect(debug_expand);
                        var featureImage_expand = new Mat();
                        Cv2.DrawKeypoints(debug_expand, keypoint_expand, featureImage_expand);
                        Cv2.ImShow(Path.GetFileName(file) + "_expand", featureImage_expand);
                    }
                }
                if (49 <= key && key <= 57)
                {
                    Rect trimRect = new Rect();
                    string prefix = string.Empty;
                    switch (key)
                    {
                        case 50: // 2キー
                            trimRect = escalator2nd;
                            prefix = nameof(escalator2nd) + "_";
                            break;

                        case 51: // 3キー
                            trimRect = parking1fast;
                            prefix = nameof(parking1fast) + "_";
                            break;

                        case 52: // 4キー
                            trimRect = parking2fast;
                            prefix = nameof(parking2fast) + "_";
                            break;

                        //case 53: // 5キー
                        //    trimRect = parking1second;
                        //    prefix = nameof(parking1second) + "_";
                        //    break;

                        //case 54: // 6キー
                        //    trimRect = parking2fast;
                        //    prefix = nameof(parking2fast) + "_";
                        //    break;

                        //case 55: // 7キー
                        //    trimRect = parking2second;
                        //    prefix = nameof(parking2second) + "_";
                        //    break;

                        //case 56: // 8キー
                        //    trimRect = parking3fast;
                        //    prefix = nameof(parking3fast) + "_";
                        //    break;

                        //case 57: // 9キー
                        //    trimRect = parking3second;
                        //    prefix = nameof(parking3second) + "_";
                        //    break;

                        default: // 1キー
                            trimRect = escalator1st;
                            prefix = nameof(escalator1st) + "_";
                            break;
                    }
                    using var trim = frame.SubMat(trimRect);

                    // 特徴量検出
                    using Mat grayImage = trim.CvtColor(ColorConversionCodes.BGR2GRAY);
                    // 画像サイズを大きくする
                    var magnification = 2;
                    Mat expandImage = grayImage.Resize(new Size(grayImage.Width * magnification, grayImage.Height * magnification));
                    // ガンマ補正
                    var gamma = 1.8;
                    byte[] gammaLut = new byte[256];
                    for (int i = 0; i < gammaLut.Length; i++)
                    {
                        gammaLut[i] = (byte)(255d * Math.Pow(i / 255d, 1d / gamma));
                    }
                    Mat gammaImage = new Mat();
                    Cv2.LUT(expandImage, gammaLut, gammaImage);
                                                                       
                    // 特徴量計算
                    var keypoint = feature.Detect(gammaImage);
                    using var featureImage = new Mat();
                    Cv2.DrawKeypoints(gammaImage, keypoint, featureImage);
                    featureImage.PutText("keypoint:" + keypoint.Length.ToString(), new Point(5, 50), HersheyFonts.HersheySimplex, 1, Scalar.Red);

                    //var featureImage2 = featureImage.Resize(new Size(trim.Width,
                                                             //trim.Height));
                    Cv2.ImShow("trim", featureImage);

                    // テンプレート画像保存
                    var bmpName = prefix + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    Cv2.ImWrite(bmpName + ".bmp", trim);
                    Cv2.ImWrite(bmpName + "_特徴量.bmp", featureImage);
                }
            }
            Cv2.DestroyAllWindows();
            videoWriter?.Dispose();
        }
    }
}
