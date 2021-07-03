using CSProject.Dto.Base;

namespace CSProject.Dto.DataDto
{
    public class ProductDto : BaseDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
    }
}
