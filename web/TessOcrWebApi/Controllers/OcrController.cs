using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using TessOcrWebApi.Contract;
using TessOcrWebApi.Util;

namespace TessOcrWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcrController : ControllerBase
    {
       
        public OcrController()
        {
          
        }
        ///// <summary>
        ///// 获得Post过来的数据  
        ///// </summary>
        ///// <returns></returns>
        //private async Task<string> GetPostStr(HttpRequest request)
        //{
        //    using (var sr = new StreamReader(request.Body, Encoding.UTF8))
        //    {
        //        var body = await sr.ReadToEndAsync();
        //        return body;
        //    }
        //}
        [HttpPost]
        public ActionResult Post([FromBody]ImgData imgData)
        {
            string rootDirectory = AppContext.BaseDirectory;

            string filePath = Base64BitmapUtil.SaveLocal(imgData.Base64);
           
            //string filePath = $"{rootDirectory}tessdata\\01.png";
            string tessDataPath = $"{rootDirectory}tessdata";
            using (var engine = new TesseractEngine(tessDataPath, "chi_sim", EngineMode.Default))
            {
                using (var pix = Pix.LoadFromFile(filePath))
                {
                    using (var page = engine.Process(pix))
                    {
                        string text = page.GetText();
                        return Ok(text);
                    }
                }
            }
        }
    }
}
