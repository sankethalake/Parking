using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using VehicleMicroservice.Controllers;
using VehicleMicroservice.Models;
using VehicleMicroservice.Models.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VehicleTest
{
    [TestFixture]
    class TestVehicle
    {
        private Mock<IVehicleRepository<Vehicle>> mockDataRepository;
        private VehicleController _vehicleController;

        [SetUp]
        public void Setup()
        {
            mockDataRepository = new Mock<IVehicleRepository<Vehicle>>();
            _vehicleController = new VehicleController(mockDataRepository.Object);
        }

        [Test]
        public void Test_GetAll_ReturnsList_whenVehicleIsPresent()
        {
            IEnumerable<Vehicle> vehicle = new List<Vehicle>();
            mockDataRepository.Setup(x => x.GetAll()).Returns(vehicle);

            // Act
            var result = _vehicleController.GetAll();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Test_GetAll_ReturnsList_whenVehicleIsNotPresent()
        {
            IEnumerable<Vehicle> vehicle = new List<Vehicle>();
            mockDataRepository.Setup(x => x.GetAll()).Returns(vehicle);

            // Act
            var result = _vehicleController.GetAll();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Test_Post_vehicle()
        {
            // Arrange
            Vehicle vehicle = new Vehicle()
            {
                VehicleNumber = "MH09FJ6656",
                Company = "SUZUKI",
                Model = "XL6",
                Type = VehicleType.Four_Wheeler
            };
            mockDataRepository.Setup(x => x.Add(vehicle));

            // Act
            var result = _vehicleController.Post(vehicle);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Test_GetByValidId()
        {
            // Arrange
            Vehicle vehicle = new Vehicle()
            {
                VehicleNumber = "MH09FJ6656",
                Company = "SUZUKI",
                Model = "XL6",
                Type = VehicleType.Four_Wheeler
            };
            string number = "MH09FJ6656";
            mockDataRepository.Setup(x => x.Get(number)).Returns(vehicle);

            // Act
            var result = _vehicleController.Get(number);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Test_GetByInValidId()
        {
            // Arrange
            Vehicle vehicle = new Vehicle();
            string number = "MH09F";
            //mockDataRepository.Setup(x => x.Get("number")).Returns(null);

            // Act
            var result = _vehicleController.Get(number);
            var BadResult = result as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(BadResult);
            Assert.AreEqual(404, BadResult.StatusCode);
        }

        [Test]
        public void Test_Delete_ValidVehicle()
        {

            // Arrange
            //string status = "pending";
            string vehicleNumber= "MH09FJ6655";
            Vehicle vehicle = new Vehicle();
            mockDataRepository.Setup(x => x.Get("MH09FJ6655")).Returns(vehicle);
            mockDataRepository.Setup(x => x.Delete(vehicle));

            // Act
            var result = _vehicleController.Delete(vehicleNumber);
            var okResult = result as NoContentResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.That(204, Is.EqualTo(okResult.StatusCode));
        }

        [Test]
        public void Test_Delete_InValidVehicle()
        {

            // Arrange
            //string status = "pending";
            string vehicleNumber = "MH09FJ6655";
            Vehicle vehicle = null;
            mockDataRepository.Setup(x => x.Get("MH09FJ6655")).Returns(vehicle);

            // Act
            var result = _vehicleController.Delete(vehicleNumber);
            var notFoundResult = result as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(notFoundResult);
            Assert.That(404, Is.EqualTo(notFoundResult.StatusCode));

        }
    }
}
