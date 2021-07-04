using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSProject.Product.Data.ORM.Model
{
    public class BaseEntity
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }

}
