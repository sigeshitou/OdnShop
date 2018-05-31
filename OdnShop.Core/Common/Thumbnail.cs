using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.IO;
using System.Drawing.Imaging;

namespace OdnShop.Core.Common
{
    /// <summary>
    /// 生成缩略图类
    /// </summary>
    public class Thumbnail
    {
        private string _orgPath;
        private string _newPath;
        private double _width;
        private double _height;
        private double _orgWidth;
        private double _orgHeight;
        private double _priority = 1; //默认宽度优先
        private Image image;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Thumbnail()
        {
            this.Priority = 1;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="orgpath">图片原始路径</param>
        public Thumbnail(string orgpath)
        {
            this.OrgPath = orgpath;
            this.Priority = 1;
            setWH();
        }
        public Thumbnail(Image image)
        {
            this.image = image;
            this.Priority = 1;
            this.OrgWidth = image.Width;
            this.OrgHeight = image.Height;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="orgpath">原始路径</param>
        /// <param name="newpath">新路径</param>
        /// <param name="orgwidth">原始宽度</param>
        /// <param name="newwidth">新宽度</param>
        /// <param name="orgheight">原始高度</param>
        /// <param name="newheight">新高度</param>
        /// <param name="priority">宽度优先或高度优先</param>
        public Thumbnail(string orgpath, string newpath, int orgwidth, int newwidth, int orgheight, int newheight, int priority)
        {
            this.OrgPath = orgpath;
            this.NewPath = newpath;
            this.OrgWidth = orgwidth;
            this.Width = newwidth;
            this.OrgHeight = orgheight;
            this.Height = newheight;
            this.Priority = priority;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="orgpath">原始路径</param>
        /// <param name="newpath">新路径</param>
        /// <param name="newwidth">新宽度</param>
        /// <param name="newheight">新高度</param>
        /// <param name="priority">宽度优先或高度优先</param>
        public Thumbnail(string orgpath, string newpath, int newwidth, int newheight, int priority)
        {
            this.OrgPath = orgpath;
            this.NewPath = newpath;

            this.setWH(); //设置原始宽高

            this.Width = newwidth;
            this.Height = newheight;
            this.Priority = priority;
        }

        /// <summary>
        /// 原始路径
        /// </summary>
        public string OrgPath
        {
            get
            {
                return _orgPath;
            }
            set
            {
                _orgPath = value;
            }
        }
        /// <summary>
        /// 新路径
        /// </summary>
        public string NewPath
        {
            get
            {
                return _newPath;
            }
            set
            {
                _newPath = value;
            }
        }
        /// <summary>
        /// 要生成的缩略路宽度
        /// </summary>
        public int Width
        {
            set
            {
                _width = value;
            }
        }
        /// <summary>
        /// 要生成的缩略图的高度
        /// </summary>
        public int Height
        {
            set
            {
                _height = value;
            }
        }
        /// <summary>
        /// 原始宽度
        /// </summary>
        public int OrgWidth
        {
            set
            {
                _orgWidth = value;
            }
        }
        /// <summary>
        /// 原始高度
        /// </summary>
        public int OrgHeight
        {
            set
            {
                _orgHeight = value;
            }
        }
        /// <summary>
        /// 宽度优先或者高路优先,1为宽度优先,0为高度优先
        /// </summary>
        public int Priority
        {
            set
            {
                _priority = value;
            }
        }
        /// <summary>
        /// 产生缩略图片
        /// </summary>
        public void Make()
        {
            if (!string.IsNullOrEmpty(_orgPath))
            {
                image = Image.FromFile(_orgPath);
            }
            double w = _width;
            double h = _height;
            if (_priority == 1)
            {
                h = (_width / _orgWidth) * _orgHeight;
            }
            else
            {
                w = (_height / _orgHeight) * _orgWidth;
            }
            if (image.Width > w)
            {
                CreateThumbnail(_newPath, w, h);
            }
            else
            {
                image.Save(_newPath);
            }

            image.Dispose(); //added by kwklover 2010/8/25
        }
        /// <summary>
        /// 建立缩略图
        /// </summary>
        /// <param name="sFileDstPath">目标路径</param>
        /// <param name="LimitW">限制宽</param>
        /// <param name="LimitH">限制高</param>
        private void CreateThumbnail(string sFileDstPath, double LimitW, double LimitH)
        {
            if (this.image != null)
            {
                System.Drawing.Image image = this.image as System.Drawing.Bitmap;
                byte[] data;
                ImageCodecInfo myImageCodecInfo;
                System.Drawing.Imaging.Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;
                myImageCodecInfo = ImageCodecInfo.GetImageEncoders()[0];
                myEncoder = System.Drawing.Imaging.Encoder.Quality;
                myEncoderParameters = new EncoderParameters(1);
                myEncoderParameter = new EncoderParameter(myEncoder, 10L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                MemoryStream ms = new MemoryStream();
                image.Save(ms, myImageCodecInfo, myEncoderParameters);
                CreateThumbnail(ms.ToArray(), out data, LimitW, LimitH);
                image = System.Drawing.Image.FromStream(new MemoryStream(data)) as System.Drawing.Bitmap;
                image.Save(sFileDstPath);
            }
        }
        /// <summary>
        /// 生成缩略图纯数据
        /// </summary>
        /// <param name="data1">数据1</param>
        /// <param name="data2">数据2</param>
        /// <param name="LimitW">限宽</param>
        /// <param name="LimitH">限高</param>
        static public void CreateThumbnail(byte[] data1, out byte[] data2, double LimitW, double LimitH)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(data1)) as System.Drawing.Bitmap;
            System.Drawing.SizeF size = new System.Drawing.SizeF(image.Width, image.Height);
            size.Width = (float)LimitW;
            size.Height = (float)LimitH;
            if (size.Height <= 0)
            {
                size.Height = image.Height * size.Width / image.Width;
            }
            if (size.Width <= 0)
            {
                size.Width = image.Width * size.Height / image.Height;
            }
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(Convert.ToInt16(size.Width), Convert.ToInt16(size.Height));
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.Clear(Color.Transparent);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            g.DrawImage(image, rect, new System.Drawing.Rectangle(0, 0, image.Width, image.Height), System.Drawing.GraphicsUnit.Pixel);
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            myImageCodecInfo = ImageCodecInfo.GetImageEncoders()[0];
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 0L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, myImageCodecInfo, myEncoderParameters);
            data2 = ms.ToArray();
            myEncoderParameter.Dispose();
            myEncoderParameters.Dispose();
            image.Dispose();
            bitmap.Dispose();
            g.Dispose();
            ms.Dispose();
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
        /// <summary>
        /// 根据图片路径获取图片大小并设置
        /// </summary>
        private void setWH()
        {
            Bitmap bitmap = new Bitmap(_orgPath);
            this.OrgWidth = bitmap.Width;
            this.OrgHeight = bitmap.Height;

            bitmap.Dispose();
        }

        #region 2012-10-30 新增图片裁剪方法
        /// <summary>
        /// 裁剪图片并保存
        /// </summary>
        /// <param name="fileName">源图路径（绝对路径）</param>
        /// <param name="newFileName">缩略图路径（绝对路径）</param>
        /// <param name="maxWidth">缩略图宽度</param>
        /// <param name="maxHeight">缩略图高度</param>
        /// <param name="cropWidth">裁剪宽度</param>
        /// <param name="cropHeight">裁剪高度</param>
        /// <param name="X">X轴</param>
        /// <param name="Y">Y轴</param>
        public static bool MakeThumbnailImage(string fileName, string newFileName, int maxWidth, int maxHeight, int cropWidth, int cropHeight, int X, int Y)
        {
            byte[] imageBytes = File.ReadAllBytes(fileName);
            Image originalImage = Image.FromStream(new System.IO.MemoryStream(imageBytes));
            Bitmap b = new Bitmap(cropWidth, cropHeight);
            try
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    //设置高质量插值法
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //设置高质量,低速度呈现平滑程度
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    //清空画布并以透明背景色填充
                    g.Clear(Color.Transparent);
                    //在指定位置并且按指定大小绘制原图片的指定部分
                    g.DrawImage(originalImage, new Rectangle(0, 0, cropWidth, cropHeight), X, Y, cropWidth, cropHeight, GraphicsUnit.Pixel);
                    Image displayImage = new Bitmap(b, maxWidth, maxHeight);
                    SaveImage(displayImage, newFileName, GetCodecInfo("image/" + GetFormat(newFileName).ToString().ToLower()));
                    return true;
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                b.Dispose();
            }
        }
        #endregion

        #region Helper

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image">Image 对象</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="ici">指定格式的编解码参数</param>
        private static void SaveImage(Image image, string savePath, ImageCodecInfo ici)
        {
            //设置 原图片 对象的 EncoderParameters 对象
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(Encoder.Quality, ((long)100));
            image.Save(savePath, ici, parameters);
            parameters.Dispose();
        }

        /// <summary>
        /// 获取图像编码解码器的所有相关信息
        /// </summary>
        /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
        /// <returns>返回图像编码解码器的所有相关信息</returns>
        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType)
                    return ici;
            }
            return null;
        }

        /// <summary>
        /// 计算新尺寸
        /// </summary>
        /// <param name="width">原始宽度</param>
        /// <param name="height">原始高度</param>
        /// <param name="maxWidth">最大新宽度</param>
        /// <param name="maxHeight">最大新高度</param>
        /// <returns></returns>
        private static Size ResizeImage(int width, int height, int maxWidth, int maxHeight)
        {
            //此次2012-02-05修改过=================
            if (maxWidth <= 0)
                maxWidth = width;
            if (maxHeight <= 0)
                maxHeight = height;
            //以上2012-02-05修改过=================
            decimal MAX_WIDTH = (decimal)maxWidth;
            decimal MAX_HEIGHT = (decimal)maxHeight;
            decimal ASPECT_RATIO = MAX_WIDTH / MAX_HEIGHT;

            int newWidth, newHeight;
            decimal originalWidth = (decimal)width;
            decimal originalHeight = (decimal)height;

            if (originalWidth > MAX_WIDTH || originalHeight > MAX_HEIGHT)
            {
                decimal factor;
                // determine the largest factor 
                if (originalWidth / originalHeight > ASPECT_RATIO)
                {
                    factor = originalWidth / MAX_WIDTH;
                    newWidth = Convert.ToInt32(originalWidth / factor);
                    newHeight = Convert.ToInt32(originalHeight / factor);
                }
                else
                {
                    factor = originalHeight / MAX_HEIGHT;
                    newWidth = Convert.ToInt32(originalWidth / factor);
                    newHeight = Convert.ToInt32(originalHeight / factor);
                }
            }
            else
            {
                newWidth = width;
                newHeight = height;
            }
            return new Size(newWidth, newHeight);
        }

        /// <summary>
        /// 得到图片格式
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <returns></returns>
        public static ImageFormat GetFormat(string name)
        {
            string ext = name.Substring(name.LastIndexOf(".") + 1);
            switch (ext.ToLower())
            {
                case "jpg":
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "bmp":
                    return ImageFormat.Bmp;
                case "png":
                    return ImageFormat.Png;
                case "gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Jpeg;
            }
        }
        #endregion
    }
}
