using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MV.Prometric.DomainServices;
using MV.Prometric.EntityModels;
using MV.Prometric.IRepositories;

namespace MV.Prometric.Tests.DomainServices
{
    [TestClass]
    public class VehicleServiceTest
    {

        [TestInitialize]
        public void InitializeTest()
        {
        }

        [TestCleanup]
        public void ClearTest()
        {

        }

        [TestMethod]
        public void GetVehicles_Should_ReturnsRecords()
        {
            //Arrange
            var repository = new Mock<IVehicleReposistory>();
            repository.Setup(u => u.GetAll()).Returns(new List<Vehicle> { new Vehicle { }, new Vehicle { } });
            int expected = 2;
            //Act
            var domainService = new VehicleService(repository.Object);
            var vehicles = domainService.GetAll();
            //Assert
            Assert.AreEqual(expected, vehicles.Count());
        }

        [TestMethod]
        public void GetVehicles_Should_NoRecords()
        {
            //Arrange
            var repository = new Mock<IVehicleReposistory>();
            repository.Setup(u => u.GetAll()).Returns(new List<Vehicle> {  });
            int expected = 0;
            //Act
            var domainService = new VehicleService(repository.Object);
            var vehicles = domainService.GetAll();
            //Assert
            Assert.AreEqual(expected, vehicles.Count());
        }
    }
}
