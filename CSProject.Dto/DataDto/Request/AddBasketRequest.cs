using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject.Dto.DataDto.Request
{
    public class AddBasketRequest
    {
        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

    }
}
