using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject.Dto.ApiModel.Response
{
    public class ProductStockResponseModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Stock { get; set; }
    }
}
