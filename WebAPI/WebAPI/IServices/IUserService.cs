using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.IServices
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        public Task<List<UserViewModel>> GetAllUserAsync();
        public Task<UserViewModel> AddNewUserAsync(UserViewModel model);
        public Task<UserViewModel> GetUserByIDAsync(int ID);
        public Task<UserViewModel> UpdateUserAsync(int ID, UserViewModel model);
        public Task<bool> DeleteUserAsync(int ID);
    }
}
