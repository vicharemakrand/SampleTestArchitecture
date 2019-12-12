using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MV.Prometric.EntityModels;
using MV.Prometric.IRepositories;
using MV.Prometric.Repositories;

namespace MV.Prometric.Test.Repositories
{
    [TestClass]
    public class VehicleRepositoryTest
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
            var expected = 10;
            var dbContext = new Mock<TestDbEntities>();
            var dbSet = new Mock<DbSet<Vehicle>>();
            var vehicleList = FizzWare.NBuilder.Builder<Vehicle>.CreateListOfSize(expected).Build().AsQueryable(); ;
            dbSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(vehicleList.GetEnumerator());
            dbContext.Setup(x => x.Vehicles).Returns(dbSet.Object);

            //Act
            var repository = new VehicleRepository(dbContext.Object);

            var vehicles = repository.GetAll();
            //Assert
            Assert.AreEqual(expected, vehicleList.Count());
        }

        [TestMethod]
        public void SaveShouldReturnSavedId()
        {
            var expected = 10;
            var dbContext = new Mock<TestDbEntities>();
            var dbSet = new Mock<DbSet<Vehicle>>();
            var vehicleList = FizzWare.NBuilder.Builder<Vehicle>.CreateListOfSize(expected).Build().AsQueryable(); ;
            dbContext.Setup(x => x.Vehicles).Returns(dbSet.Object);
            dbSet.Setup(x => x.Add(It.IsAny<Vehicle>())).Returns((Vehicle u) => u);

            var repository = new VehicleRepository(dbContext.Object);
                var vehicle = Builder<Vehicle>.CreateNew().With(s => s.Id = 0).Build();
                repository.Insert(vehicle);
                repository.Save();
                Assert.AreNotEqual(11, vehicle.Id);
        }
    }
}
