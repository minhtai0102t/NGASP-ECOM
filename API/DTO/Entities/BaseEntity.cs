using System;
namespace Ecom_API.DTO.Entities
{
    public abstract class BaseEntity
    {
        public Guid id { get; set; }
        public DateTime created_date { get; set; }
        public int created_user { get; set; }
        public DateTime updated_date { get; set; }
        public int updated_user { get; set; }
        public bool is_deleted { get; set; }
    }

}

