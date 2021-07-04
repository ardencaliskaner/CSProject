using System.ComponentModel.DataAnnotations.Schema;

namespace CSProject.Product.Data.ORM.Model
{
    public class Category : BaseEntity
    {
        [Column(Order = 1)]
        public string Name { get; set; }

        [Column(Order = 2)]
        public string Description { get; set; }
    }
}
