using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Car car;
            private Garage garage;
            [Test]
            public void ConstructorShouldCreateNewCar()
            {
                Car car = new Car("GOLF2", 0);

                Assert.AreEqual("GOLF2", car.CarModel);
                Assert.AreEqual(0, car.NumberOfIssues);
                Assert.True(car.IsFixed);

            }
            [Test]
            public void ConstructorShouldCreateNewGarage()
            {
                Garage garage = new Garage("NIE NE MOJEM", 1);
                Assert.AreEqual("NIE NE MOJEM", garage.Name);
                Assert.AreEqual(1, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }
            [TestCase(null)]
            [TestCase("")]
            public void ConstructorShouldThrowExceptionWhenNameIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>(() => { Garage garage = new Garage(name, 1); }, "Invalid garage name.");
            }
            [TestCase(0)]
            [TestCase(-1)]
            public void ConstructorShouldThrowExceptionWhenAvaliableMechanicsAreEqualOrBelowZero(int avaliableMechanics)
            {
                Assert.Throws<ArgumentException>(() => { Garage garage = new Garage("NIE NE MOJEM", avaliableMechanics); }, "At least one mechanic must work in the garage.");
            }
            [Test]
            public void AddCarShouldAddCar()
            {
                Garage garage = new Garage("NIE NE MOJEM", 1);
                garage.AddCar(new Car("GOLF2", 1));
                Assert.AreEqual(1, garage.CarsInGarage);
            }
            [Test]
            public void AddCarShouldThrowExceptionWhenThereAreNotAvaliableMechanics()
            {
                Garage garage = new Garage("NIE NE MOJEM", 1);
                garage.AddCar(new Car("GOLF2", 1));
                Assert.Throws<InvalidOperationException>(() => { garage.AddCar(new Car("GOLF3", 1)); }, "No mechanic available.");
            }
            [Test]
            public void FixCarShouldThrowExceptionWhenCarDoesNotExist()
            {
                Garage garage = new Garage("NIE NE MOJEM", 1);
                garage.AddCar(new Car("GOLF2", 1));
                Assert.Throws<InvalidOperationException>(() => { garage.FixCar("GOLF3"); }, $"The car GOLF3 doesn't exist.");
            }
            [Test]
            public void FixCarShouldReteurnCarWithoutIssues()
            {
                Garage garage = new Garage("NIE NE MOJEM", 1);
                garage.AddCar(new Car("GOLF2", 1));
                var car = garage.FixCar("GOLF2");
                Assert.AreSame(car, garage.FixCar("GOLF2"));
                Assert.AreEqual(0, car.NumberOfIssues);
            }
            [Test]
            public void RemoveFixedCarShouldThrowExceptionWhenThereAreNotFixedCars()
            {
                Garage garage = new Garage("NIE NE MOJEM", 3);
                garage.AddCar(new Car("GOLF2", 1));
                Assert.Throws<InvalidOperationException>(() => { garage.RemoveFixedCar(); }, $"No fixed cars available.");
            }
            [Test]
            public void RemoveFixedCarShouldReturnNumberOfFixedCars()
            {
                Garage garage = new Garage("NIE NE MOJEM", 3);
                garage.AddCar(new Car("GOLF2", 1));
                garage.FixCar("GOLF2");
                Assert.AreEqual(1, garage.RemoveFixedCar());
            }
            [Test]
            public void ReportShouldReturnReportForAllCarsWhichIsNotFixed()
            {
                Garage garage = new Garage("NIE NE MOJEM", 3);
                garage.AddCar(new Car("GOLF", 1));
                garage.AddCar(new Car("GOLF2", 1));
                garage.AddCar(new Car("GOLF3", 1));
                string report = "There are 3 which are not fixed: GOLF, GOLF2, GOLF3.";
                Assert.AreEqual(report, garage.Report());
               
            }
        }
    }
}