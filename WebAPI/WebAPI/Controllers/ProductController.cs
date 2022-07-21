using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.IServices;
using WebAPI.Services.Mail;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        public ProductController(IProductService productService, IMapper mapper, IMailService mailService)
        {
            _productService = productService;
            _mapper = mapper;
            _mailService = mailService;
        }
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            try
            {
                //var rng = new Random();
                //var message = new Message(new string[] { "codemazetest@mailinator.com" }, "Test email", "This is the content from our email.");
                //_mailService.SendEmail(message);
                //return Enumerable.Range(1, 5).Select(index => new CategoryViewModel
                //{
                //    Id = index,
                //    Name = "assas"
                //}).ToArray();
                var items = await _productService.GetAllProductAsync();
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
        [HttpGet("GetProductByID/{ID}")]
        public async Task<IActionResult> GetProductByIDAsync(int ID)
        {
            try
            {
                var items = await _productService.GetProductByIDAsync(ID);
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
        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> AddNewProductAsync(ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                }
                var items = await _productService.AddNewProductAsync(model);
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
        [HttpPut("UpdateProduct/{ID}")]
        public async Task<IActionResult> UpdateProductAsync(int ID, ProductViewModel model)
        {
            try
            {
                var items = await _productService.UpdateProductAsync(ID, model);
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
        [HttpDelete("DeleteProduct/{ID}")]
        public async Task<IActionResult> DeleteProductAsync(int ID)
        {
            try
            {
                await _productService.DeleteProductAsync(ID);
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
