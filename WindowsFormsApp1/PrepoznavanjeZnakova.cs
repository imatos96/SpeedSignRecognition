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
using System.Globalization;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace WindowsFormsApp1
{
    public partial class PrepoznavanjeZnakova : Form
    {
       
        Image<Bgr, byte> objektSvuda;
        VideoCapture WebcamPic;
        bool CapInProg;

       
        //ovo u LOADTRAIN uvrstiti
        string TrainDataPath2 = @"D:\gtsrb train\20";
        string TrainDataPath3 = @"D:\gtsrb train\30";
        string TrainDataPath5 = @"D:\gtsrb train\50";
        string TrainDataPath6 = @"D:\gtsrb train\60";
        string TrainDataPath7 = @"D:\gtsrb train\70";
        string TrainDataPath8 = @"D:\gtsrb train\80";
        string TrainDataPath9 = @"D:\gtsrb train\90";
        string TrainDataPath10 = @"D:\gtsrb train\100";
        string TrainDataPath12 = @"D:\gtsrb train\120";

        string TrainDataPath3M = @"D:\Trainset mastif speed\30";
        string TrainDataPath5M = @"D:\Trainset mastif speed\50";
        string TrainDataPath7M = @"D:\Trainset mastif speed\70";
        string TrainDataPath4M = @"D:\Trainset mastif speed\40";
        string TrainDataPath6M = @"D:\Trainset mastif speed\60";

        string TestDataPath3 = @"D:\Testset mastif speed\30";
        string TestDataPath5 = @"D:\Testset mastif speed\50";
        string TestDataPath7 = @"D:\Testset mastif speed\70";
        string TestDataPath4 = @"D:\Testset mastif speed\40";
        string TestDataPath6 = @"D:\Testset mastif speed\60";

        string TestDataPath = @"D:\gtsrbtestspeed";

        List<float[]> TrainDataList = new List<float[]>();
        List<int> TrainLabelList = new List<int>();

        List<float[]> TestDataList = new List<float[]>();
        List<int> TestLabelList = new List<int>();

        Image<Gray, byte> dest;
        Matrix<float> TrainsData;
        Matrix<float> TestsData;
        Matrix<int> TrainsLabel;
        Matrix<int> TestsLabel;

        Matrix<float> TrainsDataM;
        Matrix<float> TestsDataM;
        Matrix<int> TrainsLabelM;
        Matrix<int> TestsLabelM;
        int countDetectedTest = 0;
        SVM svm;
        SVM svmMastif;
        int countHOG = 0;

        float[] prvi;

        Filters filterImgManually, filterImgAuto;
        Detection detectImg, detectFilterAll;

        ScriptEngine pyEngine = null;
        ScriptScope pyScope = null;

        public PrepoznavanjeZnakova()
        {
            InitializeComponent();
            pyEngine = Python.CreateEngine();//ovo dvoje za inicijalizaciju
            pyScope = pyEngine.CreateScope();
        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            if (CompImage.Checked)
            {
                OpenFileDialog Openfile = new OpenFileDialog();
                if (Openfile.ShowDialog() == DialogResult.OK)
                {
                    objektSvuda = new Image<Bgr, byte>(Openfile.FileName);
                    objektSvuda = objektSvuda.Resize(45, 45, Inter.Cubic);
                    pictureBox1.Image = objektSvuda.ToBitmap();

                }
            }

            if (WebCam.Checked)
            {
                if (WebcamPic == null)
                {
                    WebcamPic = new VideoCapture();
                }


                if (WebcamPic != null)
                {

                    if (CapInProg)
                    {
                        LoadImage.Text = "Učitaj sliku";
                        WebcamPic.ImageGrabbed -= WebcamPic_ImageGrabbed;
                        objektSvuda = new Image<Bgr, byte>(WebcamPic.QuerySmallFrame().Bitmap);
                        objektSvuda = objektSvuda.Resize(45, 45, Inter.Cubic);
                        pictureBox1.Image = objektSvuda.ToBitmap();
                    }
                    else
                    {
                        LoadImage.Text = "Snimi sliku";
                        WebcamPic.ImageGrabbed += WebcamPic_ImageGrabbed;
                        WebcamPic.Start();
                        
                    }

                    CapInProg = !CapInProg;
                }

            }
        }
        public void WebcamPic_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                this.WebcamPic.Retrieve(m);
                CvInvoke.Resize(m, m, new Size(60, 60));
                objektSvuda = m.ToImage<Bgr, byte>();
                pictureBox1.Image = objektSvuda.Bitmap;
            }
            catch
            {

            }

        }


        private void ReleaseData()
        {
            if (WebcamPic != null)
                WebcamPic.Dispose();
        }


        private async void Filters_Click(object sender, EventArgs e)
        {
            if (objektSvuda == null) //provjerimo je li objekt tu, odnosno je li slika izabrana/snimljena
            {
                return;
            }
            filterImgManually = new Filters(objektSvuda);
            objektSvuda = filterImgManually.preprocessingFunc();
            pictureBox1.Image = objektSvuda.Bitmap;
            await Task.Delay(500);
            Image<Gray,byte> grayImg = filterImgManually.convertToGray(objektSvuda);
            pictureBox1.Image = grayImg.Bitmap;
            await Task.Delay(500);

            detectImg = new Detection(grayImg);
            dest = detectImg.detectDrawCIrcle();
            pictureBox1.Image = dest.Bitmap;
            await Task.Delay(500);
            
                prvi = GetVector(dest);
                try
                {
                    PrepZnak(prvi);
                }
                catch
                {

                }
            
        }

     
        private float[] filteri(Image<Bgr, byte> FiltrImg)
        {
            FiltrImg = FiltrImg.Resize(45, 45, Inter.Linear);
            bool count = false;
            filterImgAuto = new Filters(FiltrImg);
            FiltrImg = filterImgAuto.preprocessingFunc();
            Image<Gray, byte> GrayImg = filterImgAuto.convertToGray(FiltrImg);

            detectFilterAll = new Detection(GrayImg);
            dest = detectFilterAll.detectDrawCIrcle();

            if (count = detectFilterAll.get()) countDetectedTest++;
            return GetVector(dest);

        }
        
        private void RecTrainTest_Click(object sender, EventArgs e)
        {
            try
            {

                LoadTrainData();
              
                MessageBox.Show("Data loaded.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTrainData()
        {
            string[] files2 = Directory.GetFiles(TrainDataPath2, "*.ppm", SearchOption.AllDirectories);
            string[] files3 = Directory.GetFiles(TrainDataPath3, "*.ppm", SearchOption.AllDirectories);
            string[] files5= Directory.GetFiles(TrainDataPath5, "*.ppm", SearchOption.AllDirectories);
            string[] files6 = Directory.GetFiles(TrainDataPath6, "*.ppm", SearchOption.AllDirectories);
            string[] files7 = Directory.GetFiles(TrainDataPath7, "*.ppm", SearchOption.AllDirectories);
           string[] files8 = Directory.GetFiles(TrainDataPath8, "*.ppm", SearchOption.AllDirectories);
            string[] files9 = Directory.GetFiles(TrainDataPath9, "*.ppm", SearchOption.AllDirectories);
            string[] files10 = Directory.GetFiles(TrainDataPath10, "*.ppm", SearchOption.AllDirectories);
            string[] files12 = Directory.GetFiles(TrainDataPath12, "*.ppm", SearchOption.AllDirectories);
            FolderFilter(files2, 2, TrainDataList, TrainLabelList); //bili 10 i 200 svuda filteri
            FolderFilter(files3, 3,  TrainDataList, TrainLabelList);
            FolderFilter(files5, 5,  TrainDataList, TrainLabelList);
            FolderFilter(files6, 6,  TrainDataList, TrainLabelList);
            FolderFilter(files7, 7,  TrainDataList, TrainLabelList);
            FolderFilter(files8, 8,  TrainDataList, TrainLabelList);
            FolderFilter(files9, 9,  TrainDataList, TrainLabelList);
            FolderFilter(files10, 10,TrainDataList, TrainLabelList);
            FolderFilter(files12, 12,TrainDataList, TrainLabelList);
            MessageBox.Show(countHOG.ToString());
            TrainsData = new Matrix<float>(To2D<float>(TrainDataList.ToArray()));
            TrainsLabel = new Matrix<int>(TrainLabelList.ToArray());
        }

        private void FolderFilter(string[] folder, int num, List<float[]> DataList, List<int> LabelList )
        {
            foreach (var file in folder)
            {
                Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                DataList.Add(filteri(fileImage));
                LabelList.Add(num);
            }
        }

       
        public Image<Gray, Byte> Resize1(Image<Gray, Byte> im)
        {
            return im.Resize(48, 48, Inter.Linear);
           

        }
        public float[] GetVector(Image<Gray, Byte> im)
        {
          
            HOGDescriptor hog = new HOGDescriptor(new Size(48, 48), new Size(16, 16), new Size(8,8), new Size(8,8)); ;    // with defaults values
            Image<Gray, byte> imageOfInterest = Resize1(im);
            imageOfInterest= imageOfInterest.SmoothGaussian(3, 3, 0, 0);
            CvInvoke.MedianBlur(imageOfInterest, imageOfInterest, 5);
            countHOG++;
            return hog.Compute(imageOfInterest); 
        }
        private T[,] To2D<T>(T[][] source)
        {
            
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }

        private void Train_Click(object sender, EventArgs e)
        {
            try
            {
             if (File.Exists("svmGtsrb.txt"))
                {
                    svm = new SVM();
                    FileStorage file = new FileStorage("svmGtsrb.txt", FileStorage.Mode.Read);
                    svm.Read(file.GetNode("opencv_ml_svm"));
                    MessageBox.Show("Svm opened.");
                }
                else
                {
                    svm = new SVM();
                   // TrainData traindata = new TrainData(TrainsData, DataLayoutType.RowSample, TrainsLabel);
                    svm.C = 100;
                    svm.Type = SVM.SvmType.CSvc;
                    svm.Gamma =0.1;
                    //0.02 je 89, 0.05 je 88
                   // svm.Gamma = 0.09; 0.844 u kombinciji sa c=5
                    svm.SetKernel(SVM.SvmKernelType.Rbf);
                   // svm.Degree = 1;
                    svm.TermCriteria = new MCvTermCriteria(1000, 1e-6);
                    svm.Train(TrainsData, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, TrainsLabel);
                   // svm.TrainAuto(traindata,20);
                    svm.Save("svmGtsrb.txt");
                    
                   
                    MessageBox.Show("Svm is trained.");
                }


            }
            //stanjit sve male slike ostavit ili obrnuto
            //normalizacija
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
        private void PrepZnak (float [] prvi)
        {
             List<float[]> trainList = new List<float[]>();
            trainList.Add(prvi);

            TestsData = new Matrix<float>(To2D<float>(trainList.ToArray()));
            //MessageBox.Show(TestsData.Rows.ToString());

            if (TestsData == null)
            {
                return;
            }
           
            if (svm == null && svmMastif==null)
            {
                return;//ako nije treniran ne radi nista
            }
            try
            {
                if (svm != null)
                {
                    Matrix<float> row = TestsData.GetRow(0);
                    float predict = svm.Predict(row, null);

                    label1.Text = "Recognized speed sign:" + predict.ToString() + "0";
                    if (predict == 2)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._20;

                    }
                    if (predict == 3)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._30;

                    }
                    if (predict == 5)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._50;
                    }
                    if (predict == 6)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._60s;
                    }
                    if (predict == 7)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._70;
                    }
                    if (predict == 8)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._80;
                    }
                    if (predict == 9)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._90;
                    }
                    if (predict == 10)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._100;
                    }
                    if (predict == 12)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._120;
                    }
                    // kao da u message/picbox pokaze sliku koju je labelovo if (predict==)
                }
                if (svmMastif != null)
                {
                    Matrix<float> row = TestsData.GetRow(0);
                    float predict = svmMastif.Predict(row, null);

                    label1.Text = "Recognized speed sign:" + predict.ToString() + "0";
                    if (predict == 4)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._40;

                    }
                    if (predict == 3)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._30;

                    }
                    if (predict == 5)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._50;
                    }
                    if (predict == 6)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._60s;
                    }
                    if (predict == 7)
                    {
                        picBoxExtractNum1.Image = Properties.Resources._70;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    
        private async void TestSVM_Click(object sender, EventArgs e)
        {
            
            int i = 0;
            countDetectedTest = 0;
            int ct2 = 0, ct3 = 0, ct5 = 0, ct6 = 0, ct7 = 0, ct8 = 0, ct9 = 0, ct10 = 0, ct12 = 0;
           //svi su skupa, mora otvarat txt file listu i redom svaki broj dodavat slici iz folder
           string[] files = Directory.GetFiles(TestDataPath, "*.ppm", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                TestDataList.Add(filteri(fileImage));
                
            }
            var ReadLabel=System.IO.File.ReadAllLines(@"D:\testLabelReal.txt");
            foreach(string s in ReadLabel)
            {
                TestLabelList.Add(Convert.ToInt32(s)); 
                // stavlja u test
            }

           foreach(int b in TestLabelList)
            {
                if (b == 3) ct3++;
                else if (b == 5) ct5++;
                else if (b == 2) ct2++;
                else if (b == 6) ct6++;
                else if (b == 7) ct7++;
                else if (b == 8) ct8++;
                else if (b == 9) ct9++;
                else if (b == 10) ct10++;
                else if (b == 12) ct12++;
            }
          

            TestsData = new Matrix<float>(To2D<float>(TestDataList.ToArray()));
           
            TestsLabel = new Matrix<int>(TestLabelList.ToArray());
       
            //MessageBox.Show(" 20:" + ct2.ToString() + " 30:" + ct3.ToString() + " 50:" + ct5.ToString() + " 60:" + ct6.ToString() + " 70:" + ct7.ToString() + " 80:" + ct8.ToString() + " 90:" + ct9.ToString() + " 100:" + ct10.ToString() + " 120:" + ct12.ToString());

            if (TestsData == null)
            {
                return;
            }
            if (svm == null)
            {
                return;//ako nije treniran ne radi nista
            }
            try
            {
                int counterPredicted = 0;
                int c3 = 0, c2 = 0, c5 = 0, c6 = 0, c7 = 0,c8=0, c9=0,c10=0,c12=0;
                for (i = 0; i < TestsData.Rows; i++)
                {
                    Matrix<float> row = TestsData.GetRow(i);
                 
                    float predict = svm.Predict(row, null);
                   
                    InputTest.Text = "Loaded Picture:" + TestsLabel[i, 0].ToString() + "0";
                   
                    label1.Text = "Recognized speed sign:" + predict.ToString() + "0";
                   // await Task.Delay(1000);

                    if (predict == TestsLabel[i, 0])
                    {
                        counterPredicted++;
                    }
                    if (TestsLabel[i, 0]==3 && predict == TestsLabel[i, 0])
                    {
                        c3++;
                    }
                    if (TestsLabel[i, 0] == 2 && predict == TestsLabel[i, 0])
                    {
                        c2++;
                    }
                    if (TestsLabel[i, 0] == 5 && predict == TestsLabel[i, 0])
                    {
                        c5++;
                    }
                    if (TestsLabel[i, 0] == 6 && predict == TestsLabel[i, 0])
                    {
                        c6++;
                    }
                    if (TestsLabel[i, 0] == 7 && predict == TestsLabel[i, 0])
                    {
                        c7++;
                    }
                    if (TestsLabel[i, 0] == 8 && predict == TestsLabel[i, 0])
                    {
                        c8++;
                    }
                    if (TestsLabel[i, 0] == 9 && predict == TestsLabel[i, 0])
                    {
                        c9++;
                    }
                    if (TestsLabel[i, 0] == 10 && predict == TestsLabel[i, 0])
                    {
                        c10++;
                    }
                    if (TestsLabel[i, 0] == 12 && predict == TestsLabel[i, 0])
                    {
                        c12++;
                    }

                    else
                    {
                        await Task.Delay(1);
                    }

                }



                SVMacc.Text = "Recognition accuracy:" + (counterPredicted / (float)TestsData.Rows);
                // if petlje i broji sve iz txt fila koliko i ima po klasi
                lbl4.Text = "30:" + c3 + ":" + ct3;
                lbl3.Text = "20:" + c2 + ":" + ct2;
                lbl5.Text = "50:" + c5 + ":" + ct5;
                lbl6.Text = "60:" + c6 + ":" + ct6;
                lbl7.Text = "70:" + c7 + ":" + ct7;
                lbl8.Text = "80:" + c8 + ":" + ct8;
                lbl9.Text = "90:" + c9 + ":" + ct9;
                lbl10.Text = "100:" + c10 + ":" + ct10;
                lbl12.Text = "120:" + c12 + ":" + ct12;
                lblTest.Text = "Number of detected \nspeed limit sigs:"+countDetectedTest.ToString();
                detAcc.Text = "Detection accuracy:" + (countDetectedTest / (float)TestsData.Rows);
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PrepoznavanjeZnakova_Load(object sender, EventArgs e)
        {
           
        }

        

        private async void TestMastifImg_Click(object sender, EventArgs e)
        {

            countDetectedTest = 0;
            List<int> TrainLabelList = new List<int>();
            List<float[]> TrainDataList = new List<float[]>();
           float ct3 = 0, ct4 = 0, ct5 = 0, ct6 = 0, ct7 = 0;
            int i = 0;
            string[] files3 = Directory.GetFiles(TestDataPath3, "*.ppm", SearchOption.AllDirectories);
            string[] files5 = Directory.GetFiles(TestDataPath5, "*.ppm", SearchOption.AllDirectories);
            string[] files7 = Directory.GetFiles(TestDataPath7, "*.ppm", SearchOption.AllDirectories);
            string[] files4 = Directory.GetFiles(TestDataPath4, "*.ppm", SearchOption.AllDirectories);
            string[] files6 = Directory.GetFiles(TestDataPath6, "*.ppm", SearchOption.AllDirectories);

            foreach (var file in files3)
            {
                Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                TrainDataList.Add(filteri(fileImage));
                TrainLabelList.Add(3);
                ct3++;
               // await Task.Delay(1000);
            }
            foreach (var file in files4)
            {
                Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                TrainDataList.Add(filteri(fileImage));
                TrainLabelList.Add(4);
                ct4++;
               // await Task.Delay(1000);
            }
            foreach (var file in files5)
            {
                Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                TrainDataList.Add(filteri(fileImage));
                TrainLabelList.Add(5);
                ct5++;
                //await Task.Delay(1000);
            }
            foreach (var file in files6)
            {
                Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                TrainDataList.Add(filteri(fileImage));
                TrainLabelList.Add(6);
                ct6++;
               // await Task.Delay(1000);
            }
            foreach (var file in files7)
            {
                Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                TrainDataList.Add(filteri(fileImage));
                TrainLabelList.Add(7);
                ct7++;
                //await Task.Delay(1000);
            }

            TestsDataM = new Matrix<float>(To2D<float>(TrainDataList.ToArray()));
            //MessageBox.Show(TestsData.Rows.ToString());
            TestsLabelM = new Matrix<int>(TrainLabelList.ToArray());
            //MessageBox.Show(TestsLabel.Rows.ToString());


            if (TestsDataM == null)
            {
                return;
            }
            if (svmMastif == null)
            {
                return;//ako nije treniran ne radi nista
            }
            try
            {
                int counter = 0;
                int c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0;
                for (i = 0; i < TestsDataM.Rows; i++)
                {
                    Matrix<float> row = TestsDataM.GetRow(i);
                    float predict = svmMastif.Predict(row, null);
                    //Image<Gray, Byte> imout = TestsData.GetRow(counter).Mat.Reshape(0, 28).ToImage<Gray, Byte>().ThresholdBinary(new Gray(30), new Gray(255));
                    // pictureBox1.Image = imout.Bitmap;
                    InputTest.Text = "Loaded image:" + TestsLabelM[i, 0].ToString() + "0";
                    label1.Text = "Recognized sign:" + predict.ToString() + "0";


                    if (predict == TestsLabelM[i, 0])
                    {
                        counter++;
                    }
                    if (TestsLabelM[i, 0] == 3 && predict == TestsLabelM[i, 0])
                    {
                        c3++;
                    }
                    if (TestsLabelM[i, 0] == 4 && predict == TestsLabelM[i, 0])
                    {
                        c4++;
                    }
                    if (TestsLabelM[i, 0] == 5 && predict == TestsLabelM[i, 0])
                    {
                        c5++;
                    }
                    if (TestsLabelM[i, 0] == 6 && predict == TestsLabelM[i, 0])
                    {
                        c6++;
                    }
                    if (TestsLabelM[i, 0] == 7 && predict == TestsLabelM[i, 0])
                    {
                        c7++;
                    }
                    
                }
                SVMacc.Text = "Recognition accuracy:" + (counter / (float)TestsDataM.Rows);
                lbl3.Text = "30:"+ c3+":"+ ct3;
                lbl4.Text = "40:" + c4 + ":" + ct4;
                lbl5.Text = "50:" + c5 + ":" + ct5;
                lbl6.Text = "60:" + c6 + ":" + ct6;
                lbl7.Text = "70:" + c7 + ":" + ct7;
                lbl8.Text = "";
                lbl9.Text = "";
                lbl10.Text = "";
                lbl12.Text = "";
                lblTest.Text = "Number of detected \nspeed limit sigs:"+ countDetectedTest.ToString();
                detAcc.Text = "Detection accuracy:" + (countDetectedTest / (float)TestsDataM.Rows);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog extensionLoad = new OpenFileDialog())
            {
                extensionLoad.InitialDirectory = "Debug";
                extensionLoad.Filter = "Python files (*.py)|*.py|All files (*.*)|*.*";

                if (extensionLoad.ShowDialog() == DialogResult.OK)
                {
                    var fileName = System.IO.Path.GetFileName(extensionLoad.FileName);
                    ScriptSource ss = pyEngine.CreateScriptSourceFromFile(fileName);
                    ss.Execute(pyScope);
                    //dynamic Function = pyScope.GetVariable("RunIme_Click");// želimo ga odmah runnati na pritisak gumba
                    dynamic addExtensions = pyScope.GetVariable("LoadExtension");
                    addExtensions(this);

                }

            }
        }

        private void TrainMastif_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("svmMastif.txt"))
                {
                    svmMastif = new SVM();
                    FileStorage file = new FileStorage("svmMastif.txt", FileStorage.Mode.Read);
                    svmMastif.Read(file.GetNode("opencv_ml_svm"));
                    MessageBox.Show("Svm opened.");
                }
                else
                {
                    //nesto ne valja u kodu auto, oni cv_32s fale
                    svmMastif = new SVM();

                    // TrainData traindata = new TrainData(TrainsData, DataLayoutType.RowSample, TrainsLabel);
                    svmMastif.C = 100;
                    svmMastif.Type = SVM.SvmType.CSvc;
                    svmMastif.Gamma = 0.1;
                    //0.02 je 89, 0.05 je 88
                    // svm.Gamma = 0.09; 0.844 u kombinciji sa c=5
                    svmMastif.SetKernel(SVM.SvmKernelType.Rbf);
                    // svm.Degree = 1;
                    svmMastif.TermCriteria = new MCvTermCriteria(1000, 1e-6);
                    svmMastif.Train(TrainsDataM, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, TrainsLabelM);
                    // svm.TrainAuto(traindata,20);
                    svmMastif.Save("svmMastif.txt");


                    MessageBox.Show("Svm Mastif is trained.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataLoadMastif_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> TrainLabelList = new List<int>();
                List<float[]> TrainDataList = new List<float[]>();
                int i = 0;
                string[] files3 = Directory.GetFiles(TrainDataPath3M, "*.ppm", SearchOption.AllDirectories);
                string[] files5 = Directory.GetFiles(TrainDataPath5M, "*.ppm", SearchOption.AllDirectories);
                string[] files7 = Directory.GetFiles(TrainDataPath7M, "*.ppm", SearchOption.AllDirectories);
                string[] files4 = Directory.GetFiles(TrainDataPath4M, "*.ppm", SearchOption.AllDirectories);
                string[] files6 = Directory.GetFiles(TrainDataPath6M, "*.ppm", SearchOption.AllDirectories);

                foreach (var file in files3)
                {
                    Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                    TrainDataList.Add(filteri(fileImage));
                    TrainLabelList.Add(3);


                }
                foreach (var file in files4)
                {
                    Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                    TrainDataList.Add(filteri(fileImage));
                    TrainLabelList.Add(4);
                }
                foreach (var file in files5)
                {
                    Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                    TrainDataList.Add(filteri(fileImage));
                    TrainLabelList.Add(5);
                }
                foreach (var file in files6)
                {
                    Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                    TrainDataList.Add(filteri(fileImage));
                    TrainLabelList.Add(6);
                }
                foreach (var file in files7)
                {
                    Image<Bgr, byte> fileImage = new Image<Bgr, byte>(file);
                    TrainDataList.Add(filteri(fileImage));
                    TrainLabelList.Add(7);
                }



                TrainsDataM = new Matrix<float>(To2D<float>(TrainDataList.ToArray()));


                TrainsLabelM = new Matrix<int>(TrainLabelList.ToArray());

                MessageBox.Show("Data loaded");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
    }


