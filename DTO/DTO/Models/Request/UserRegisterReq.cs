using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom_API.DTO.Models;
public class UserRegisterReq
{
    [Required]
    public string FullName { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}

