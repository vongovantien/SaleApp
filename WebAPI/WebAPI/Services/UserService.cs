using AutoMapper;
using WebAPI.Helpers;
using WebAPI.IServices;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        public IConfiguration _configuration;
        private saledbContext _context;
        private readonly IMapper _mapper;

        public UserService(saledbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.User.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = TokenHelper.GenerateAccessToken(user.Id);

            return new AuthenticateResponse(user, token.Result);
        }

        public Task<List<UserViewModel>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> AddNewUserAsync(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> GetUserByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> UpdateUserAsync(int ID, UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
