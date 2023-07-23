using OpenCvSharp;

namespace BSV_wpf
{
    internal class ImageProcess
    {
        internal static string RecognizeCircle(string fileName)
        {
            Mat srcImg = new Mat(fileName);
            Mat FilImg = new Mat();

            //高斯滤波
            Cv2.GaussianBlur(srcImg, FilImg, new Size(7, 7), 0, 0);

            Mat BinImg = new Mat();
            //固定阈值二值化图像分割图像
            Cv2.Threshold(FilImg, BinImg, 100, 255, ThresholdTypes.Binary);

            Mat edgeImg = new Mat();
            Cv2.Canny(BinImg, edgeImg, 0, 255);
            Cv2.FindContours(edgeImg, out Point[][] contours, out HierarchyIndex[] _, RetrievalModes.List, ContourApproximationModes.ApproxNone, new Point(0, 0));
            edgeImg.Release();

            double area, length, cir, width, height, asp;
            double circularity = 0.6;
            double aspectRatio = 0.6;
            RotatedRect rect;
            int cnt = 0;
            int ln = contours.Length;
            for (int i = 0; i < ln; i++)
            {
                if (contours[i].Length > 10)
                {
                    area = Cv2.ContourArea(contours[i]); //第i个轮廓的面积
                    length = Cv2.ArcLength(contours[i], true); //第i个轮廓的周长
                    cir = (12.56 * area) / (length * length); //第i个轮廓的圆形度
                    if (cir > circularity)
                    {
                        rect = Cv2.FitEllipse(contours[i]);
                        width = rect.Size.Width; //外接矩形的宽度
                        height = rect.Size.Height; //外接矩形的高度
                        asp = height / width; //纵横比
                        if (asp > aspectRatio && asp < (1.0 / aspectRatio))
                        {
                            srcImg.DrawMarker(new Point(rect.Center.X, rect.Center.Y), new Scalar(255, 0, 0));
                            cnt++;
                        }
                    }
                }
            }
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            string outputPath = @$"{currentDir}\1.bmp";
            bool isSaved = srcImg.SaveImage(outputPath);
            //if (isSaved)
            //    Cv2.ImShow("Circle Detect", srcImg);
            return outputPath;
        }
    }
}
