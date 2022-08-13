namespace Presents.Tests
{
    using NUnit.Framework;
    using Presents;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [Test]
        public void ConstructorShouldCreateNewPreset()
        {
            Present present = new Present("Porche", 1.5);
            string expectedName = "Porche";
            double expectedMagic = 1.5;
            Assert.AreEqual(expectedName, present.Name);
            Assert.AreEqual(expectedMagic, present.Magic);
        }
        [Test]
        public void ConstructorShouldCreateNewEmptyBag()
        {
            Bag bag = new Bag();
            Assert.AreEqual(0, bag.GetPresents().Count);
        }
        [Test]
        public void CreateShouldThrowExpectionWhenPresentIsNull()
        {
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => { bag.Create(null); }, "Present is null");
        }
        [Test]
        public void CreateShouldThrowExpectionWhenPresentIsAlreadyAdded()
        {
            Bag bag = new Bag();
            Present present = new Present("Porche", 1.5);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => { bag.Create(present); }, "This present already exists!");
        }
        [Test]
        public void CreateShouldAddNewPresentToBag()
        {
            Bag bag = new Bag();
            Present present = new Present("Porche", 1.5);
            bag.Create(present);
            Assert.AreEqual(1, bag.GetPresents().Count);
        }
        [Test]
        public void RemoveShouldRemovePresentFromBag()
        {
            Bag bag = new Bag();
            Present present = new Present("Porche", 1.5);
            bag.Create(present);
            Assert.True(bag.Remove(present));
        }
        [Test]
        public void GetPresentWithLeastMagicShouldReturnPresentWithLessMagic()
        {
            Bag bag = new Bag();
            Present present = new Present("Porche", 1.5);
            Present present2 = new Present("GOLFE", 0.5);
            bag.Create(present);
            bag.Create(present2);
            var actualPresent = bag.GetPresentWithLeastMagic();
            Assert.AreSame(present2, actualPresent);
        }
        [Test]
        public void GetPresentShouldReturnCurrentPresent()
        {
            Bag bag = new Bag();
            Present present = new Present("Porche", 1.5);
            Present present2 = new Present("GOLFE", 0.5);
            bag.Create(present);
            bag.Create(present2);
            Assert.AreSame(present, bag.GetPresent("Porche"));
        }
    }

}
