using System;

namespace CSProject.Basket.Data.ORM.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }

}
