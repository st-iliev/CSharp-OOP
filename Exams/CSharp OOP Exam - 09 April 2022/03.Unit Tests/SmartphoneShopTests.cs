using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;
        [Test]
        public void ConstructorShouldCreateNewSmartphone()
        {
            string expectedModel = "Sony";
            int expectedMaxBattery = 100;
            int expectedCurrentBattery = 30;
            smartphone = new Smartphone("Sony", 100);
            Assert.AreEqual(expectedModel, smartphone.ModelName);
            Assert.AreEqual(expectedMaxBattery, smartphone.MaximumBatteryCharge);
            smartphone.CurrentBateryCharge = 30;
            Assert.AreEqual(expectedCurrentBattery, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void ConstructorShouldCreateNewShopWithoutSmartphones()
        {
            shop = new Shop(0);
            Assert.AreEqual(0, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }
        [TestCase(-1)]
        [TestCase(-57)]
        public void ConstructorShouldThrowExceptionWhenTryToCreateShopWithNegativeCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() => { shop = new Shop(capacity); }, "Invalid capacity.");

        }
        [Test]
        public void AddShouldAddSmartphoneToShop()
        {
            shop = new Shop(2);
            smartphone = new Smartphone("Sony", 100);
            Assert.AreEqual(0, shop.Count);
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);

        }
        [Test]
        public void AddShouldThrowExceptionWhenSmartphoneIsAlreadyAdded()
        {
            shop = new Shop(2);
            smartphone = new Smartphone("Sony", 100);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => { shop.Add(smartphone); }, $"The phone model {smartphone.ModelName} already exist.");

        }
        [Test]
        public void AddShouldThrowExceptionWhenShopIsFull()
        {
            shop = new Shop(1);
            smartphone = new Smartphone("Sony", 100);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => { shop.Add(new Smartphone("IPHONE", 1)); }, "The shop is full.");
            
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenSmartphoneModelIsNotExist()
        {
            string modelName = "IPHONE";
            shop = new Shop(1);
            smartphone = new Smartphone("Sony", 100);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => { shop.Remove(modelName); }, $"The phone model {modelName} doesn't exist.");
        }
        [Test]
        public void RemoveShouldRemoveSmartphoneFromShop()
        {
            string modelName = "Sony";
            shop = new Shop(1);
            smartphone = new Smartphone("Sony", 100);
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
            shop.Remove(modelName);
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void TestPhoneShouldThrowExceptionWhenSmartphoneModelDoNotExist()
        {
            string modelName = "IPHONE";
            shop = new Shop(1);
            smartphone = new Smartphone("Sony", 100);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => { shop.TestPhone(modelName, 3); }, $"The phone model {modelName} doesn't exist.");        
        }
        [Test]
        public void TestPhoneShouldThrowExceptionWhenBatteryIsNotEnough()
        {
            shop = new Shop(1);
            smartphone = new Smartphone("Sony", 100);
            smartphone.CurrentBateryCharge = 30;
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => { shop.TestPhone("Sony", 40); }, $"The phone model {smartphone.ModelName} is low on batery.");
        }
        [Test]
        public void TestPhoneShouldBeSuccessfull()
        {
            shop = new Shop(1);
            smartphone = new Smartphone("Sony", 100);
            smartphone.CurrentBateryCharge = 80;
            shop.Add(smartphone);
            int batteryUsege = 50;
            int expectedBatteryCharge = smartphone.CurrentBateryCharge - batteryUsege;
            shop.TestPhone(smartphone.ModelName, batteryUsege);
            Assert.AreEqual(expectedBatteryCharge, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void ChargePhoneShouldThrowExceptionWhenSmartphoneModelDoNotExist()
        {
            string modelName = "IPHONE";
            shop = new Shop(1);
            smartphone = new Smartphone("Sony", 100);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => { shop.ChargePhone(modelName); }, $"The phone model {modelName} doesn't exist.");     
        }
        [Test]
        public void ChargePhoneShouldChargeBatteryToMaximum()
        {
            shop = new Shop(1);
            smartphone = new Smartphone("Sony", 100);
            smartphone.CurrentBateryCharge = 50;
            shop.Add(smartphone);
            int expectedBattery = 100;
            shop.ChargePhone("Sony");
            Assert.AreEqual(expectedBattery, smartphone.CurrentBateryCharge);
            Assert.AreEqual(smartphone.MaximumBatteryCharge, smartphone.CurrentBateryCharge);
            smartphone.CurrentBateryCharge = 30;
            shop.ChargePhone("Sony");
            Assert.AreEqual(expectedBattery, smartphone.CurrentBateryCharge);
            Assert.AreEqual(smartphone.MaximumBatteryCharge, smartphone.CurrentBateryCharge);
        }
    }
}