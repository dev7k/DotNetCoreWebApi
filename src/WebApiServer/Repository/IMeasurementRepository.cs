using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiServer.Models;

namespace WebApiServer.Repository
{
    public interface IMeasurementRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(Measurement measurement, TEntity entity);
        Task Delete(Measurement measurement);
    }
}
