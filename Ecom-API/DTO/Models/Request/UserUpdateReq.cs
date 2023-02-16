using System;
namespace Ecom_API.DTO.Models
{
	public class UserUpdateReq
	{
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

