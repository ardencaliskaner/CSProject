using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CSProject.Basket.Services.ApiService
{
    public class BaseApiService<TInput, TOutput>
        where TInput : class, new()
        where TOutput : class, new()
    {
        public async Task<ApiResponse<TOutput>> GetDataFromApi(TInput reqModel, string url)
        {
            using (var client = new HttpClient { BaseAddress = new Uri("http://csproject.product.api:80/") })
            {
                var tokenModel = await GetToken();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenModel.Token}");

                string strContent = JsonConvert.SerializeObject(reqModel);

                HttpContent httpContent = new StringContent(strContent);

                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpRequestMessage message = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url, UriKind.Relative),
                    Content = httpContent
                };

                HttpResponseMessage response = await client.SendAsync(message);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                ApiResponse<TOutput> baseResponse = JsonConvert.DeserializeObject<ApiResponse<TOutput>>(content);

                return baseResponse;
            }
        }


        private async Task<TokenResponseModel> GetToken()
        {
            using (var client = new HttpClient { BaseAddress = new Uri("http://csproject.auth:80/") })
            {

                var tokenRequest = new TokenRequestModel
                {
                    UserName = "Arden",
                    Jobtitle = "Developer"
                };

                string url = "api/Token/GenerateToken";

                string strContent = JsonConvert.SerializeObject(tokenRequest);

                HttpContent httpContent = new StringContent(strContent);

                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpRequestMessage message = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url, UriKind.Relative),
                    Content = httpContent
                };

                HttpResponseMessage response = await client.SendAsync(message);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                TokenResponseModel tokenResponse = JsonConvert.DeserializeObject<TokenResponseModel>(content);

                return tokenResponse;
            }
        }
    }
}
