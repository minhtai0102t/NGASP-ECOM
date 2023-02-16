using System;
namespace Ecom_API.DTO.Models;
using System.ComponentModel.DataAnnotations;

public class AuthenticateReq
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}