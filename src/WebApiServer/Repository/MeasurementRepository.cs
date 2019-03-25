using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiServer.Database;
using WebApiServer.Models;

namespace WebApiServer.Repository
{
    public class MeasurementRepository : IMeasurementRepository<Measurement>
    {
        private readonly MeasurementContext _measurementContext;

        public MeasurementRepository(MeasurementContext context)
        {
            _measurementContext = context;
        }


        public async Task<IEnumerable<Measurement>> GetAll()
        {
            return await _measurementContext.Measurements.ToListAsync();
        }

        public async Task<Measurement> Get(long id)
        {
            return await _measurementContext.Measurements.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Add(Measurement entity)
        {
            await _measurementContext.Measurements.AddAsync(entity);
            await _measurementContext.SaveChangesAsync();
        }

        public async Task Update(Measurement measurement, Measurement entity)
        {
            measurement.Name = entity.Name;
            measurement.Value = entity.Value;
            measurement.CreatedBy = entity.CreatedBy;
            measurement.CreatedAt = entity.CreatedAt;

            await _measurementContext.SaveChangesAsync();
        }

        public async Task Delete(Measurement measurement)
        {
            _measurementContext.Measurements.Remove(measurement);
            await _measurementContext.SaveChangesAsync();
        }
    }
}
