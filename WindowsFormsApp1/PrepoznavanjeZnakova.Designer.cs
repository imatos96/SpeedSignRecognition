namespace WindowsFormsApp1
{
    partial class PrepoznavanjeZnakova
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrepoznavanjeZnakova));
            this.LoadImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WebCam = new System.Windows.Forms.RadioButton();
            this.CompImage = new System.Windows.Forms.RadioButton();
            this.picBoxExtractNum1 = new System.Windows.Forms.PictureBox();
            this.Filters = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RecTrainTest = new System.Windows.Forms.Button();
            this.Train = new System.Windows.Forms.Button();
            this.InputTest = new System.Windows.Forms.Label();
            this.TestSVM = new System.Windows.Forms.Button();
            this.SVMacc = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.detAcc = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.DataLoadMastif = new System.Windows.Forms.Button();
            this.TrainMastif = new System.Windows.Forms.Button();
            this.TestMastifImg = new System.Windows.Forms.Button();
            this.NaslovGtsrb = new System.Windows.Forms.Label();
            this.NaslovrMastif = new System.Windows.Forms.Label();
            this.NalsovManualy = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.yoloItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExtractNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoloItemBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadImage
            // 
            this.LoadImage.BackColor = System.Drawing.Color.Indigo;
            this.LoadImage.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.LoadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoadImage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoadImage.Location = new System.Drawing.Point(164, 135);
            this.LoadImage.Name = "LoadImage";
            this.LoadImage.Size = new System.Drawing.Size(174, 29);
            this.LoadImage.TabIndex = 0;
            this.LoadImage.Text = "Load Image";
            this.LoadImage.UseVisualStyleBackColor = false;
            this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(16, 234);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // WebCam
            // 
            this.WebCam.AutoSize = true;
            this.WebCam.BackColor = System.Drawing.Color.Indigo;
            this.WebCam.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.WebCam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.WebCam.Checked = true;
            this.WebCam.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.WebCam.Location = new System.Drawing.Point(164, 81);
            this.WebCam.Name = "WebCam";
            this.WebCam.Size = new System.Drawing.Size(184, 21);
            this.WebCam.TabIndex = 2;
            this.WebCam.TabStop = true;
            this.WebCam.Text = "Computer camera usage";
            this.WebCam.UseVisualStyleBackColor = false;
            // 
            // CompImage
            // 
            this.CompImage.AutoSize = true;
            this.CompImage.BackColor = System.Drawing.Color.Indigo;
            this.CompImage.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.CompImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CompImage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CompImage.Location = new System.Drawing.Point(164, 108);
            this.CompImage.Name = "CompImage";
            this.CompImage.Size = new System.Drawing.Size(174, 21);
            this.CompImage.TabIndex = 3;
            this.CompImage.Text = "Choose a computer file";
            this.CompImage.UseVisualStyleBackColor = false;
            // 
            // picBoxExtractNum1
            // 
            this.picBoxExtractNum1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app2;
            this.picBoxExtractNum1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxExtractNum1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxExtractNum1.Location = new System.Drawing.Point(16, 332);
            this.picBoxExtractNum1.Name = "picBoxExtractNum1";
            this.picBoxExtractNum1.Size = new System.Drawing.Size(54, 57);
            this.picBoxExtractNum1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxExtractNum1.TabIndex = 4;
            this.picBoxExtractNum1.TabStop = false;
            // 
            // Filters
            // 
            this.Filters.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.Filters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Filters.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Filters.Location = new System.Drawing.Point(164, 170);
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(174, 32);
            this.Filters.TabIndex = 10;
            this.Filters.Text = "Speed sign recognition";
            this.Filters.UseVisualStyleBackColor = true;
            this.Filters.Click += new System.EventHandler(this.Filters_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 12;
            // 
            // RecTrainTest
            // 
            this.RecTrainTest.BackColor = System.Drawing.Color.Aqua;
            this.RecTrainTest.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.RecTrainTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RecTrainTest.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RecTrainTest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RecTrainTest.Location = new System.Drawing.Point(12, 77);
            this.RecTrainTest.Name = "RecTrainTest";
            this.RecTrainTest.Size = new System.Drawing.Size(134, 45);
            this.RecTrainTest.TabIndex = 16;
            this.RecTrainTest.Text = "Data Load";
            this.RecTrainTest.UseVisualStyleBackColor = false;
            this.RecTrainTest.Click += new System.EventHandler(this.RecTrainTest_Click);
            // 
            // Train
            // 
            this.Train.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.Train.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Train.Location = new System.Drawing.Point(12, 128);
            this.Train.Name = "Train";
            this.Train.Size = new System.Drawing.Size(134, 43);
            this.Train.TabIndex = 17;
            this.Train.Text = "Train Database";
            this.Train.UseVisualStyleBackColor = true;
            this.Train.Click += new System.EventHandler(this.Train_Click);
            // 
            // InputTest
            // 
            this.InputTest.AutoSize = true;
            this.InputTest.BackColor = System.Drawing.Color.Transparent;
            this.InputTest.ForeColor = System.Drawing.Color.Black;
            this.InputTest.Location = new System.Drawing.Point(161, 258);
            this.InputTest.Name = "InputTest";
            this.InputTest.Size = new System.Drawing.Size(0, 17);
            this.InputTest.TabIndex = 18;
            // 
            // TestSVM
            // 
            this.TestSVM.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.TestSVM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TestSVM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TestSVM.Location = new System.Drawing.Point(12, 177);
            this.TestSVM.Name = "TestSVM";
            this.TestSVM.Size = new System.Drawing.Size(134, 37);
            this.TestSVM.TabIndex = 20;
            this.TestSVM.Text = "Test all images";
            this.TestSVM.UseVisualStyleBackColor = true;
            this.TestSVM.Click += new System.EventHandler(this.TestSVM_Click);
            // 
            // SVMacc
            // 
            this.SVMacc.AutoSize = true;
            this.SVMacc.BackColor = System.Drawing.Color.Transparent;
            this.SVMacc.ForeColor = System.Drawing.Color.Black;
            this.SVMacc.Location = new System.Drawing.Point(161, 283);
            this.SVMacc.Name = "SVMacc";
            this.SVMacc.Size = new System.Drawing.Size(0, 17);
            this.SVMacc.TabIndex = 21;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.BackColor = System.Drawing.Color.Transparent;
            this.lbl3.ForeColor = System.Drawing.Color.Black;
            this.lbl3.Location = new System.Drawing.Point(386, 234);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(0, 17);
            this.lbl3.TabIndex = 22;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.BackColor = System.Drawing.Color.Transparent;
            this.lbl4.ForeColor = System.Drawing.Color.Black;
            this.lbl4.Location = new System.Drawing.Point(386, 255);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(0, 17);
            this.lbl4.TabIndex = 23;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.BackColor = System.Drawing.Color.Transparent;
            this.lbl5.ForeColor = System.Drawing.Color.Black;
            this.lbl5.Location = new System.Drawing.Point(386, 277);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(0, 17);
            this.lbl5.TabIndex = 24;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.BackColor = System.Drawing.Color.Transparent;
            this.lbl6.ForeColor = System.Drawing.Color.Black;
            this.lbl6.Location = new System.Drawing.Point(386, 297);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(0, 17);
            this.lbl6.TabIndex = 25;
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.BackColor = System.Drawing.Color.Transparent;
            this.lbl8.ForeColor = System.Drawing.Color.Black;
            this.lbl8.Location = new System.Drawing.Point(386, 334);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(0, 17);
            this.lbl8.TabIndex = 27;
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.BackColor = System.Drawing.Color.Transparent;
            this.lbl9.ForeColor = System.Drawing.Color.Black;
            this.lbl9.Location = new System.Drawing.Point(386, 355);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(0, 17);
            this.lbl9.TabIndex = 28;
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.BackColor = System.Drawing.Color.Transparent;
            this.lbl10.ForeColor = System.Drawing.Color.Black;
            this.lbl10.Location = new System.Drawing.Point(386, 377);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(0, 17);
            this.lbl10.TabIndex = 29;
            // 
            // lbl12
            // 
            this.lbl12.AutoSize = true;
            this.lbl12.BackColor = System.Drawing.Color.Transparent;
            this.lbl12.ForeColor = System.Drawing.Color.Black;
            this.lbl12.Location = new System.Drawing.Point(386, 397);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(0, 17);
            this.lbl12.TabIndex = 30;
            // 
            // detAcc
            // 
            this.detAcc.AutoSize = true;
            this.detAcc.BackColor = System.Drawing.Color.Transparent;
            this.detAcc.ForeColor = System.Drawing.Color.Black;
            this.detAcc.Location = new System.Drawing.Point(161, 306);
            this.detAcc.Name = "detAcc";
            this.detAcc.Size = new System.Drawing.Size(0, 17);
            this.detAcc.TabIndex = 31;
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.BackColor = System.Drawing.Color.Transparent;
            this.lblTest.ForeColor = System.Drawing.Color.Black;
            this.lblTest.Location = new System.Drawing.Point(161, 332);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(0, 17);
            this.lblTest.TabIndex = 32;
            // 
            // DataLoadMastif
            // 
            this.DataLoadMastif.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.DataLoadMastif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DataLoadMastif.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataLoadMastif.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DataLoadMastif.Location = new System.Drawing.Point(376, 77);
            this.DataLoadMastif.Name = "DataLoadMastif";
            this.DataLoadMastif.Size = new System.Drawing.Size(134, 45);
            this.DataLoadMastif.TabIndex = 34;
            this.DataLoadMastif.Text = "Data Load";
            this.DataLoadMastif.UseVisualStyleBackColor = true;
            this.DataLoadMastif.Click += new System.EventHandler(this.DataLoadMastif_Click);
            // 
            // TrainMastif
            // 
            this.TrainMastif.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.TrainMastif.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TrainMastif.Location = new System.Drawing.Point(376, 128);
            this.TrainMastif.Name = "TrainMastif";
            this.TrainMastif.Size = new System.Drawing.Size(134, 43);
            this.TrainMastif.TabIndex = 35;
            this.TrainMastif.Text = "Train Database";
            this.TrainMastif.UseVisualStyleBackColor = true;
            this.TrainMastif.Click += new System.EventHandler(this.TrainMastif_Click);
            // 
            // TestMastifImg
            // 
            this.TestMastifImg.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.TestMastifImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TestMastifImg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TestMastifImg.Location = new System.Drawing.Point(376, 177);
            this.TestMastifImg.Name = "TestMastifImg";
            this.TestMastifImg.Size = new System.Drawing.Size(134, 37);
            this.TestMastifImg.TabIndex = 36;
            this.TestMastifImg.Text = "Test all images";
            this.TestMastifImg.UseVisualStyleBackColor = true;
            this.TestMastifImg.Click += new System.EventHandler(this.TestMastifImg_Click);
            // 
            // NaslovGtsrb
            // 
            this.NaslovGtsrb.AutoSize = true;
            this.NaslovGtsrb.BackColor = System.Drawing.Color.Transparent;
            this.NaslovGtsrb.ForeColor = System.Drawing.Color.Aqua;
            this.NaslovGtsrb.Location = new System.Drawing.Point(13, 48);
            this.NaslovGtsrb.Name = "NaslovGtsrb";
            this.NaslovGtsrb.Size = new System.Drawing.Size(133, 17);
            this.NaslovGtsrb.TabIndex = 37;
            this.NaslovGtsrb.Text = "GTSRB DATABASE";
            // 
            // NaslovrMastif
            // 
            this.NaslovrMastif.AutoSize = true;
            this.NaslovrMastif.BackColor = System.Drawing.Color.Transparent;
            this.NaslovrMastif.ForeColor = System.Drawing.Color.Aqua;
            this.NaslovrMastif.Location = new System.Drawing.Point(373, 48);
            this.NaslovrMastif.Name = "NaslovrMastif";
            this.NaslovrMastif.Size = new System.Drawing.Size(139, 17);
            this.NaslovrMastif.TabIndex = 38;
            this.NaslovrMastif.Text = "rMASTIF DATABASE";
            // 
            // NalsovManualy
            // 
            this.NalsovManualy.AutoSize = true;
            this.NalsovManualy.BackColor = System.Drawing.Color.Transparent;
            this.NalsovManualy.ForeColor = System.Drawing.Color.Aqua;
            this.NalsovManualy.Location = new System.Drawing.Point(180, 48);
            this.NalsovManualy.Name = "NalsovManualy";
            this.NalsovManualy.Size = new System.Drawing.Size(158, 17);
            this.NalsovManualy.TabIndex = 39;
            this.NalsovManualy.Text = "Choose Image Manually";
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.BackColor = System.Drawing.Color.Transparent;
            this.lbl7.ForeColor = System.Drawing.Color.Black;
            this.lbl7.Location = new System.Drawing.Point(386, 317);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(0, 17);
            this.lbl7.TabIndex = 40;
            // 
            // yoloItemBindingSource
            // 
            this.yoloItemBindingSource.DataSource = typeof(Alturos.Yolo.Model.YoloItem);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.background_app3;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resultsToolStripMenuItem,
            this.addedToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 28);
            this.menuStrip1.TabIndex = 43;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.resultsToolStripMenuItem.Text = "Results";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // addedToolStripMenuItem
            // 
            this.addedToolStripMenuItem.Name = "addedToolStripMenuItem";
            this.addedToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.addedToolStripMenuItem.Text = "Added";
            // 
            // PrepoznavanjeZnakova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(559, 448);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.NalsovManualy);
            this.Controls.Add(this.NaslovrMastif);
            this.Controls.Add(this.NaslovGtsrb);
            this.Controls.Add(this.TestMastifImg);
            this.Controls.Add(this.TrainMastif);
            this.Controls.Add(this.DataLoadMastif);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.detAcc);
            this.Controls.Add(this.lbl12);
            this.Controls.Add(this.lbl10);
            this.Controls.Add(this.lbl9);
            this.Controls.Add(this.lbl8);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.SVMacc);
            this.Controls.Add(this.TestSVM);
            this.Controls.Add(this.InputTest);
            this.Controls.Add(this.Train);
            this.Controls.Add(this.RecTrainTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Filters);
            this.Controls.Add(this.picBoxExtractNum1);
            this.Controls.Add(this.CompImage);
            this.Controls.Add(this.WebCam);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoadImage);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrepoznavanjeZnakova";
            this.Text = "The speed limit road sign recognition";
            this.Load += new System.EventHandler(this.PrepoznavanjeZnakova_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExtractNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoloItemBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton WebCam;
        private System.Windows.Forms.RadioButton CompImage;
        private System.Windows.Forms.PictureBox picBoxExtractNum1;
        private System.Windows.Forms.Button Filters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RecTrainTest;
        private System.Windows.Forms.Button Train;
        private System.Windows.Forms.Label InputTest;
        private System.Windows.Forms.Button TestSVM;
        private System.Windows.Forms.Label SVMacc;
        public System.Windows.Forms.Label lbl3;
        public System.Windows.Forms.Label lbl4;
        public System.Windows.Forms.Label lbl5;
        public System.Windows.Forms.Label lbl6;
        public System.Windows.Forms.Label lbl8;
        public System.Windows.Forms.Label lbl9;
        public System.Windows.Forms.Label lbl10;
        public System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label detAcc;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button DataLoadMastif;
        private System.Windows.Forms.Button TrainMastif;
        private System.Windows.Forms.Button TestMastifImg;
        private System.Windows.Forms.Label NaslovGtsrb;
        private System.Windows.Forms.Label NaslovrMastif;
        private System.Windows.Forms.Label NalsovManualy;
        public System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.BindingSource yoloItemBindingSource;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem addedToolStripMenuItem;
    }
}

