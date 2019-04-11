using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using VehicleAPI.Controllers;
using VehicleCommon;
using VehicleDAL;

namespace VehicleAPITests
{
    [TestClass]
    public class VehicleApiUnitTests
    {
        [TestMethod]
        public void GetVehiclesByUserIdValidId()
        {
            AutoMock mock = null;
            int userId = 1;

            try
            {
                mock = AutoMock.GetLoose();
                mock.Mock<IVehicleDAL>()
                    .Setup(itm => itm.GetVehicleCollectionByUserId(userId))
                    .Returns(GetVehiclesByUserId(userId));

                var controller = mock.Create<VehicleController>();
                var expected = this.GetVehiclesByUserId(userId);
                var actual = controller.Get(userId);

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.ToList().Count);
            }
            finally
            {
                if(mock != null) { mock.Dispose(); mock = null; }
            }
        }

        [TestMethod]
        public void GetVehiclesByUserIdInvalidId()
        {
            AutoMock mock = null;
            int userId = 14;

            try
            {
                mock = AutoMock.GetLoose();
                mock.Mock<IVehicleDAL>()
                    .Setup(itm => itm.GetVehicleCollectionByUserId(userId))
                    .Returns(GetVehiclesByUserId(userId));

                var controller = mock.Create<VehicleController>();
                var expected = this.GetVehiclesByUserId(userId);
                var actual = controller.Get(userId);

                Assert.IsTrue(actual == null);
                Assert.IsTrue(expected == null);
            }
            finally
            {
                if (mock != null) { mock.Dispose(); mock = null; }
            }
        }

        
        private List<Vehicle> GetVehiclesByUserId(int userId)
        {
            List<Vehicle> vehicles = null;

            switch (userId)
            {
                case 1:
                    vehicles = new List<Vehicle>
                    {
                        new Vehicle
                        {
                            Id = 1,
                            IsActive = false,
                            Make = "Ford",
                            Model = "2006 Mustang GT",
                            UserId = 1
                        },
                        new Vehicle
                        {
                            Id = 2,
                            IsActive = false,
                            Make = "Ford",
                            Model = "2001 Mustang Coupe (V6)",
                            UserId = 1
                        },
                        new Vehicle
                        {
                            Id = 3,
                            IsActive = false,
                            Make = "Ford",
                            Model = "2008 Escape XLT V6 4x4",
                            UserId = 1
                        },
                        new Vehicle
                        {
                            Id = 4,
                            IsActive = true,
                            Make = "Ford",
                            Model = "2012 Mustang GT",
                            UserId = 1
                        },
                        new Vehicle
                        {
                            Id = 6,
                            IsActive = true,
                            Make = "Ford",
                            Model = "2017 Explorer XLT 3.5L V6 4x4",
                            UserId = 1
                        }

                    };
                    break;
                default:
                    break;
            };
            

            return vehicles;
        }
    }
}
