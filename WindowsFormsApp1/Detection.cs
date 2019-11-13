using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using System.IO;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace WindowsFormsApp1
{
    class Detection
    {
        public Image<Gray, byte> OriginalImg;
        public bool counter;
        public Detection(Image<Gray, byte> grayImg)
        {
            this.OriginalImg = grayImg;
        }
        public bool get()
        {
            return counter;
        }

        public Image<Gray, byte> detectDrawCIrcle()
        {
            Image<Bgr, byte> Img_Result_Bgr = new Image<Bgr, byte>(OriginalImg.Width, OriginalImg.Height);
            Gray cannyThreshold = new Gray(35); //kad je ovdje 200, a ispod 100 ne radi na nekim slikama, ovako radi
            Gray circleAccumulatorThreshold = new Gray(30);
           
            try
            {
                CircleF[] HoughCircles = OriginalImg.Clone().HoughCircles(cannyThreshold, circleAccumulatorThreshold, 1, 5, 10, 50)[0];


                #region draw circles
                foreach (CircleF circle in HoughCircles)
                    Img_Result_Bgr.Draw(circle, new Bgr(Color.Red), 2);
              
                #endregion

                //nalazi srediste, sprema u tocku i nalazi radius kruga ako je detektiran
                float x = HoughCircles[0].Center.X;
                float y = HoughCircles[0].Center.Y;
                Point pointc = new Point((int)x, (int)y);
                float radic = HoughCircles[0].Radius;
                Image<Gray, byte> mask = new Image<Gray, byte>(OriginalImg.Width, OriginalImg.Height);
                CvInvoke.Circle(mask, pointc, (int)radic, new MCvScalar(255, 255, 255), -1, Emgu.CV.CvEnum.LineType.AntiAlias, 0);
                Image<Gray, byte> dest = new Image<Gray, byte>(OriginalImg.Width, OriginalImg.Height);
                dest = OriginalImg.And(OriginalImg, mask);
                dest.ROI = new Rectangle(pointc.X - (int)radic, pointc.Y - (int)radic, (int)(radic - 2) * 2, (int)(radic - 2) * 2);
                counter=true;
                return dest;

            }
            catch
            {
                counter = false;
                return OriginalImg;
            }
        }

    }
}
