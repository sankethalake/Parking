using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Parking.Controllers;
using Parking.Models.Repositoy;
using System.Collections.Generic;

namespace ParkingTestProject
{
    [TestFixture]
    public class Tests
    {
        private Mock<IParkingRepository<Parking.Models.Parking>> mockDataRepository;
        private ParkingController _parkingController;
        [SetUp]
        public void Setup()
        {
            mockDataRepository = new Mock<IParkingRepository<Parking.Models.Parking>>();
            _parkingController = new ParkingController(mockDataRepository.Object);
        }

        [Test]
        public void Test_Get_ReturnsList_whenParkingIsPresent()
        {
            IEnumerable<Parking.Models.Parking> parking = new List<Parking.Models.Parking>();
            mockDataRepository.Setup(x => x.GetAllParking()).Returns(parking);

            // Act
            var result = _parkingController.Get();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Test_Add_Returns_okObject_forValidParking()
        {
            Parking.Models.Parking parking = new Parking.Models.Parking();
            mockDataRepository.Setup(x => x.AddParking(parking));

            // Act
            var result = _parkingController.Post(parking);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Test_Add_Returns_BadRequest_forInvalidParking()
        {
            Parking.Models.Parking parking = null;
            //mockDataRepository.Setup(x => x.AddParking(parking));

            // Act
            var result = _parkingController.Post(parking);
            var badRequest = result as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(badRequest);
            Assert.AreEqual(400, badRequest.StatusCode);
        }

        [Test]
        public void Test_put_Returns_okResult_forvalidParking()
        {
            Parking.Models.Parking parking = new Parking.Models.Parking()
            {
                Id = 1,
            };
            mockDataRepository.Setup(x => x.UpdateParking(parking, parking));
            mockDataRepository.Setup(x => x.Get(parking.Id)).Returns(parking);

            // Act
            var result = _parkingController.Put(parking);
            var okObject = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okObject);
            Assert.AreEqual(200, okObject.StatusCode);
        }

        [Test]
        public void Test_put_Returns_BadRequest_fornull()
        {
            Parking.Models.Parking parking = null;

            // Act
            var result = _parkingController.Put(parking);
            var badRequest = result as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(badRequest);
            Assert.AreEqual(400, badRequest.StatusCode);
        }
    }
}