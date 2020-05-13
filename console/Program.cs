using System;
using System.Drawing;
using Tesseract;

namespace Learn_Tesseract_ocr
{
    class Program
    {
        static void Main(string[] args)
        {
            var ocr = new TesseractEngine(@"./tessdata", "chi_sim", EngineMode.Default);    //使用chi_sim中文语言包做测试
            var img = Pix.LoadFromFile(@"./tessdata/01.png");    //需要识别的图片
            var page = ocr.Process(img);
            Console.Write(page.GetText());
            Console.ReadKey();
        }
    }
}
