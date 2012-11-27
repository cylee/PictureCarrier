using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

using AForge.Imaging;
using AForge.Imaging.Filters;

namespace PictureCarrier
{
    public static class TIImage
    {
        public enum ImageFiliter { Threshold, ThresholdWithCarry, OrderedDithering, BayerDithering, FloydSteinbergDithering, BurkesDithering, JarvisJudiceNinkeDithering, SierraDithering, StuckiDithering, Convolution, None }

        public static Bitmap ApplyFiliter(Bitmap bmp)
        {
            //轉換成 1bit bps

            Bitmap newImage = BitmapTo1Bpp(bmp);
            return newImage;
        }
        public static Bitmap ApplyFiliter(ImageFiliter imgFilter, Bitmap bmp)
        {
            return ApplyFiliter(imgFilter, bmp, 0);
        }
        public static Bitmap ApplyFiliter(ImageFiliter imgFilter, Bitmap bmp, byte Value)
        {
            return ApplyFiliter(imgFilter, bmp, Value, 0);
        }
        public static Bitmap ApplyFiliter(ImageFiliter imgFilter, Bitmap bmp, byte Value, byte Value2)
        {
            Bitmap newImage = null;
            //ContrastCorrection filter2 = new ContrastCorrection(1.0);
            //newImage = filter2.Apply(bmp);
            if (imgFilter != ImageFiliter.None)
            {
                IFilter filter3 = Grayscale.CommonAlgorithms.Y;
                newImage = filter3.Apply(bmp);

                if (imgFilter == ImageFiliter.Threshold)
                {
                    IFilter filter = null;
                    if (Value == 0) filter = new Threshold();
                    else filter = new Threshold(Value);
                    newImage = filter.Apply(newImage);

                    //IterativeThreshold filter = new IterativeThreshold(Value2, Value);
                    //// apply the filter
                    // newImage = filter.Apply(newImage);
                }
                if (imgFilter == ImageFiliter.ThresholdWithCarry)
                {
                    IFilter filter = new ThresholdWithCarry();
                    newImage = filter.Apply(newImage);
                }
                else if (imgFilter == ImageFiliter.OrderedDithering)
                {
                    IFilter filter = new OrderedDithering();
                    newImage = filter.Apply(newImage);
                }
                else if (imgFilter == ImageFiliter.BayerDithering)
                {
                    IFilter filter = new BayerDithering();
                    newImage = filter.Apply(newImage);
                }
                else if (imgFilter == ImageFiliter.FloydSteinbergDithering)
                {
                    IFilter filter = new FloydSteinbergDithering();
                    newImage = filter.Apply(newImage);
                }
                else if (imgFilter == ImageFiliter.BurkesDithering)
                {
                    IFilter filter = new BurkesDithering();
                    newImage = filter.Apply(newImage);
                }
                else if (imgFilter == ImageFiliter.JarvisJudiceNinkeDithering)
                {
                    IFilter filter = new JarvisJudiceNinkeDithering();
                    newImage = filter.Apply(newImage);
                }
                else if (imgFilter == ImageFiliter.SierraDithering)
                {
                    IFilter filter = new SierraDithering();
                    newImage = filter.Apply(newImage);
                }
                else if (imgFilter == ImageFiliter.StuckiDithering)
                {
                    IFilter filter = new StuckiDithering();
                    newImage = filter.Apply(newImage);

                }
                else if (imgFilter == ImageFiliter.Convolution)
                {
                    // create filter
                    //OtsuThreshold filter = new OtsuThreshold();
                    //// apply the filter
                    //filter.ApplyInPlace(newImage);

                    //// create filter
                    //IterativeThreshold filter = new IterativeThreshold(0);
                    //// apply the filter
                    //newImage = filter.Apply(newImage);

                    int[,] kernel = {
                            { -2, -1,  0 },
                            { -1,  1,  1 },
                            {  0,  1,  2 } 
                                };
                    // create filter
                    Convolution filter = new Convolution(kernel);
                    // apply the filter
                    filter.ApplyInPlace(newImage);
                }
                newImage = BitmapTo1Bpp(newImage);
            }
            else newImage = BitmapTo1Bpp(bmp);
            //轉換成 1bit bps
            return newImage;
        }
        private static Graphics ConvertTextToImage(string txt, Graphics g, Color BackColor, Color ForeColor, int X, int Y, Font txtFont)     //bolRotate =true 是要旋轉90度
        {

            //List<DrawTextItem> dtList = SpiltText(oi); //split the length of oi.Text string  

            //for (int i = 0; i < dtList.Count; i++)
            //{
            try
            {
                Bitmap objBmpImage = new Bitmap(1, 1);
                int intWidth = 0;
                int intHeight = 0;

                // Create the Font object for the image text drawing.

                // Create a graphics object to measure the text's width and height.
                Graphics objGraphics = Graphics.FromImage(objBmpImage);

                // This is where the bitmap size is determined.

                intWidth = (int)objGraphics.MeasureString(txt, txtFont).Width;
                intHeight = (int)objGraphics.MeasureString(txt, txtFont).Height;

                // Create the bmpImage again with the correct size for the text and font.
                objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

                // Add the colors to the new bitmap.
                objGraphics = Graphics.FromImage(objBmpImage);

                // Set Background color
                objGraphics.Clear(Color.White);// BGColor);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.FormatFlags = StringFormatFlags.LineLimit;
                objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                RectangleF centered = objGraphics.VisibleClipBounds;

                objGraphics.DrawString(txt, txtFont, new SolidBrush(ForeColor), centered, sf);
                objGraphics.Flush();

                // if (bolRotate) objBmpImage.RotateFlip(RotateFlipType.Rotate90FlipNone);   //旋轉圖片
                g.DrawImageUnscaled(objBmpImage, X, Y);

            }
            catch { }
            //}
            return g;// ((Image)objBmpImage);
        }
        //2011.11.03發現載入動態gif時會有錯誤, 後改用 pictureBox1.LoadSync 來取代
        public static System.Drawing.Image ReadImage(string imgPath)
        {
            System.Drawing.Image im = null;
            try
            {
                // MemoryStream memStream;                      
                using (FileStream sr = new FileStream(imgPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 8192))
                {
                    im = System.Drawing.Image.FromStream(sr);
                }
            }
            catch { }
            return im;
        }
        private static Bitmap Get1BppImage(Bitmap srcBitmap)
        {
            //Be sure to have / create a Format32bppPArgb bitmap and resize it
            if (srcBitmap.PixelFormat != PixelFormat.Format32bppPArgb)
            {
                Bitmap temp = new Bitmap(srcBitmap.Width, srcBitmap.Height, PixelFormat.Format32bppPArgb);
                temp.SetResolution(srcBitmap.Width, srcBitmap.Height);
                Graphics g = Graphics.FromImage(temp);
                g.DrawImage(srcBitmap, new Rectangle(0, 0, temp.Width, temp.Height), 0, 0, srcBitmap.Width, srcBitmap.Height, GraphicsUnit.Pixel);
                srcBitmap.Dispose();
                g.Dispose();
                srcBitmap = temp;
            }

            //lock the bits of the original bitmap
            BitmapData bmdo = srcBitmap.LockBits(new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height), ImageLockMode.ReadOnly, srcBitmap.PixelFormat);

