using ConnectorResource.Api.DbContextw;
using ConnectorResource.Api.Enums;
using ConnectorResource.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectorResource.Api.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly ConnectorDBContext context;

        public MedicineService(ConnectorDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Medicine medicine)
        {
            try
            {
                var med = new Medicine()
                {
                    Id = new Guid().ToString(),
                    Name = medicine.Name,
                    Description = medicine.Description,
                    RecordState = RecordState.Active
                };

                await context.Medicines.AddAsync(med);
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(Medicine medicine)
        {
            try
            {
                var availableMedicine = await context.Medicines.FirstOrDefaultAsync(m => m.Id == medicine.Id);

                if(availableMedicine == null)
                {
                    throw new Exception("Record Not Found");
                }

                availableMedicine.Name = medicine.Name;
                availableMedicine.Description = medicine.Description;   
                availableMedicine.RecordState = RecordState.Active;
                

                context.Medicines.Update(availableMedicine);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string Id)
        {
            try
            {
                var availableMedicine = await context.Medicines.FirstOrDefaultAsync(m => m.Id == Id);

                if (availableMedicine == null)
                {
                    throw new Exception("Record Not Found");
                }

                context.Medicines.Remove(availableMedicine);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Medicine>> GetAllAsync()
        {
            try
            {
                return await context.Medicines.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Medicine> GetAsync(string Id)
        {
            try
            {
                return await context.Medicines.FirstOrDefaultAsync(m => m.Id == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
