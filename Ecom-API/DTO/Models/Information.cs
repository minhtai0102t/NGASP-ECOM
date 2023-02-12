using System;
namespace Ecom_API.DTO.Models
{
    public class Information : BaseEntity
    {
        public Guid uuid;
        public string fullname { get; set; }
        public string phone { get; set; }
    }
}

