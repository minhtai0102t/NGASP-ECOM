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
        public async Task<AuthenticateRes> Authenticate(AuthenticateReq model)
        {
            try
            {
                var user = await _unitOfWork.Users.FindWithCondition(c => c.username == model.username);
                // validate
                if (user == null || !Argon2.Verify(model.password, user.password))
                    throw new AppException("username or password is incorrect");

                // authentication successful
                var response = _mapper.Map<AuthenticateRes>(user);
                response.Token = _jwtUtils.GenerateToken(user);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public async Task<bool> Register(UserRegisterReq model)
        {
                var validate = await _unitOfWork.Users.FindWithCondition(c => c.username == model.username);
                if (validate != null)
                    throw new AppException("username '" + model.username + "' is already taken");

                // map model to new user object
                var user = _mapper.Map<User>(model);

                // hash password
                user.password = Argon2.Hash(model.password);

                // save user
                _context.Users.Add(user);
            var effectedRow = _context.SaveChanges();

                return effectedRow >= 1 ? true : false;
        }

        public void Update(int id, UserUpdateReq model)
        {
            var user = getUser(id);

            // validate
            if (model.username != user.username && _context.Users.Any(x => x.username == model.username))
                throw new AppException("username '" + model.username + "' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.password))
                user.password = Argon2.Hash(model.password);

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

