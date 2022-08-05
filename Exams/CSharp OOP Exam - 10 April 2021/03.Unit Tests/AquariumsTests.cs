namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            fish = new Fish("Muncho");
        }
        [Test]
        public void ConstructorShouldCreateNewFish()
        {
            Assert.AreEqual("Muncho", fish.Name);
            Assert.True(fish.Available);
        }
        [Test]
        public void AvailableShouldBeSetToFalse()
        {
            fish.Available = false;
            Assert.False(fish.Available);
        }
        [Test]
        public void ConstructorShouldCreateNewAquarium()
        {
            aquarium = new Aquarium("RIBKI", 5);
            Assert.AreEqual("RIBKI", aquarium.Name);
            Assert.AreEqual(5, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }
        [TestCase(null)]
        [TestCase("")]
        public void AquariumNameShouldThrowExceptionWhenNameIsInavalid(string name)
        {
           Assert.Throws<ArgumentNullException>(()=> { aquarium = new Aquarium(name, 5); }, "Invalid aquarium name!");
        }
        [TestCase(-1)]
        [TestCase(-5)]
        public void AquariumCapacityShouldThrowExceptionWhenCapacityIsBelowZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() => { aquarium = new Aquarium("RIBKI", capacity); }, "Invalid aquarium capacity!");
        }
        [Test]
        public void AddFishShouldThrowExceptionWhenCapacityIsFull()
        {
            aquarium = new Aquarium("RIBKI", 0);
            Assert.Throws<InvalidOperationException>(() => {aquarium.Add(fish); }, "Aquarium is full!");
        }
        [Test]
        public void AddFishShouldAddFishToAquarium()
        {
            aquarium = new Aquarium("RIBKI", 1);
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void RemoveFishShouldThrowExceptionWhenFishIsNotExcist()
        {
            aquarium = new Aquarium("RIBKI", 1);
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => { aquarium.RemoveFish("BOJKA"); }, $"Fish with the name BOJKA doesn't exist!");
        }
        [Test]
        public void RemoveFishShouldRemoveFishFromAquarium()
        {
            aquarium = new Aquarium("RIBKI", 3);
            aquarium.Add(fish);
            aquarium.Add(new Fish("Gosho"));
            aquarium.RemoveFish("Muncho");
            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void SellFishShouldThrowExceptionWhenFishIsNotExcist()
        {
            aquarium = new Aquarium("RIBKI", 1);
            aquarium.Add(fish);
            string name = "BOBKATA";
            Assert.Throws<InvalidOperationException>(() => {aquarium.SellFish(name);},$"Fish with the name {name} doesn't exist!");
        }
        [Test]
        public void SellFishShouldChangeFishAvaliableToFalse()
        {
            aquarium = new Aquarium("RIBKI", 1);
            aquarium.Add(fish);
            var currentFish = aquarium.SellFish("Muncho");
            Assert.AreSame(currentFish, aquarium.SellFish("Muncho"));
            Assert.False(currentFish.Available); 
        }
        [Test]
        public void ReportShouldReturnInformationAboutAllAvaliableFish()
        {
            aquarium = new Aquarium("RIBKI", 3);
            aquarium.Add(fish);
            aquarium.Add(new Fish("Gosho"));
            string expectedReport = "Fish available at RIBKI: Muncho, Gosho";
            Assert.AreEqual(expectedReport, aquarium.Report());
        }
        [Test]
        public void ReportShouldReturnEmptyStringForAvaliableFish()
        {
            aquarium = new Aquarium("RIBKI", 3);
            string expectedReport = "Fish available at RIBKI: ";
            Assert.AreEqual(expectedReport, aquarium.Report());

        }

    }
}
