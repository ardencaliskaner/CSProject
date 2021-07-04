namespace CSProject.Basket.Data.ORM.Model
{
    public class BasketProduct : BaseEntity
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }

}
