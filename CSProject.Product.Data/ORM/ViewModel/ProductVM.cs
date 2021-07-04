using System.ComponentModel.DataAnnotations.Schema;

namespace CSProject.Product.Data.ORM.Model
{
    public class ProductVM : BaseEntity
    {
        [Column(Order = 1)]
        public int CategoryId { get; set; }

        [Column(Order = 2)]
        public string Name { get; set; }

        [Column(Order = 3)]
        public int Stock { get; set; }

        [Column(Order = 4)]
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
