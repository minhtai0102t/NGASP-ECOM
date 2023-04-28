using System;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;

namespace Ecom_API.Service;

public interface IUserService
{
    Task<AuthenticateRes> Authenticate(AuthenticateReq model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    Task<bool> Register(UserRegisterReq model);
    void Update(int id, UserUpdateReq model);
    void Delete(int id);
}

