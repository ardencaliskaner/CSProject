using Newtonsoft.Json;

namespace CSProject.Dto.ApiModel.Response
{
    public class TokenResponseModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
