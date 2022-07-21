using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IServices;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _productService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            try
            {
                var items = await _productService.GetAllCategoryAsync();
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
        [HttpGet("GetCategoryByID/{ID}")]
        public async Task<IActionResult> GetCategoryByIDAsync(int ID)
        {
            try
            {
                var items = await _productService.GetCategoryByIDAsync(ID);
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
        [HttpPost("AddNewCategory")]
        public async Task<IActionResult> AddNewCategoryAsync(CategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                }
                var items = await _productService.AddNewCategoryAsync(model);
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
        [HttpPut("UpdateCategory/{ID}")]
        public async Task<IActionResult> UpdateCategoryAsync(int ID, CategoryViewModel model)
        {
            try
            {
                var items = await _productService.UpdateCategoryAsync(ID, model);
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
        [HttpDelete("DeleteCategory/{ID}")]
        public async Task<IActionResult> DeleteCategoryAsync(int ID)
        {
            try
            {
                await _productService.DeleteCategoryAsync(ID);
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
