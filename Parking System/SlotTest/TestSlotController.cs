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
    }
}
