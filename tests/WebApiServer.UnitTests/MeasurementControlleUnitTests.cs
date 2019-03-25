using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiServer.Controllers;
using WebApiServer.Models;
using Xunit;

namespace WebApiServer.UnitTests
{
    public class MeasurementControlleUnitTests
    {
        [Fact]
        public async Task get_all_measurements()
        {
            // Arrange 
            var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(get_all_measurements));
            var controller = new MeasurementController(repository);

            // Act
            var response = await controller.GetAll() as ObjectResult;
            var measurements = response.Value as List<Measurement>;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(5, measurements.Count);
        }

        [Fact]
        public async Task get_measurement_with_existing_id()
        {
            // Arrange 
            var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(get_measurement_with_existing_id));
            var controller = new MeasurementController(repository);
            var expectedValue = 0.25m;

            // Act
            var response = await controller.Get(1) as ObjectResult;
            var measurement = response.Value as Measurement;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedValue, measurement.Value);
        }

        [Fact]
        public async Task get_measurement_with_not_existing_id()
        {
            // Arrange 
            var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(get_measurement_with_not_existing_id));
            var controller = new MeasurementController(repository);
            var expectedMessage = "The Measurement record couldn't be found.";

            // Act
            var response = await controller.Get(10) as ObjectResult;

            // Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Equal(expectedMessage, response.Value);
        }

        [Fact]
        public async Task add_new_measurement()
        {
            // Arrange 
            var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(add_new_measurement));
            var controller = new MeasurementController(repository);
            var expectedMeasurementValue = 99.99m;

            var newMeasurement = new Measurement
            {
                Id = 11,
                Name = "New Measurement 11",
                Value = 99.99m,
                CreatedBy = "New Operator",
                CreatedAt = Convert.ToDateTime("2099/01/01 01:00:00 PM")
            };

            // Act
            var response = await controller.Post(newMeasurement) as ObjectResult;
            var measurement = response.Value as Measurement;

            // Assert
            Assert.Equal(201, response.StatusCode);
            Assert.Equal(expectedMeasurementValue, measurement.Value);
        }
    }
}
