namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Audi", "A3", 5, 55);
        }


        [TestCase("", "A3", 5.0, 55.0)]
        [TestCase(null, "A3", 15.0, 75.0)]
        [TestCase("Audi", "", 10.0, 80.0)]
        [TestCase("Audi", null, 12.0, 88.0)]
        [TestCase("Audi", "A3", 0, 88.0)]
        [TestCase("Audi", "A3", -1, 88.0)]
        [TestCase("Audi", "A3", 9, 0)]
        [TestCase("Audi", "A3", 16, -1)]
        [TestCase("", "", 0, 0)]
        [TestCase("", "", -15, -15)]
        [TestCase(null, null, 0, 0)]
        [TestCase(null, null, -9, -98)]

        public void ConstructorShouldNotCreateNewCarWithAInvalidData(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
                   {
                       car = new Car(make, model, fuelConsumption, fuelCapacity);
                   });
        }
        [Test]
        public void EmptyConstructorShouldSetFuelAmountToZero()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }
        [TestCase("Audi", "A3", 5.6, 55)]
        public void ConstructorShouldCreateNewCarWithValidInput(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            string expectedMake = make;
            string actualMake = car.Make;
            Assert.AreEqual(expectedMake, actualMake);

            string expectedModel = model;
            string actualModel = car.Model;
            Assert.AreEqual(expectedModel, actualModel);

            double expectedConsumption = fuelConsumption;
            double actualConsumption = car.FuelConsumption;
            Assert.AreEqual(expectedConsumption, actualConsumption);

            double expectedCapacity = fuelCapacity;
            double actualCapacity = car.FuelCapacity;
            Assert.AreEqual(expectedCapacity, actualCapacity);

        }
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowExeptionWhenTryToRefuelCarWithInvalidValue(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);

            }, "Fuel amount cannot be zero or negative!");
        }
        [Test]
        public void RefuelShouldRefuelCarWhenTryToRefuelCarWithValidValue()
        {
            car.Refuel(45.5);
            double expectedAmount = 45.5;
            double actualAmount = car.FuelAmount;
            Assert.AreEqual(expectedAmount, actualAmount);
        }
        [Test]
        public void RefuelShouldSetFuelAmoauntEqualToFuelCapacityWithValidValue()
        {
            car.Refuel(60.9);
            double expectedAmount = 55.0;
            double actualAmount = car.FuelAmount;
            Assert.AreEqual(car.FuelCapacity, actualAmount);
            Assert.AreEqual(expectedAmount, car.FuelCapacity);
        }
        [Test]
        public void DriveShouldThrowExeptionWhenFuelAmountIsNotEnough()
        {
            double distance = 1500.0;
            car.Refuel(50.0);
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");

        }
        [Test]
        public void DriveShouldReduceFuelMount()
        {    
            car.Refuel(50.0);
            car.Drive(500);
            Assert.AreEqual(25, car.FuelAmount);
        }
       
        
    }
}