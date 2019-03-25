using Microsoft.EntityFrameworkCore;
using WebApiServer.Database;
using WebApiServer.Models;
using WebApiServer.Repository;

namespace WebApiServer.UnitTests
{
    public static class MeasurementContextMocker
    {
        public static IMeasurementRepository<Measurement> GetInMemoryMeasurementsRepository(string dbName)
        {
            var options = new DbContextOptionsBuilder<MeasurementContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            MeasurementContext measurementContext = new MeasurementContext(options);
            measurementContext.FillDatabase();

            return new MeasurementRepository(measurementContext);
        }
    }
}
