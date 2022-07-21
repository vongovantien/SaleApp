using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IServices;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _productService;
        private readonly IMapper _mapper;
        public ReceiptController(IReceiptService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet("GetAllReceipt")]
        public async Task<IActionResult> GetAllReceiptAsync()
        {
            try
            {
                var items = await _productService.GetAllReceiptAsync();
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
        [HttpGet("GetReceiptByID/{ID}")]
        public async Task<IActionResult> GetReceiptByIDAsync(int ID)
        {
            try
            {
                var items = await _productService.GetReceiptByIDAsync(ID);
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
        [HttpPost("AddNewReceipt")]
        public async Task<IActionResult> AddNewReceiptAsync(ReceiptViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                }
                var items = await _productService.AddNewReceiptAsync(model);
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
        [HttpPut("UpdateReceipt/{ID}")]
        public async Task<IActionResult> UpdateReceiptAsync(int ID, ReceiptViewModel model)
        {
            try
            {
                var items = await _productService.UpdateReceiptAsync(ID, model);
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
        [HttpDelete("DeleteReceipt/{ID}")]
        public async Task<IActionResult> DeleteReceiptAsync(int ID)
        {
            try
            {
                await _productService.DeleteReceiptAsync(ID);
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
