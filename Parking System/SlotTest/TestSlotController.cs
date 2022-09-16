using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ParkingSlots.Controllers;
using ParkingSlots.Models;
using ParkingSlots.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlotTest
{
    [TestFixture]
    class TestSlotController
    {
        private Mock<ISlotRepository<Slot>> mockDataRepository;
        private SlotController _slotController;

        [SetUp]
        public void Setup()
        {
            mockDataRepository = new Mock<ISlotRepository<Slot>>();
            _slotController = new SlotController(mockDataRepository.Object);
        }

        [Test]
        public void Test_GetAll_ReturnsList_whenSlotIsPresent()
        {
            IEnumerable<Slot> slot = new List<Slot>();
            mockDataRepository.Setup(x => x.GetAll()).Returns(slot);

            // Act
            var result = _slotController.GetAll();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Test_GetAll_Returns_EmptyList_whenSlotIsNotPresent()
        {
            IEnumerable<Slot> slot = new List<Slot>();
            mockDataRepository.Setup(x => x.GetAll()).Returns(slot);

            // Act
            var result = _slotController.GetAll();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Test_GetById_Returns_Slot_whenSlotIsPresent()
        {
            Slot slot = new Slot()
            {
                SlotID = 1,
                Floor = "Ground",
                IsParked = true,
            };
            mockDataRepository.Setup(x => x.Get(1)).Returns(slot);

            // Act
            var result = _slotController.GetSlot(1);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }


        [Test]
        public void Test_GetById_Returns_NotFound_whenSlotIsNotPresent()
        {
            Slot slot = null;
            
            mockDataRepository.Setup(x => x.Get(1)).Returns(slot);

            // Act
            var result = _slotController.GetSlot(1);
            var notFoundResult = result as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        [Test]
        public void Test_Add_Returns_Ok_ForValidSlot()
        {
            Slot slot = new Slot()
            {
                SlotID = 1,
                Floor = "Ground",
                IsParked = true,
                Type = new SlotType()
            };

            mockDataRepository.Setup(x => x.Add(slot));

            // Act
            var result = _slotController.Post(slot);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Test_Add_Returns_BadRequest_ForInValidSlot()
        {
            Slot slot = null;

            // Act
            var result = _slotController.Post(slot);
            var badRequest = result as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(badRequest);
            Assert.AreEqual(400, badRequest.StatusCode);
        }

        [Test]
        public void Test_Delete_Returns_NotFound_SlotIsNotPresentt()
        {
            Slot slot = null;
            mockDataRepository.Setup(x => x.Get(1)).Returns(slot);
            //mockDataRepository.Setup(x => x.Delete(slot));

            // Act
            var result = _slotController.Delete(1);
            var badRequest = result as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(badRequest);
            Assert.AreEqual(404, badRequest.StatusCode);
        }

        [Test]
        public void Test_Delete_Returns_Ok_SlotIsPresent()
        {
            Slot slot = new Slot();
            mockDataRepository.Setup(x => x.Get(1)).Returns(slot);
            // Act
            var result = _slotController.Delete(1);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
