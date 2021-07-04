using System;

namespace CSProject.Dto.ApiModel.Response
{
    public class BasketReponseModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}