using System;
using System.Security.Cryptography;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

namespace Ecom_API.Service.Interfaces;

public interface IUserService
{
    AuthenticateRes Authenticate(AuthenticateReq model);
    IEnumerable<User> GetAll();
    User GetById(Guid id);
    void Register(UserRegisterReq model);
    void Update(Guid uid,UserUpdateReq model);
    void Delete(Guid id);
}

