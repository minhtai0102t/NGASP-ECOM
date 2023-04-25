using AutoMapper;
using Ecom_API.Authorization;
using Ecom_API.DBHelpers;
using Ecom_API.DTO.Entities;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Isopoh.Cryptography.Argon2;
using Services.Repositories;

namespace Ecom_API.Service
{
    public class UserService : IUserService
    {
        private ApiDbContext _context;
        private IUnitOfWork _unitOfWork;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            ApiDbContext context,
            IJwtUtils jwtUtils,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }
        public AuthenticateRes Authenticate(AuthenticateReq model)
        {
            var user = _context.Users.SingleOrDefault(x => x.user_name == model.Username);

            // validate
            if (user == null || !Argon2.Verify(model.Password, user.password))
                throw new AppException("Username or password is incorrect");

            // authentication successful
            var response = _mapper.Map<AuthenticateRes>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Register(UserRegisterReq model)
        {
            // validate
            if (_context.Users.Any(x => x.user_name == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.password = Argon2.Hash(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UserUpdateReq model)
        {
            var user = getUser(id);

            // validate
            if (model.Username != user.user_name && _context.Users.Any(x => x.user_name == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.password = Argon2.Hash(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // helper methods
        private User getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}

