using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.IServices;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly saledbContext _context;
        private readonly IMapper _mapper;

        public ProductService(saledbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductViewModel>> GetAllProductAsync()
        {
            var data = await _context.Product.OrderByDescending(s => s.Name).ToListAsync();
            return _mapper.Map<List<ProductViewModel>>(data);
        }

        public async Task<ProductViewModel> GetProductByIDAsync(int ID)
        {
            var data = await _context.Product.Where(s => s.Id == ID).FirstOrDefaultAsync();
            return _mapper.Map<ProductViewModel>(data);
        }

        public async Task<bool> DeleteProductAsync(int ID)
        {
            try
            {
                Product existingItem = await _context.Product.Where(c => c.Id == ID).FirstOrDefaultAsync();
                _context.Product.Remove(existingItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductViewModel> UpdateProductAsync(int ID, ProductViewModel model)
        {
            try
            {
                _mapper.Map<Product>(model);
                Product existingItem = await _context.Product.Where(s => s.Id == ID).FirstOrDefaultAsync();
                //model.modified_by = SessionHelper.currentUser.id;
                //model.modified_at = DateTime.Now.ToUniversalTime();
                await _context.SaveChangesAsync();
                return _mapper.Map<ProductViewModel>(existingItem);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ProductViewModel> AddNewProductAsync(ProductViewModel model)
        {
            try
            {
                var data = _mapper.Map<Product>(model);
                //model.created_by = SessionHelper.currentUser.id;
                //model.created_at = DateTime.Now.ToUniversalTime();
                _context.Product.Add(data);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
