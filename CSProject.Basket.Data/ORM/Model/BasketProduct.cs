using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSProject.Basket.Data.ORM.Model
{
    public class BasketProduct : BaseEntity
    {
        [Column(Order = 1)]
        public int BasketId { get; set; }

        [Column(Order = 2)]
        public int ProductId { get; set; }

        [Column(Order = 3)]
        public int Quantity { get; set; }
    }

}
