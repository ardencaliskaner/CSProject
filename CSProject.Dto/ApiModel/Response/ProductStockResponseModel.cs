using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject.Dto.ApiModel.Response
{
    public class ProductStockResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }
    }
}
