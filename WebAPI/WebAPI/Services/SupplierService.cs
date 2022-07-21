using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.IServices;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly saledbContext _context;
        private readonly IMapper _mapper;

        public SupplierService(saledbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SupplierViewModel>> GetAllSupplierAsync()
        {
            var data = await _context.Supplier.OrderByDescending(s => s.Id).ToListAsync();
            return _mapper.Map<List<SupplierViewModel>>(data);
        }

        public async Task<SupplierViewModel> GetSupplierByIDAsync(int ID)
        {
            var data = await _context.Supplier.Where(s => s.Id == ID).FirstOrDefaultAsync();
            return _mapper.Map<SupplierViewModel>(data);
        }

        public async Task<bool> DeleteSupplierAsync(int ID)
        {
            try
            {
                Supplier existingItem = await _context.Supplier.Where(c => c.Id == ID).FirstOrDefaultAsync();
                _context.Supplier.Remove(existingItem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<SupplierViewModel> UpdateSupplierAsync(int ID, SupplierViewModel model)
        {
            try
            {
                _mapper.Map<Supplier>(model);
                Supplier existingItem = await _context.Supplier.Where(s => s.Id == ID).FirstOrDefaultAsync();
                //model.modified_by = SessionHelper.currentUser.id;
                //model.modified_at = DateTime.Now.ToUniversalTime();
                await _context.SaveChangesAsync();
                return _mapper.Map<SupplierViewModel>(existingItem);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SupplierViewModel> AddNewSupplierAsync(SupplierViewModel model)
        {
            try
            {
                var data = _mapper.Map<Supplier>(model);
                //model.created_by = SessionHelper.currentUser.id;
                //model.created_at = DateTime.Now.ToUniversalTime();
                _context.Supplier.Add(data);
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
