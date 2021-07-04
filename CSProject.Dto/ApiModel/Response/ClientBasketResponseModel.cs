using System.Collections.Generic;

namespace CSProject.Dto.ApiModel.Response
{
    public class ClientBasketResponseModel
    {
        public int ClientId { get; set; }

        public int BasketId { get; set; }

        public List<ProductResponseModel> Products { get; set; }
    }
}
