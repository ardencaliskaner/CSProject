using Newtonsoft.Json;

namespace CSProject.Dto.ApiModel.Request
{
    public class ProductStockRequestModel
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }
    }
}
