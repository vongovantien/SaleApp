using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IServices;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _productService;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }
        [HttpGet("GetAllSupplier")]
        public async Task<IActionResult> GetAllSupplierAsync()
        {
            try
            {
                var items = await _productService.GetAllSupplierAsync();
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
        [HttpGet("GetSupplierByID/{ID}")]
        public async Task<IActionResult> GetSupplierByIDAsync(int ID)
        {
            try
            {
                var items = await _productService.GetSupplierByIDAsync(ID);
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
        [HttpPost("AddNewSupplier")]
        public async Task<IActionResult> AddNewSupplierAsync(SupplierViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                }
                var items = await _productService.AddNewSupplierAsync(model);
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
        [HttpPut("UpdateSupplier/{ID}")]
        public async Task<IActionResult> UpdateSupplierAsync(int ID, SupplierViewModel model)
        {
            try
            {
                var items = await _productService.UpdateSupplierAsync(ID, model);
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
        [HttpDelete("DeleteSupplier/{ID}")]
        public async Task<IActionResult> DeleteSupplierAsync(int ID)
        {
            try
            {
                await _productService.DeleteSupplierAsync(ID);
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
