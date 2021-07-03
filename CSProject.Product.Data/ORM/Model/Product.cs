namespace CSProject.Product.Data.ORM.Model
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
    }

}
