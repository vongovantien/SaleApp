using WebAPI.ViewModel;

namespace WebAPI.IServices
{
    public interface ISupplierService
    {
        public Task<List<SupplierViewModel>> GetAllSupplierAsync();
        public Task<SupplierViewModel> AddNewSupplierAsync(SupplierViewModel model);
        public Task<SupplierViewModel> GetSupplierByIDAsync(int ID);
        public Task<SupplierViewModel> UpdateSupplierAsync(int ID, SupplierViewModel model);
        public Task<bool> DeleteSupplierAsync(int ID);
    }
}
