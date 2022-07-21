using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IServices;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _productService;
        private readonly IMapper _mapper;
        public TagController(ITagService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet("GetAllTag")]
        public async Task<IActionResult> GetAllTagAsync()
        {
            try
            {
                var items = await _productService.GetAllTagAsync();
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
        [HttpGet("GetTagByID/{ID}")]
        public async Task<IActionResult> GetTagByIDAsync(int ID)
        {
            try
            {
                var items = await _productService.GetTagByIDAsync(ID);
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
        [HttpPost("AddNewTag")]
        public async Task<IActionResult> AddNewTagAsync(TagViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                }
                var items = await _productService.AddNewTagAsync(model);
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
        [HttpPut("UpdateTag/{ID}")]
        public async Task<IActionResult> UpdateTagAsync(int ID, TagViewModel model)
        {
            try
            {
                var items = await _productService.UpdateTagAsync(ID, model);
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
        [HttpDelete("DeleteTag/{ID}")]
        public async Task<IActionResult> DeleteTagAsync(int ID)
        {
            try
            {
                await _productService.DeleteTagAsync(ID);
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
