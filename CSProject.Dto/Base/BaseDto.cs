using System;

namespace CSProject.Dto.Base
{
    public class BaseDto
    {
        public int ID { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}