            //and the new 1bpp bitmap
            Bitmap destBitmap = new Bitmap(srcBitmap.Width, srcBitmap.Height, PixelFormat.Format1bppIndexed);
            BitmapData bmdn = destBitmap.LockBits(new Rectangle(0, 0, destBitmap.Width, destBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
            destBitmap.SetResolution(srcBitmap.Width, srcBitmap.Height); //I want a resolution of 200dpi x 200dpi

            //scan through the pixels Y by X
            int x, y;

            for (x = 0; x < srcBitmap.Width; x++)
            {
                for (y = 0; y < srcBitmap.Height; y++)
                {
                    //generate the address of the colour pixel

                    int index = y * bmdo.Stride + (x * 4);
                    float myBrigthness = Color.FromArgb(Marshal.ReadByte(bmdo.Scan0, index + 2),
                                     Marshal.ReadByte(bmdo.Scan0, index + 1),
                                     Marshal.ReadByte(bmdo.Scan0, index)).GetBrightness();

                    //check its brightness and if between 0.33f and 0.67f create fake gray by alternating black and white (note that you have to cross depending on x-y position)
                    if (myBrigthness < 0.33f)
                    {
                        //Black thus do nothing
                    }
                    else if (myBrigthness < 0.67f)
                    {
                        if ((x + (y % 2)) % 2 == 1)
                        {
                            //Black thus do nothing
                        }
                        else
                        {
                            //White
                            SetIndexedPixel(x, y, bmdn, true); //set it if its bright.
                        }
                    }
                    else
                    {
                        //White
                        SetIndexedPixel(x, y, bmdn, true); //set it if its bright.
                    }
                }
            }

            //tidy up
            destBitmap.UnlockBits(bmdn);
            srcBitmap.UnlockBits(bmdo);

            return destBitmap;
        }

        static void SetIndexedPixel(int x, int y, BitmapData bmd, bool pixel)
        {
            int index = y * bmd.Stride + (x >> 3);
            byte p = Marshal.ReadByte(bmd.Scan0, index);
            byte mask = (byte)(0x80 >> (x & 0x7));
            if (pixel)
                p |= mask;
            else
                p &= (byte)(mask ^ 0xff);
            Marshal.WriteByte(bmd.Scan0, index, p);
        }
        public static Bitmap BitmapTo1Bpp(Bitmap img)
        {
            return BitmapTo1Bpp2(img);
        }
        public static Bitmap BitmapTo1Bpp2(Bitmap img)
        {
            int w = img.Width;
            int h = img.Height;
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format1bppIndexed);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
            // string s = "";
            for (int y = 0; y < h; y++)
            {
                // s = "";
                byte[] scan = new byte[(w + 7) / 8];
                for (int x = 0; x < w; x++)
                {
                    Color c = img.GetPixel(x, y);
                    if (c.GetBrightness() >= 0.5)
                    {
                        scan[x / 8] |= (byte)(0x80 >> (x % 8));
                    }
                }

                //for (int i = 0; i < scan.Length; i++)
                //{
                //    s += i.ToString()+ scan[i].ToString("x2")+",";
                //}
                Marshal.Copy(scan, 0, (IntPtr)((int)data.Scan0 + data.Stride * y), scan.Length);
                //   Debug.Print(s);
            }

            return bmp;
        }
        public static ImageFiliter GetFiliterFromIndex(int index)
        {
            ImageFiliter ifilter = new ImageFiliter();
            switch (index)
            {
                case 0: ifilter = ImageFiliter.OrderedDithering; break;
                case 1: ifilter = ImageFiliter.Threshold; break;
                case 2: ifilter = ImageFiliter.ThresholdWithCarry; break;
                case 3: ifilter = ImageFiliter.BayerDithering; break;
                case 4: ifilter = ImageFiliter.FloydSteinbergDithering; break;
                case 5: ifilter = ImageFiliter.BurkesDithering; break;
                case 6: ifilter = ImageFiliter.JarvisJudiceNinkeDithering; break;
                case 7: ifilter = ImageFiliter.SierraDithering; break;
                case 8: ifilter = ImageFiliter.StuckiDithering; break;
                case 9: ifilter = ImageFiliter.Convolution; break;
                default: ifilter = ImageFiliter.OrderedDithering; break;
            }
            return ifilter;
        }
        public static ImageFiliter GetFiliterFromString(string name)
        {
            ImageFiliter ifilter = new ImageFiliter();
            switch (name)
            {
                case "OrderedDithering": ifilter = ImageFiliter.OrderedDithering; break;
                case "Threshold": ifilter = ImageFiliter.Threshold; break;
                case "ThresholdWithCarry": ifilter = ImageFiliter.ThresholdWithCarry; break;
                case "BayerDithering": ifilter = ImageFiliter.BayerDithering; break;
                case "FloydSteinbergDithering": ifilter = ImageFiliter.FloydSteinbergDithering; break;
                case "BurkesDithering": ifilter = ImageFiliter.BurkesDithering; break;
                case "JarvisJudiceNinkeDithering": ifilter = ImageFiliter.JarvisJudiceNinkeDithering; break;
                case "SierraDithering": ifilter = ImageFiliter.SierraDithering; break;
                case "StuckiDithering": ifilter = ImageFiliter.StuckiDithering; break;
                case "Convolution": ifilter = ImageFiliter.Convolution; break;
                default: ifilter = ImageFiliter.Threshold; break;

            }
            return ifilter;
        }
        /// <summary>
        /// 回傳圖片的所有陣列
        /// </summary>
        /// <param name="ImageFilePath"></param>
        /// <returns></returns>
        public static List<byte[]> ImageToByteArray(string ImageFilePath, int spiltSize)
        {
            const byte BMPOffset = 0x3e;
            // const ushort PayloadMax = 100;
            List<byte[]> SendBuffer = new List<byte[]>();

            FileStream fs = new FileStream(ImageFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 8046);
            try
            {
                ushort fristFrame = (ushort)((fs.Length - BMPOffset) / spiltSize);
                fs.Seek((long)BMPOffset, SeekOrigin.Begin);


                for (int i = 0; i < (int)fristFrame; i++)
                {
                    byte[] bs = new byte[spiltSize];

                    fs.Read(bs, 0, spiltSize);
                    string s = "";
                    for (int j = 0; j < bs.Length; j++)
                    {
                        s += bs[j].ToString("x2") + ",";
                        bs[j] = (byte)(bs[j] ^ 0xff);  //做圖片反轉,黑變白, 白變黑
                    }
                    // Debug.Print(s);
                    SendBuffer.Add(bs);
                }
                Debug.Print("finished Image to byte array");
                return SendBuffer;

            }
            catch { return null; }
            finally
            {
                fs.Close();
                fs.Dispose();
            }

            // SendBuffer.Clear();

            //for (int i = 0; i < 100; i++)
            //{
            //    bs[i] = byte.Parse(pageData.Trim(), System.Globalization.NumberStyles.HexNumber);
            //}
            //FileStream fs = File.OpenRead(FileName);
            //  byte[] content = new byte[fs.Length];
            //  fs.Read(content, 0, content.Length);
            //  fs.Close();

        }

