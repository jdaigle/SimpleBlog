using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;

namespace SimpleBlog.Web.Mvc
{
    public class ImageResult : FileContentResult
    {
        public ImageResult(Image image, ImageFormat imageFormat)
            :base(ToBytes(image, imageFormat), ToContentType(imageFormat))
        {
            Image = image;
            ImageFormat = imageFormat;
        }

        public Image Image { get; private set; }
        public ImageFormat ImageFormat { get; private set; }

        public static string ToContentType(ImageFormat imageFormat)
        {
            if (imageFormat.Equals(ImageFormat.Bmp)) return "image/bmp";
            if (imageFormat.Equals(ImageFormat.Gif)) return "image/gif";
            if (imageFormat.Equals(ImageFormat.Icon)) return "image/vnd.microsoft.icon";
            if (imageFormat.Equals(ImageFormat.Jpeg)) return "image/jpeg";
            if (imageFormat.Equals(ImageFormat.Png)) return "image/png";
            if (imageFormat.Equals(ImageFormat.Tiff)) return "image/tiff";
            if (imageFormat.Equals(ImageFormat.Wmf)) return "image/wmf";
            return "image/bmp";
        }

        public static byte[] ToBytes(Image image, ImageFormat imageFormat)
        {
            using (var byteStream = new MemoryStream())
            {
                image.Save(byteStream, ImageFormat.Png);
                var bytes = byteStream.ToArray();
                return bytes;
            }
        }
    }
}
