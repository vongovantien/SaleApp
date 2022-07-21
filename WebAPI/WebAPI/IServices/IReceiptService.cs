using WebAPI.ViewModel;

namespace WebAPI.IServices
{
    public interface IReceiptService
    {
        public Task<List<ReceiptViewModel>> GetAllReceiptAsync();
        public Task<ReceiptViewModel> AddNewReceiptAsync(ReceiptViewModel model);
        public Task<ReceiptViewModel> GetReceiptByIDAsync(int ID);
        public Task<ReceiptViewModel> UpdateReceiptAsync(int ID, ReceiptViewModel model);
        public Task<bool> DeleteReceiptAsync(int ID);
    }
}
