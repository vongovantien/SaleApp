using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.IServices;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly saledbContext _context;
        private readonly IMapper _mapper;

        public ReceiptService(saledbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ReceiptViewModel>> GetAllReceiptAsync()
        {
            var data = await _context.Receipt.OrderByDescending(s => s.Id).ToListAsync();
            return _mapper.Map<List<ReceiptViewModel>>(data);
        }

        public async Task<ReceiptViewModel> GetReceiptByIDAsync(int ID)
        {
            var data = await _context.Receipt.Where(s => s.Id == ID).FirstOrDefaultAsync();
            return _mapper.Map<ReceiptViewModel>(data);
        }

        public async Task<bool> DeleteReceiptAsync(int ID)
        {
            try
            {
                Receipt existingItem = await _context.Receipt.Where(c => c.Id == ID).FirstOrDefaultAsync();
                _context.Receipt.Remove(existingItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ReceiptViewModel> UpdateReceiptAsync(int ID, ReceiptViewModel model)
        {
            try
            {
                _mapper.Map<Receipt>(model);
                Receipt existingItem = await _context.Receipt.Where(s => s.Id == ID).FirstOrDefaultAsync();
                //model.modified_by = SessionHelper.currentUser.id;
                //model.modified_at = DateTime.Now.ToUniversalTime();
                await _context.SaveChangesAsync();
                return _mapper.Map<ReceiptViewModel>(existingItem);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ReceiptViewModel> AddNewReceiptAsync(ReceiptViewModel model)
        {
            try
            {
                var data = _mapper.Map<Receipt>(model);
                //model.created_by = SessionHelper.currentUser.id;
                //model.created_at = DateTime.Now.ToUniversalTime();
                _context.Receipt.Add(data);
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
