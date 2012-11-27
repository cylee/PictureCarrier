namespace PictureCarrier
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdWithCarryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderedDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bayerDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floydSteinbergDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burkesDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisJudiceNinkeDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sierraDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stuckiDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HSLStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NoneStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.rotate0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate0ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate0ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate0ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picFilter = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(721, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As ...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdToolStripMenuItem,
            this.thresholdWithCarryToolStripMenuItem,
            this.orderedDitheringToolStripMenuItem,
            this.bayerDitheringToolStripMenuItem,
            this.floydSteinbergDitheringToolStripMenuItem,
            this.burkesDitheringToolStripMenuItem,
            this.jarvisJudiceNinkeDitheringToolStripMenuItem,
            this.sierraDitheringToolStripMenuItem,
            this.stuckiDitheringToolStripMenuItem,
            this.HSLStripMenuItem,
            this.NoneStripMenuItem,
            this.toolStripMenuItem1,
            this.rotate0ToolStripMenuItem,
            this.rotate0ToolStripMenuItem1,
            this.rotate0ToolStripMenuItem2,
            this.rotate0ToolStripMenuItem3});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.thresholdToolStripMenuItem.Tag = "1";
            this.thresholdToolStripMenuItem.Text = "Threshold";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // thresholdWithCarryToolStripMenuItem
            // 
            this.thresholdWithCarryToolStripMenuItem.Name = "thresholdWithCarryToolStripMenuItem";
            this.thresholdWithCarryToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.thresholdWithCarryToolStripMenuItem.Tag = "2";
            this.thresholdWithCarryToolStripMenuItem.Text = "Threshold with carry";
            this.thresholdWithCarryToolStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // orderedDitheringToolStripMenuItem
            // 
            this.orderedDitheringToolStripMenuItem.Name = "orderedDitheringToolStripMenuItem";
            this.orderedDitheringToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.orderedDitheringToolStripMenuItem.Tag = "3";
            this.orderedDitheringToolStripMenuItem.Text = "Ordered dithering";
            this.orderedDitheringToolStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // bayerDitheringToolStripMenuItem
            // 
            this.bayerDitheringToolStripMenuItem.Name = "bayerDitheringToolStripMenuItem";
            this.bayerDitheringToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.bayerDitheringToolStripMenuItem.Tag = "4";
            this.bayerDitheringToolStripMenuItem.Text = "Bayer dithering";
            this.bayerDitheringToolStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // floydSteinbergDitheringToolStripMenuItem
            // 
            this.floydSteinbergDitheringToolStripMenuItem.Name = "floydSteinbergDitheringToolStripMenuItem";
            this.floydSteinbergDitheringToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.floydSteinbergDitheringToolStripMenuItem.Tag = "5";
            this.floydSteinbergDitheringToolStripMenuItem.Text = "Floyd-Steinberg dithering";
            this.floydSteinbergDitheringToolStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // burkesDitheringToolStripMenuItem
            // 
            this.burkesDitheringToolStripMenuItem.Name = "burkesDitheringToolStripMenuItem";
            this.burkesDitheringToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.burkesDitheringToolStripMenuItem.Tag = "6";
            this.burkesDitheringToolStripMenuItem.Text = "Burkes dithering";
            this.burkesDitheringToolStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // jarvisJudiceNinkeDitheringToolStripMenuItem
            // 
            this.jarvisJudiceNinkeDitheringToolStripMenuItem.Name = "jarvisJudiceNinkeDitheringToolStripMenuItem";
            this.jarvisJudiceNinkeDitheringToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.jarvisJudiceNinkeDitheringToolStripMenuItem.Tag = "7";
            this.jarvisJudiceNinkeDitheringToolStripMenuItem.Text = "Jarvis-Judice-Ninke dithering";
            this.jarvisJudiceNinkeDitheringToolStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // sierraDitheringToolStripMenuItem
            // 
            this.sierraDitheringToolStripMenuItem.Name = "sierraDitheringToolStripMenuItem";
            this.sierraDitheringToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.sierraDitheringToolStripMenuItem.Tag = "8";
            this.sierraDitheringToolStripMenuItem.Text = "Sierra dithering";
            this.sierraDitheringToolStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // stuckiDitheringToolStripMenuItem
            // 
            this.stuckiDitheringToolStripMenuItem.Name = "stuckiDitheringToolStripMenuItem";
            this.stuckiDitheringToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.stuckiDitheringToolStripMenuItem.Tag = "9";
            this.stuckiDitheringToolStripMenuItem.Text = "Stucki dithering";
            this.stuckiDitheringToolStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // HSLStripMenuItem
            // 
            this.HSLStripMenuItem.Name = "HSLStripMenuItem";
            this.HSLStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.HSLStripMenuItem.Tag = "10";
            this.HSLStripMenuItem.Text = "Convolution";
            this.HSLStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // NoneStripMenuItem
            // 
            this.NoneStripMenuItem.Name = "NoneStripMenuItem";
            this.NoneStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.NoneStripMenuItem.Tag = "11";
            this.NoneStripMenuItem.Text = "None";
            this.NoneStripMenuItem.Click += new System.EventHandler(this.FiliterMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(236, 6);
            // 
            // rotate0ToolStripMenuItem
            // 
            this.rotate0ToolStripMenuItem.Name = "rotate0ToolStripMenuItem";
            this.rotate0ToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.rotate0ToolStripMenuItem.Tag = "10";
            this.rotate0ToolStripMenuItem.Text = "Rotated 0°";
            this.rotate0ToolStripMenuItem.Click += new System.EventHandler(this.RotateMenuItem_Click);
            // 
            // rotate0ToolStripMenuItem1
            // 
            this.rotate0ToolStripMenuItem1.Name = "rotate0ToolStripMenuItem1";
            this.rotate0ToolStripMenuItem1.Size = new System.Drawing.Size(239, 22);
            this.rotate0ToolStripMenuItem1.Tag = "11";
            this.rotate0ToolStripMenuItem1.Text = "Rotated 90°";
            this.rotate0ToolStripMenuItem1.Click += new System.EventHandler(this.RotateMenuItem_Click);
            // 
            // rotate0ToolStripMenuItem2
            // 
            this.rotate0ToolStripMenuItem2.Name = "rotate0ToolStripMenuItem2";
            this.rotate0ToolStripMenuItem2.Size = new System.Drawing.Size(239, 22);
            this.rotate0ToolStripMenuItem2.Tag = "12";
            this.rotate0ToolStripMenuItem2.Text = "Rotated 180°";
            this.rotate0ToolStripMenuItem2.Click += new System.EventHandler(this.RotateMenuItem_Click);
            // 
            // rotate0ToolStripMenuItem3
            // 
            this.rotate0ToolStripMenuItem3.Name = "rotate0ToolStripMenuItem3";
            this.rotate0ToolStripMenuItem3.Size = new System.Drawing.Size(239, 22);
            this.rotate0ToolStripMenuItem3.Tag = "13";
            this.rotate0ToolStripMenuItem3.Text = "Rotated 270°";
            this.rotate0ToolStripMenuItem3.Click += new System.EventHandler(this.RotateMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picOriginal);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 485);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original";
            // 
            // picOriginal
            // 
            this.picOriginal.Location = new System.Drawing.Point(6, 21);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(320, 453);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picFilter);
            this.groupBox2.Location = new System.Drawing.Point(352, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 485);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // picFilter
            // 
            this.picFilter.Location = new System.Drawing.Point(6, 21);
            this.picFilter.Name = "picFilter";
            this.picFilter.Size = new System.Drawing.Size(320, 453);
            this.picFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFilter.TabIndex = 1;
            this.picFilter.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 2;
            this.trackBar1.Location = new System.Drawing.Point(684, 59);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 464);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Visible = false;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "128";
            this.label1.Visible = false;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(722, 59);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 464);
            this.trackBar2.TabIndex = 5;
            this.trackBar2.TickFrequency = 10;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar2.Visible = false;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 541);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EPD Picture Carrier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdWithCarryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderedDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bayerDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floydSteinbergDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem burkesDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jarvisJudiceNinkeDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sierraDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stuckiDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotate0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate0ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rotate0ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem rotate0ToolStripMenuItem3;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picFilter;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HSLStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NoneStripMenuItem;
   
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Timer timer1;
    }
}

