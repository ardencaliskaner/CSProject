namespace CSProject.Dto.ApiModel.Response
{
    public class BasketProductResponseModel
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public int BasketQuantity { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }


    }
}
