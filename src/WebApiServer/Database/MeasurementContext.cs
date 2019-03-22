using Microsoft.EntityFrameworkCore;
using WebApiServer.Models;

namespace WebApiServer.Database
{
    public class MeasurementContext : DbContext
    {
        public MeasurementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Measurement> Measurements { get; set; }
    }
}
