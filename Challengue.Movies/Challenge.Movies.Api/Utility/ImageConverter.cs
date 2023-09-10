


using SixLabors.ImageSharp;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Challenge.Movies.Api.Utility
{
    public static class ImageConverter
    {
        

        public static byte[] ImageToByteArray(Image image)
        {
           
            using (var ms = new MemoryStream())
            {
                image.SaveAsJpeg(ms);
                return ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage = Image.Load(ms);

                return returnImage;
            }
        }

        public static byte[] FileImageToByteArray(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            
            using (var imageLoad = Image.Load(file.OpenReadStream()))
            {
                using (var ms = new MemoryStream())
                {
                    imageLoad.SaveAsJpeg(ms);
                    return ms.ToArray();
                }

            }
           
        }
    }
}
