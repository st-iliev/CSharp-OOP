using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Gym gym;
        private Athlete athlete;
        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete("Boiko");
            gym = new Gym("Nikoga dolo", 1);
        }
        [Test]
        public void ConstructorShouldCrateNewAthlete()
        {
            string expectedName = "Boiko";
            bool expectedInjure = false;
            Athlete athlete = new Athlete("Boiko");
            Assert.AreEqual(expectedName, athlete.FullName);
            Assert.AreEqual(expectedInjure, athlete.IsInjured);
        }
        [Test]
        public void ConstructorShouldCreateNewGym()
        {
            string expectedName = "Pobediteli";
            int expectedCapacity = 100;
            Gym gym = new Gym("Pobediteli", 100);

            Assert.AreEqual(expectedName, gym.Name);
            Assert.AreEqual(expectedCapacity, gym.Capacity);
            Assert.AreEqual(0, gym.Count);

        }
        [TestCase("")]
        [TestCase(null)]

        public void ConstructorShouldThrowExceptionWhenNameIsInvalid(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 1);
            }, "Invalid gym name.");
        }
        [TestCase(-1)]
        [TestCase(-50)]

        public void ConstructorShouldThrowExceptionWhenSizeIsBelowZero(int size)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Boiko", size);
            }, "Invalid gym capacity.");
        }

        [Test]
        public void AddAthleteShouldThrowExceptionWhenGymIsFull()
        {
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("Gosho"));
            }, "The gym is full.");
        }
        [Test]
        public void AddAthleteShouldAddAthleteToTheGym()
        {
            int expectedCount = 1;
            gym.AddAthlete(athlete);
            Assert.AreEqual(expectedCount, gym.Count);
        }
        [Test]
        public void RemoveAthleteShouldThrowExceptionWhenAthleteIsNotExsist()
        {
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Batko");
            }, $"The athlete {athlete.FullName} doesn't exist.");
        }
        [Test]
        public void RemoveAthleteShouldRemoveAthleteFromTheGym()
        {
            Gym gym = new Gym("Machkame", 2);
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("Gosho"));
            gym.RemoveAthlete("Gosho");
            Assert.AreEqual(1, gym.Count);

        }
        [Test]
        public void InjureAthleteShouldThrowExceptionWhenAthleteIsNotExsist()
        {
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Boika");
            }, $"The athlete {athlete.FullName} doesn't exist.");
        }
        [Test]
        public void InjureAthleteShouldInjuredAthleteInTheGym()
        {
            gym.AddAthlete(athlete);
            var injuredAthlete = gym.InjureAthlete(athlete.FullName);

            Assert.True(athlete.IsInjured);
            Assert.AreSame(athlete, injuredAthlete);
        }
        [Test]
        public void ReportShouldReturnStringWithActiveAthleteInGym()
        {
            Gym gym = new Gym("Machkai", 2);
            gym.AddAthlete(athlete);
            gym.InjureAthlete(athlete.FullName);
            Athlete athlete2 = new Athlete("Gosho");
            gym.AddAthlete(athlete2);
            string expectedReport = $"Active athletes at {gym.Name}: {athlete2.FullName}";
            Assert.AreEqual(expectedReport, gym.Report());
        }
        [Test]
        public void ReportShouldReturnStringWhenAllAthletesAreActiveInGym()
        {
            Gym gym = new Gym("Machkai", 2);
            gym.AddAthlete(athlete);
            Athlete athlete2 = new Athlete("Gosho");
            gym.AddAthlete(athlete2);
            Assert.AreEqual("Active athletes at Machkai: Boiko, Gosho", gym.Report());
        }
        [Test]
        public void ReportShouldReturnStringWithEmptyGym()
        {
            Gym gym = new Gym("Machkai", 2);

            Assert.AreEqual("Active athletes at Machkai: ", gym.Report());
        }

    }
}
