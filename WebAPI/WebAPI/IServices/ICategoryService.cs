using WebAPI.ViewModel;

namespace WebAPI.IServices
{
    public interface ICategoryService
    {
        public Task<List<CategoryViewModel>> GetAllCategoryAsync();
        public Task<CategoryViewModel> AddNewCategoryAsync(CategoryViewModel model);
        public Task<CategoryViewModel> GetCategoryByIDAsync(int ID);
        public Task<CategoryViewModel> UpdateCategoryAsync(int ID, CategoryViewModel model);
        public Task<bool> DeleteCategoryAsync(int ID);
    }
}
