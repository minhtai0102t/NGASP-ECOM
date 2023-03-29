using System;
using System.Text.Json.Serialization;

namespace Ecom_API.DTO.Entities
{
	public class User : BaseEntity
	{
        public int system_id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }

    }
}

