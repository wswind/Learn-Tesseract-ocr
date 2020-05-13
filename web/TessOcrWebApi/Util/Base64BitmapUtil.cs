using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace TessOcrWebApi.Util
{
    public static class Base64BitmapUtil
    {
        public static string SaveLocal(string imgBase64)
        {
            string rootDirectory = AppContext.BaseDirectory;
            byte[] bt = Convert.FromBase64String(imgBase64);

            System.IO.MemoryStream stream = new System.IO.MemoryStream(bt);
            Bitmap bitmap = new Bitmap(stream);
            string filePath = $"{rootDirectory}{Guid.NewGuid()}.png";
            bitmap.Save(filePath, ImageFormat.Png);
            return filePath;
        }

		public static string ImgToBase64String(string Imagefilename)
		{
			Bitmap bmp = new Bitmap(Imagefilename);
			MemoryStream ms = new MemoryStream();
			bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
			byte[] arr = new byte[ms.Length];
			ms.Position = 0;
			ms.Read(arr, 0, (int)ms.Length);
			ms.Close();
			return Convert.ToBase64String(arr);
		}
    }
}