        //public static Graphics ConvertImageToGray(string ImgFile, Graphics g)
        //{
        //    if (!File.Exists(ImgFile)) return g;
        //    System.Drawing.Image im = ReadImage(ImgFile);
        //    if (im == null) return g;

        //    try
        //    {
        //        // Step 1: 利用 Bitmap 將 image 包起來 
        //        Bitmap bimage = new Bitmap(im);
        //        int Height = bimage.Height;
        //        int Width = bimage.Width;
        //        int[, ,] rgbData = new int[Width, Height, 3];

        //        // Step 2: 取得像點顏色資訊 
        //        for (int y = 0; y < Height; y++)
        //        {
        //            for (int x = 0; x < Width; x++)
        //            {
        //                Color color = bimage.GetPixel(x, y);
        //                rgbData[x, y, 0] = color.R;
        //                rgbData[x, y, 1] = color.G;
        //                rgbData[x, y, 2] = color.B;
        //            }
        //        }

        //        // Step 2: 設定像點資料
        //        for (int y = 0; y < Height; y++)
        //        {
        //            for (int x = 0; x < Width; x++)
        //            {
        //                //寫入成黑白
        //                //if (rgbData[x, y, 0] != 255 && rgbData[x, y, 1] != 255 && rgbData[x, y, 2] != 255) 
        //                //    bimage.SetPixel(x, y, Color.FromArgb(0, 0, 0));
        //                //else bimage.SetPixel(x, y, Color.FromArgb(255, 255, 255));

