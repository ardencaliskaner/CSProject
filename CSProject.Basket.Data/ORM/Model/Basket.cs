using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSProject.Basket.Data.ORM.Model
{
    public class Basket : BaseEntity
    {
        [Column(Order = 1)]
        public int ClientId { get; set; }
    }

}
