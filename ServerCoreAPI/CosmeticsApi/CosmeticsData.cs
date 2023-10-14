using System.Text.Json.Serialization;

namespace CosmeticsApi {
    public class CosmeticsData {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("module")]
        public string Module { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("material")]
        public string Material { get; set; }

        [JsonPropertyName("netContent")]
        public string NetContent { get; set; }

        [JsonPropertyName("univalence")]
        public string Univalence { get; set; }

        [JsonPropertyName("supplierName")]
        public string SupplierName { get; set; }  
    }
}
