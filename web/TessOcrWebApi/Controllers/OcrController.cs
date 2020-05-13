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
        [HttpPost]
        public ActionResult Post([FromBody]ImgData imgData)
        {
            string rootDirectory = AppContext.BaseDirectory;
            string filePath = Base64BitmapUtil.SaveLocal(imgData.Base64);
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
