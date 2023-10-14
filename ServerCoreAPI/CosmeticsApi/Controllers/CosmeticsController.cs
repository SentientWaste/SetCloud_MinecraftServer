using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace CosmeticsApi.Controllers {
    [ApiController]
    [Route("api/cosmetics/info")]
    public class CosmeticsController : ControllerBase {
        public static readonly string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cosmetics", "data");

        public static readonly string ImagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cosmetics", "image");

        public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions() {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs)
        };

        [HttpPost]
        public bool Post([FromBody] CosmeticsData data) {

            var dataFile = Path.Combine(DataPath, $"{data.Name}.json");
            if (System.IO.File.Exists(dataFile)) {
                return false;
            }
            if (Directory.Exists("C:\\Users\\31231\\AppData\\Roaming\\cosmetics\\data")) //C:/Users/31231/AppData/Roaming/cosmetics/data
            {
                System.IO.File.WriteAllText(dataFile, JsonSerializer.Serialize(data, DefaultJsonSerializerOptions));
                return true;
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Users\\31231\\AppData\\Roaming\\cosmetics\\data");
                directoryInfo.Create();
                System.IO.File.WriteAllText(dataFile, JsonSerializer.Serialize(data, DefaultJsonSerializerOptions));
                return true;
            }
        }

        [HttpPut]
        public bool Put([FromBody] CosmeticsData data) {
            var dataFile = Path.Combine(DataPath, $"{data.Name}.json");
            if (!System.IO.File.Exists(dataFile)) {
                return false;
            }
            
            System.IO.File.WriteAllText(dataFile, JsonSerializer.Serialize(data, DefaultJsonSerializerOptions));
            return true;
        }

        [HttpGet]
        public IEnumerable<CosmeticsData> GetAll() {
            if (!Directory.Exists(DataPath) || !Directory.EnumerateFiles(DataPath).Any()) {
                return Array.Empty<CosmeticsData>();
            }

            return Directory.EnumerateFiles(DataPath).Select(x => 
            JsonSerializer.Deserialize<CosmeticsData>(System.IO.File.ReadAllText(x),DefaultJsonSerializerOptions))!;
        }
    }
}
