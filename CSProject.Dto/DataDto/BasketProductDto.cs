using CSProject.Dto.Base;

namespace CSProject.Dto.DataDto
{
    public class BasketProductDto : BaseDto
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
