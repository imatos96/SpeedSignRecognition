using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using System.IO;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;


namespace WindowsFormsApp1
{
    class Filters
    {
        
        public Image<Bgr, byte> OriginalImg;
        
        public Filters(Image<Bgr, byte> originalImg)
        {
            this.OriginalImg = originalImg;
          
        }

        public Image<Bgr,byte> preprocessingFunc()
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(OriginalImg.Width, OriginalImg.Height);
            Image<Hls, byte> hlIM = new Image<Hls, byte>(OriginalImg.Bitmap);
            Image<Gray, byte> Ima2 = hlIM[1];
            Ima2._EqualizeHist();
            hlIM[1] = Ima2;
            CvInvoke.CvtColor(hlIM, result, Emgu.CV.CvEnum.ColorConversion.Hls2Bgr);
            return result;
        }

        public Image<Gray, byte> convertToGray(Image<Bgr,byte> result)
        {
            Image<Gray, byte>  grayImg = result.Convert<Gray, byte>();
            return grayImg;
        }

      
       


    }
}
