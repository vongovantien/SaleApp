using WebAPI.ViewModel;

namespace WebAPI.IServices
{
    public interface IProductService
    {
        public Task<List<ProductViewModel>> GetAllProductAsync();
        public Task<ProductViewModel> AddNewProductAsync(ProductViewModel model);
        public Task<ProductViewModel> GetProductByIDAsync(int ID);
        public Task<ProductViewModel> UpdateProductAsync(int ID, ProductViewModel model);
        public Task<bool> DeleteProductAsync(int ID);

    }
}
