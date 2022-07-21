using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IServices;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _productService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet("GetAllComment")]
        public async Task<IActionResult> GetAllCommentAsync()
        {
            try
            {
                var items = await _productService.GetAllCommentAsync();
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
        [HttpGet("GetCommentByID/{ID}")]
        public async Task<IActionResult> GetCommentByIDAsync(int ID)
        {
            try
            {
                var items = await _productService.GetCommentByIDAsync(ID);
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
        [HttpPost("AddNewComment")]
        public async Task<IActionResult> AddNewCommentAsync(CommentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                }
                var items = await _productService.AddNewCommentAsync(model);
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
        [HttpPut("UpdateComment/{ID}")]
        public async Task<IActionResult> UpdateCommentAsync(int ID, CommentViewModel model)
        {
            try
            {
                var items = await _productService.UpdateCommentAsync(ID, model);
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
        [HttpDelete("DeleteComment/{ID}")]
        public async Task<IActionResult> DeleteCommentAsync(int ID)
        {
            try
            {
                await _productService.DeleteCommentAsync(ID);
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
