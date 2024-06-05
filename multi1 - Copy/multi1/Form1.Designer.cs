using System.Windows.Forms;

namespace multi1
{
    partial class Form1
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
            this.upload = new System.Windows.Forms.Button();
            this.applycoloring = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.jetcolormap = new System.Windows.Forms.Button();
            this.gnuplotcolor = new System.Windows.Forms.Button();
            this.terraincolor = new System.Windows.Forms.Button();
            this.comparing = new System.Windows.Forms.Button();
            this.classify = new System.Windows.Forms.Button();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.directorySearcher2 = new System.DirectoryServices.DirectorySearcher();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tealpanel1 = new System.Windows.Forms.Panel();
            this.fouriercomboBox = new System.Windows.Forms.ComboBox();
            this.searchbutton = new System.Windows.Forms.Button();
            this.reportbutton = new System.Windows.Forms.Button();
            this.addAudioCommentButton = new System.Windows.Forms.Button();
            this.comboBoxShapes = new System.Windows.Forms.ComboBox();
            this.cropbtn = new System.Windows.Forms.Button();
            this.pHome = new System.Windows.Forms.Panel();
            this.home = new System.Windows.Forms.Panel();
            this.sharetele = new System.Windows.Forms.Button();
            this.CompressImage = new System.Windows.Forms.Button();
            this.applytext = new System.Windows.Forms.Button();
            this.commenttextbox = new System.Windows.Forms.TextBox();
            this.savebutton = new System.Windows.Forms.Button();
            this.orginalimage = new System.Windows.Forms.PictureBox();
            this.result = new System.Windows.Forms.PictureBox();
            this.searchbysize = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sizeinput = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.fromdatepicker = new System.Windows.Forms.Label();
            this.todatepicker = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tealpanel1.SuspendLayout();
            this.pHome.SuspendLayout();
            this.home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orginalimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.result)).BeginInit();
            this.searchbysize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // upload
            // 
            this.upload.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.upload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload.Location = new System.Drawing.Point(2, 59);
            this.upload.Margin = new System.Windows.Forms.Padding(2);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(196, 41);
            this.upload.TabIndex = 1;
            this.upload.Text = "upload";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // applycoloring
            // 
            this.applycoloring.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.applycoloring.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.applycoloring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applycoloring.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applycoloring.Location = new System.Drawing.Point(-2, 106);
            this.applycoloring.Margin = new System.Windows.Forms.Padding(2);
            this.applycoloring.Name = "applycoloring";
            this.applycoloring.Size = new System.Drawing.Size(205, 38);
            this.applycoloring.TabIndex = 2;
            this.applycoloring.Text = "color";
            this.applycoloring.UseVisualStyleBackColor = true;
            this.applycoloring.Click += new System.EventHandler(this.applycoloring_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(1195, 515);
            this.save.Margin = new System.Windows.Forms.Padding(2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(67, 37);
            this.save.TabIndex = 6;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            // 
            // jetcolormap
            // 
            this.jetcolormap.Location = new System.Drawing.Point(132, 553);
            this.jetcolormap.Margin = new System.Windows.Forms.Padding(2);
            this.jetcolormap.Name = "jetcolormap";
            this.jetcolormap.Size = new System.Drawing.Size(59, 28);
            this.jetcolormap.TabIndex = 8;
            this.jetcolormap.Text = "JET";
            this.jetcolormap.UseVisualStyleBackColor = true;
            this.jetcolormap.Click += new System.EventHandler(this.jetcolormap_Click);
            // 
            // gnuplotcolor
            // 
            this.gnuplotcolor.Location = new System.Drawing.Point(0, 553);
            this.gnuplotcolor.Margin = new System.Windows.Forms.Padding(2);
            this.gnuplotcolor.Name = "gnuplotcolor";
            this.gnuplotcolor.Size = new System.Drawing.Size(64, 28);
            this.gnuplotcolor.TabIndex = 10;
            this.gnuplotcolor.Text = "GNUPLOT";
            this.gnuplotcolor.UseVisualStyleBackColor = true;
            this.gnuplotcolor.Click += new System.EventHandler(this.gnuplotcolor_Click);
            // 
            // terraincolor
            // 
            this.terraincolor.Location = new System.Drawing.Point(69, 553);
            this.terraincolor.Margin = new System.Windows.Forms.Padding(2);
            this.terraincolor.Name = "terraincolor";
            this.terraincolor.Size = new System.Drawing.Size(58, 28);
            this.terraincolor.TabIndex = 11;
            this.terraincolor.Text = "TERRAIN";
            this.terraincolor.UseVisualStyleBackColor = true;
            this.terraincolor.Click += new System.EventHandler(this.terraincolor_Click);
            // 
            // comparing
            // 
            this.comparing.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.comparing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comparing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comparing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comparing.Location = new System.Drawing.Point(-3, 149);
            this.comparing.Margin = new System.Windows.Forms.Padding(2);
            this.comparing.Name = "comparing";
            this.comparing.Size = new System.Drawing.Size(201, 38);
            this.comparing.TabIndex = 12;
            this.comparing.Text = "compare";
            this.comparing.UseVisualStyleBackColor = true;
            this.comparing.Click += new System.EventHandler(this.comparing_Click);
            // 
            // classify
            // 
            this.classify.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.classify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.classify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classify.Location = new System.Drawing.Point(-5, 192);
            this.classify.Margin = new System.Windows.Forms.Padding(2);
            this.classify.Name = "classify";
            this.classify.Size = new System.Drawing.Size(205, 38);
            this.classify.TabIndex = 13;
            this.classify.Text = "classify";
            this.classify.UseVisualStyleBackColor = true;
            this.classify.Click += new System.EventHandler(this.classify_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // directorySearcher2
            // 
            this.directorySearcher2.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher2.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher2.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // tealpanel1
            // 
            this.tealpanel1.BackColor = System.Drawing.Color.Teal;
            this.tealpanel1.Controls.Add(this.fouriercomboBox);
            this.tealpanel1.Controls.Add(this.searchbutton);
            this.tealpanel1.Controls.Add(this.reportbutton);
            this.tealpanel1.Controls.Add(this.addAudioCommentButton);
            this.tealpanel1.Controls.Add(this.comparing);
            this.tealpanel1.Controls.Add(this.comboBoxShapes);
            this.tealpanel1.Controls.Add(this.cropbtn);
            this.tealpanel1.Controls.Add(this.upload);
            this.tealpanel1.Controls.Add(this.applycoloring);
            this.tealpanel1.Controls.Add(this.gnuplotcolor);
            this.tealpanel1.Controls.Add(this.terraincolor);
            this.tealpanel1.Controls.Add(this.classify);
            this.tealpanel1.Controls.Add(this.jetcolormap);
            this.tealpanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tealpanel1.Location = new System.Drawing.Point(0, 0);
            this.tealpanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tealpanel1.Name = "tealpanel1";
            this.tealpanel1.Size = new System.Drawing.Size(196, 591);
            this.tealpanel1.TabIndex = 15;
            // 
            // fouriercomboBox
            // 
            this.fouriercomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fouriercomboBox.FormattingEnabled = true;
            this.fouriercomboBox.Location = new System.Drawing.Point(-2, 28);
            this.fouriercomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.fouriercomboBox.Name = "fouriercomboBox";
            this.fouriercomboBox.Size = new System.Drawing.Size(199, 25);
            this.fouriercomboBox.TabIndex = 21;
            this.fouriercomboBox.Text = "Fourier";
            this.fouriercomboBox.SelectedIndexChanged += new System.EventHandler(this.fouriercomboBox_SelectedIndexChanged);
            // 
            // searchbutton
            // 
            this.searchbutton.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.searchbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.searchbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbutton.Location = new System.Drawing.Point(0, 235);
            this.searchbutton.Margin = new System.Windows.Forms.Padding(2);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(200, 38);
            this.searchbutton.TabIndex = 20;
            this.searchbutton.Text = "Search";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // reportbutton
            // 
            this.reportbutton.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.reportbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.reportbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportbutton.Location = new System.Drawing.Point(-2, 366);
            this.reportbutton.Margin = new System.Windows.Forms.Padding(2);
            this.reportbutton.Name = "reportbutton";
            this.reportbutton.Size = new System.Drawing.Size(200, 38);
            this.reportbutton.TabIndex = 19;
            this.reportbutton.Text = "Creat a report";
            this.reportbutton.UseVisualStyleBackColor = true;
            this.reportbutton.Click += new System.EventHandler(this.reportbutton_Click);
            // 
            // addAudioCommentButton
            // 
            this.addAudioCommentButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.addAudioCommentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addAudioCommentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAudioCommentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAudioCommentButton.Location = new System.Drawing.Point(-3, 323);
            this.addAudioCommentButton.Margin = new System.Windows.Forms.Padding(2);
            this.addAudioCommentButton.Name = "addAudioCommentButton";
            this.addAudioCommentButton.Size = new System.Drawing.Size(200, 38);
            this.addAudioCommentButton.TabIndex = 18;
            this.addAudioCommentButton.Text = "Record";
            this.addAudioCommentButton.UseVisualStyleBackColor = true;
            this.addAudioCommentButton.Click += new System.EventHandler(this.addAudioCommentButton_Click);
            // 
            // comboBoxShapes
            // 
            this.comboBoxShapes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxShapes.FormattingEnabled = true;
            this.comboBoxShapes.Location = new System.Drawing.Point(0, 0);
            this.comboBoxShapes.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxShapes.Name = "comboBoxShapes";
            this.comboBoxShapes.Size = new System.Drawing.Size(197, 25);
            this.comboBoxShapes.TabIndex = 0;
            this.comboBoxShapes.Text = "select shape:";
            this.comboBoxShapes.SelectedIndexChanged += new System.EventHandler(this.comboBoxShapes_SelectedIndexChanged);
            // 
            // cropbtn
            // 
            this.cropbtn.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.cropbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cropbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cropbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cropbtn.Location = new System.Drawing.Point(-5, 280);
            this.cropbtn.Margin = new System.Windows.Forms.Padding(2);
            this.cropbtn.Name = "cropbtn";
            this.cropbtn.Size = new System.Drawing.Size(200, 38);
            this.cropbtn.TabIndex = 15;
            this.cropbtn.Text = "crop";
            this.cropbtn.UseVisualStyleBackColor = true;
            this.cropbtn.Click += new System.EventHandler(this.cropbtn_Click);
            // 
            // pHome
            // 
            this.pHome.Controls.Add(this.home);
            this.pHome.Controls.Add(this.searchbysize);
            this.pHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pHome.Location = new System.Drawing.Point(196, 0);
            this.pHome.Margin = new System.Windows.Forms.Padding(2);
            this.pHome.Name = "pHome";
            this.pHome.Size = new System.Drawing.Size(1076, 591);
            this.pHome.TabIndex = 16;
            // 
            // home
            // 
            this.home.Controls.Add(this.sharetele);
            this.home.Controls.Add(this.CompressImage);
            this.home.Controls.Add(this.applytext);
            this.home.Controls.Add(this.commenttextbox);
            this.home.Controls.Add(this.savebutton);
            this.home.Controls.Add(this.orginalimage);
            this.home.Controls.Add(this.result);
            this.home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.home.Location = new System.Drawing.Point(0, 0);
            this.home.Margin = new System.Windows.Forms.Padding(2);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(1076, 591);
            this.home.TabIndex = 6;
            // 
            // sharetele
            // 
            this.sharetele.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.sharetele.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sharetele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sharetele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sharetele.Location = new System.Drawing.Point(257, 541);
            this.sharetele.Margin = new System.Windows.Forms.Padding(2);
            this.sharetele.Name = "sharetele";
            this.sharetele.Size = new System.Drawing.Size(110, 40);
            this.sharetele.TabIndex = 22;
            this.sharetele.Text = "Share";
            this.sharetele.UseVisualStyleBackColor = true;
            this.sharetele.Click += new System.EventHandler(this.sharetele_Click);
            // 
            // CompressImage
            // 
            this.CompressImage.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.CompressImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompressImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompressImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompressImage.Location = new System.Drawing.Point(372, 541);
            this.CompressImage.Margin = new System.Windows.Forms.Padding(2);
            this.CompressImage.Name = "CompressImage";
            this.CompressImage.Size = new System.Drawing.Size(110, 40);
            this.CompressImage.TabIndex = 21;
            this.CompressImage.Text = "Compress ";
            this.CompressImage.UseVisualStyleBackColor = true;
            this.CompressImage.Click += new System.EventHandler(this.CompressImage_Click);
            // 
            // applytext
            // 
            this.applytext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.applytext.Location = new System.Drawing.Point(192, 298);
            this.applytext.Margin = new System.Windows.Forms.Padding(2);
            this.applytext.Name = "applytext";
            this.applytext.Size = new System.Drawing.Size(56, 20);
            this.applytext.TabIndex = 20;
            this.applytext.Text = "Ok";
            this.applytext.UseVisualStyleBackColor = true;
            this.applytext.Click += new System.EventHandler(this.applytext_Click);
            // 
            // commenttextbox
            // 
            this.commenttextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commenttextbox.Location = new System.Drawing.Point(8, 298);
            this.commenttextbox.Margin = new System.Windows.Forms.Padding(2);
            this.commenttextbox.Name = "commenttextbox";
            this.commenttextbox.Size = new System.Drawing.Size(240, 20);
            this.commenttextbox.TabIndex = 19;
            // 
            // savebutton
            // 
            this.savebutton.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.savebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.savebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebutton.Location = new System.Drawing.Point(487, 541);
            this.savebutton.Margin = new System.Windows.Forms.Padding(2);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(110, 40);
            this.savebutton.TabIndex = 18;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // orginalimage
            // 
            this.orginalimage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.orginalimage.Location = new System.Drawing.Point(8, 16);
            this.orginalimage.Margin = new System.Windows.Forms.Padding(2);
            this.orginalimage.Name = "orginalimage";
            this.orginalimage.Size = new System.Drawing.Size(240, 271);
            this.orginalimage.TabIndex = 6;
            this.orginalimage.TabStop = false;
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(264, 16);
            this.result.Margin = new System.Windows.Forms.Padding(2);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(240, 271);
            this.result.TabIndex = 7;
            this.result.TabStop = false;
            // 
            // searchbysize
            // 
            this.searchbysize.Controls.Add(this.textBox1);
            this.searchbysize.Controls.Add(this.sizeinput);
            this.searchbysize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchbysize.Location = new System.Drawing.Point(0, 0);
            this.searchbysize.Margin = new System.Windows.Forms.Padding(2);
            this.searchbysize.Name = "searchbysize";
            this.searchbysize.Size = new System.Drawing.Size(1076, 591);
            this.searchbysize.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(179, 73);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 20);
            this.textBox1.TabIndex = 1;
            // 
            // sizeinput
            // 
            this.sizeinput.AutoSize = true;
            this.sizeinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeinput.ForeColor = System.Drawing.Color.Teal;
            this.sizeinput.Location = new System.Drawing.Point(19, 73);
            this.sizeinput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sizeinput.Name = "sizeinput";
            this.sizeinput.Size = new System.Drawing.Size(155, 24);
            this.sizeinput.TabIndex = 0;
            this.sizeinput.Text = "Enter The Size:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(146, 101);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(228, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(498, 101);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(225, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // fromdatepicker
            // 
            this.fromdatepicker.AutoSize = true;
            this.fromdatepicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromdatepicker.ForeColor = System.Drawing.Color.Teal;
            this.fromdatepicker.Location = new System.Drawing.Point(3, 98);
            this.fromdatepicker.Name = "fromdatepicker";
            this.fromdatepicker.Size = new System.Drawing.Size(119, 25);
            this.fromdatepicker.TabIndex = 2;
            this.fromdatepicker.Text = "From Date:";
            // 
            // todatepicker
            // 
            this.todatepicker.AutoSize = true;
            this.todatepicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todatepicker.ForeColor = System.Drawing.Color.Teal;
            this.todatepicker.Location = new System.Drawing.Point(380, 99);
            this.todatepicker.Name = "todatepicker";
            this.todatepicker.Size = new System.Drawing.Size(96, 25);
            this.todatepicker.TabIndex = 3;
            this.todatepicker.Text = "To Date:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1272, 591);
            this.Controls.Add(this.pHome);
            this.Controls.Add(this.tealpanel1);
            this.Controls.Add(this.save);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "X-RAY";
            this.tealpanel1.ResumeLayout(false);
            this.pHome.ResumeLayout(false);
            this.home.ResumeLayout(false);
            this.home.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orginalimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.result)).EndInit();
            this.searchbysize.ResumeLayout(false);
            this.searchbysize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.Button applycoloring;
        private System.Windows.Forms.Button save;
        private Button jetcolormap;
        private Button gnuplotcolor;
        private Button terraincolor;
        private Button comparing;
        private Button classify;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.DirectoryServices.DirectorySearcher directorySearcher2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel tealpanel1;
        private Panel pHome;
        private Button cropbtn;
        private ComboBox comboBoxShapes;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Panel home;
        
        private Label todatepicker;
        private Label fromdatepicker;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Panel searchbysize;
        private TextBox textBox1;
        private Label sizeinput;
        private PictureBox orginalimage;
        private PictureBox result;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Button savebutton;
        private TextBox commenttextbox;
        private Button addAudioCommentButton;
        private Button reportbutton;
        private Button applytext;
        private Button CompressImage;
        private Button sharetele;
        private Button searchbutton;
        private ComboBox fouriercomboBox;
    }
}

