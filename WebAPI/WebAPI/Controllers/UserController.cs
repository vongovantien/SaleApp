using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IServices;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _productService;
        private readonly IMapper _mapper;
        public UserController(IUserService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                var items = await _productService.GetAllUserAsync();
                return new JsonResult(new
                {
                    success = true,
                    data = items,
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Unexpected Error" });
            }
        }
        [HttpGet("GetUserByID/{ID}")]
        public async Task<IActionResult> GetUserByIDAsync(int ID)
        {
            try
            {
                var items = await _productService.GetUserByIDAsync(ID);
                return new JsonResult(new
                {
                    success = true,
                    data = items,
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Unexpected Error" });
            }
        }
        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUserAsync(UserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                }
                var items = await _productService.AddNewUserAsync(model);
                return new JsonResult(new
                {
                    success = true,
                    data = items,
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Unexpected Error" });
            }
        }
        [HttpPut("UpdateUser/{ID}")]
        public async Task<IActionResult> UpdateUserAsync(int ID, UserViewModel model)
        {
            try
            {
                var items = await _productService.UpdateUserAsync(ID, model);
                return new JsonResult(new
                {
                    success = true,
                    data = items,
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Unexpected Error" });
            }
        }
        [HttpDelete("DeleteUser/{ID}")]
        public async Task<IActionResult> DeleteUserAsync(int ID)
        {
            try
            {
                await _productService.DeleteUserAsync(ID);
                return new JsonResult(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Unexpected Error" });
            }
        }
    }
}
