using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;

namespace PictureCarrier
{
    public partial class frmMain : Form
    {
        string tmpPath = "";     //filiter
        string oriPath = "";    //original
        const string TEMPFILE = "\\tmp.bmp";

        TIImage.ImageFiliter CurrentFilter;
        ToolStripMenuItem CurrentMenuItem = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text += " ( V" + this.GetType().Assembly.GetName().Version.ToString() + " )";
            tmpPath = Path.GetDirectoryName(Application.ExecutablePath) + TEMPFILE;
            InitMenu();
        }
        private void InitMenu()
        {
            ToolStripMenuItem tm;

            //Checked the last time effect setup
            for (int i = 0; i < filtersToolStripMenuItem.DropDownItems.Count; i++)
            {
                if (filtersToolStripMenuItem.DropDownItems[i].GetType() == typeof(ToolStripMenuItem))
                {
                    tm = (ToolStripMenuItem)filtersToolStripMenuItem.DropDownItems[i];
                    if (PictureCarrier.Properties.Settings.Default.MenuFilterID == int.Parse(tm.Tag.ToString()))
                    {
                        CurrentMenuItem = tm;
                        tm.Checked = true;
                    }
                    else tm.Checked = false;
                }
            }
            tm = (ToolStripMenuItem)filtersToolStripMenuItem.DropDownItems[10];
            tm.Checked = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.CheckFileExists = true;
            ofd.Filter = "Image file|*.bmp;*.jpg;*.jpeg;*.png;*.wmf;*.gif";
            ofd.InitialDirectory = PictureCarrier.Properties.Settings.Default.OpenInitialDirectory;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picFilter.Image = null;
                picOriginal.Image = null;
                groupBox2.Text = "Filiter";

                try
                {
                    Application.DoEvents();
                    oriPath = ofd.FileName;
                    this.Text = "EPD Picture Carrier ( " + Path.GetFileName(oriPath) + " )";
                    picOriginal.LoadAsync(oriPath);

                    //20111103發現載入動態gif會有問題,改成上面的作法完成
                    //picOriginal.Image = TIImage.ReadImage(oriPath);
                    PictureCarrier.Properties.Settings.Default.OpenInitialDirectory = Path.GetDirectoryName(ofd.FileName);
                    timer1.Start();
                }
                catch (Exception exp) { MessageBox.Show(exp.Message); }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ClearFilterSelect()
        {
            ToolStripMenuItem tm;
            for (int i = 0; i < 11; i++)
            {
                tm = (ToolStripMenuItem)filtersToolStripMenuItem.DropDownItems[i];
                tm.Checked = false;
            }
        }
        private void ClearRotateSelect()
        {
            ToolStripMenuItem tm;
            for (int i = 12; i < 16; i++)
            {
                tm = (ToolStripMenuItem)filtersToolStripMenuItem.DropDownItems[i];
                tm.Checked = false;
            }
        }

        private void FiliterMenuItem_Click(object sender, EventArgs e)
        {
            if (oriPath == "") return;
            if (!File.Exists(oriPath)) return;

            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            ClearFilterSelect();
            tsmi.Checked = true;
            groupBox2.Text = "Filiter: ( " + tsmi.Text + " )";
            int index = Convert.ToInt32(tsmi.Tag);

            TIImage.ImageFiliter ifilter = TIImage.ImageFiliter.BayerDithering;

            switch (index)
            {
                case 1: ifilter = TIImage.ImageFiliter.Threshold; break;
                case 2: ifilter = TIImage.ImageFiliter.ThresholdWithCarry; break;
                case 3: ifilter = TIImage.ImageFiliter.OrderedDithering; break;
                case 4: ifilter = TIImage.ImageFiliter.BayerDithering; break;
                case 5: ifilter = TIImage.ImageFiliter.FloydSteinbergDithering; break;
                case 6: ifilter = TIImage.ImageFiliter.BurkesDithering; break;
                case 7: ifilter = TIImage.ImageFiliter.JarvisJudiceNinkeDithering; break;
                case 8: ifilter = TIImage.ImageFiliter.SierraDithering; break;
                case 9: ifilter = TIImage.ImageFiliter.StuckiDithering; break;
                case 10: ifilter = TIImage.ImageFiliter.Convolution; break;
                case 11: ifilter = TIImage.ImageFiliter.None; break;
            }
            try
            {
                if (ifilter == TIImage.ImageFiliter.Threshold)
                {
                    trackBar1.Value = 128;
                    trackBar1.Visible = true;
                    label1.Visible = true;
                    trackBar2.Value = 2;
                    trackBar2.Visible = true;

                }
                else
                {
                    trackBar1.Visible = false;
                    trackBar2.Visible = false;
                    label1.Visible = false;
                }

                // Bitmap im = new Bitmap(KLImage.ReadImage(oriPath),480,800);   //force the epaper size
                Bitmap im = TIImage.ApplyFiliter(ifilter, new Bitmap(picOriginal.Image));
                CurrentFilter = ifilter;
                CurrentMenuItem = tsmi;
                PictureCarrier.Properties.Settings.Default.MenuFilterID = index;
                im.Save(tmpPath, ImageFormat.Bmp);
                picFilter.Image = TIImage.ReadImage(tmpPath);
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }
        }

        private void RotateMenuItem_Click(object sender, EventArgs e)
        {
            if (picOriginal.Image == null) return;

            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            int index = Convert.ToInt32(tsmi.Tag);
            RotateFlipType rf = RotateFlipType.RotateNoneFlipNone;
            switch (index)
            {
                case 10: rf = RotateFlipType.RotateNoneFlipNone; break;
                case 11: rf = RotateFlipType.Rotate90FlipNone; break;
                case 12: rf = RotateFlipType.Rotate180FlipNone; break;
                case 13: rf = RotateFlipType.Rotate270FlipNone; break;
            }
            ClearRotateSelect();
            tsmi.Checked = true;
            try
            {
                Bitmap im = new Bitmap(TIImage.ReadImage(oriPath), 480, 800);   //force the epaper size
                im.RotateFlip(rf);
                // im.Save(tmpPath, ImageFormat.Bmp);
                picOriginal.Image = im;
                Bitmap imf = TIImage.ApplyFiliter(CurrentFilter, im);// im);
                imf.Save(tmpPath, ImageFormat.Bmp);
                picFilter.Image = TIImage.ReadImage(tmpPath);
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tmpPath)) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap file|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(tmpPath, sfd.FileName, true);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(tmpPath)) File.Delete(tmpPath);
            PictureCarrier.Properties.Settings.Default.Save();
        }

        private string OutPutBitmap(string filepath)
        {
            //string outfilepath;
            //FileInfo finfo = new FileInfo(filepath);
            //outfilepath = finfo.Directory.FullName + "\\" + finfo.Name + "_out.bmp";
            return OutPutBitmap(filepath, filepath);
        }
        private string OutPutBitmap(string filepath, string SavePath)
        {
            string outfilepath;
            Bitmap im = new Bitmap(TIImage.ReadImage(filepath), 480, 800);
            im.RotateFlip(RotateFlipType.Rotate180FlipX);//RotateNoneFlipX);
            im = TIImage.BitmapTo1Bpp(im);

            FileInfo finfo = new FileInfo(SavePath);
            outfilepath = finfo.Directory.FullName + "\\" + finfo.Name.Replace(finfo.Extension, "") + "_out.bmp";
            im.Save(outfilepath, System.Drawing.Imaging.ImageFormat.Bmp);
            return outfilepath;
        }

        DirectoryInfo RepeatDir = null;
        List<string> RepeatFolderFiles;
        int RepeatIndex = 0;
        private bool CheckPixelFormatSize(string ImageFileName)
        {
            if (!File.Exists(ImageFileName)) return false;
            Image im = Image.FromFile(ImageFileName);
            try
            {
                if (Image.GetPixelFormatSize(im.PixelFormat) == 1) return true;
                else return false;
            }
            finally
            {
                im.Dispose();
            }

        }
        string RepeatTempFolder = @"\Temp";
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lock (trackBar1)
            {
                try
                {
                    label1.Text = trackBar1.Value.ToString();
                    // Bitmap im = new Bitmap(KLImage.ReadImage(oriPath),480,800);   //force the epaper size
                    Bitmap im = TIImage.ApplyFiliter(TIImage.ImageFiliter.Threshold, new Bitmap(picOriginal.Image), (byte)trackBar1.Value, (byte)trackBar2.Value);
                    im.Save(tmpPath, ImageFormat.Bmp);
                    picFilter.Image = TIImage.ReadImage(tmpPath);
                }
                catch (Exception exp) { MessageBox.Show(exp.Message); }
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.Top = 50;
            this.Left = 0;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //picOriginal.Image = TIImage.ReadImage(oriPath);
            InitMenu();
            if (CurrentMenuItem != null) FiliterMenuItem_Click(CurrentMenuItem, null);
        }




    }
}
