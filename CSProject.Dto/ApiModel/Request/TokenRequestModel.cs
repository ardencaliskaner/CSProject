using Newtonsoft.Json;

namespace CSProject.Dto.ApiModel.Request
{
    public class TokenRequestModel
    {
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Jobtitle")]
        public string Jobtitle { get; set; }
    }
}
