using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.IServices;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly saledbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(saledbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            var data = await _context.Category.OrderByDescending(s => s.Name).ToListAsync();
            return _mapper.Map<List<CategoryViewModel>>(data);
        }

        public async Task<CategoryViewModel> GetCategoryByIDAsync(int ID)
        {
            var data = await _context.Category.Where(s => s.Id == ID).FirstOrDefaultAsync();
            return _mapper.Map<CategoryViewModel>(data);
        }

        public async Task<bool> DeleteCategoryAsync(int ID)
        {
            try
            {
                Category existingItem = await _context.Category.Where(c => c.Id == ID).FirstOrDefaultAsync();
                _context.Category.Remove(existingItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<CategoryViewModel> UpdateCategoryAsync(int ID, CategoryViewModel model)
        {
            try
            {
                _mapper.Map<Category>(model);
                Category existingItem = await _context.Category.Where(s => s.Id == ID).FirstOrDefaultAsync();
                //model.modified_by = SessionHelper.currentUser.id;
                //model.modified_at = DateTime.Now.ToUniversalTime();
                await _context.SaveChangesAsync();
                return _mapper.Map<CategoryViewModel>(existingItem);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CategoryViewModel> AddNewCategoryAsync(CategoryViewModel model)
        {
            try
            {
                var data = _mapper.Map<Category>(model);
                //model.created_by = SessionHelper.currentUser.id;
                //model.created_at = DateTime.Now.ToUniversalTime();
                _context.Category.Add(data);
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
