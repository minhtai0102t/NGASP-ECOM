namespace Ecom_API.DTO.Entities
{
    public class User : BaseEntity
	{
        public string user_name { get; set; }
        public string full_name { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    }
}