        //                //int gray = (byte)((float)rgbData[x, y, 0] * 0.114f + (float)rgbData[x, y, 1] * 0.587f + (float)rgbData[x, y, 2] * 0.299f);
        //                //if (gray > 250) bimage.SetPixel(x, y, Color.FromArgb(255, 255, 255));
        //                //else bimage.SetPixel(x, y, Color.FromArgb(0, 0, 0));

        //                //寫入成灰階
        //                //加權平均法
        //                int gray = (byte)((float)rgbData[x, y, 0] * 0.114f + (float)rgbData[x, y, 1] * 0.587f + (float)rgbData[x, y, 2] * 0.299f);

        //                //算術平均法
        //                //int gray = (rgbData[x, y, 0] + rgbData[x, y, 1] + rgbData[x, y, 2]) / 3;

        //                bimage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
        //            }
        //        }
        //        // Step 3: 更新顯示影像 
        //        //image = bimage; this.Refresh();
        //        Bitmap b = new Bitmap(bimage, oi.Position.Width, oi.Position.Height);//轉換圖到固定大小
        //        g.DrawImageUnscaled(b, oi.Position.X, oi.Position.Y);
        //        return g;
        //    }
        //    catch { return null; }
        //}

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern bool BitBlt(
            IntPtr pHdc, int iX,
            int iY, int nWidth,
            int nHeight, IntPtr pSrcDC,
            int xSrc, int ySrc,
            Int32 dwRop
            );
    }
}