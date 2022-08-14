using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            private Weapon weapon;
            [Test]
            public void ConstructorShouldCreateNewWeapon()
            {
                string expectedName = "BOM";
                double expectedPrice = 100.5;
                int expectedDestructionLevel = 5;
                weapon = new Weapon("BOM", 100.5, 5);
                Assert.AreEqual(expectedName, weapon.Name);
                Assert.AreEqual(expectedPrice, weapon.Price);
                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
                Assert.False(weapon.IsNuclear);
            }
            [TestCase(10)]
            [TestCase(50)]

            public void WeaponShouldBeNuclear(int destructionLevel)
            {
                weapon = new Weapon("BOM", 100.5, destructionLevel);
                Assert.True(weapon.IsNuclear);
            }
            [Test]
            public void IncreaseDesctructionLevelShouldIncreaseDestructionLevelBy1()
            {
                int expectedDestructionLevel = 6;
                weapon = new Weapon("BOM", 100.5, 5);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
            }
            [Test]
            public void ConstructorShouldThrowExceptionWhenPriceIsNegativeNumber()
            {
                Assert.Throws<ArgumentException>(() => { weapon = new Weapon("BOM", -1, 5); }, "Price cannot be negative.");

            }
            [Test]
            public void ConstructorShouldCreateNewPlanetWithNoWeapons()
            {
                string expectedPlanetName = "BOKA";
                double expectedBudget = 130.45;
                planet = new Planet("BOKA", 130.45);
                Assert.AreEqual(expectedPlanetName, planet.Name);
                Assert.AreEqual(expectedBudget, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);
                Assert.AreEqual(0, planet.MilitaryPowerRatio);
            }
            [TestCase(null)]
            [TestCase("")]
            public void ConstructorShouldThrowExceptionWhenNameIsInvalid(string name)
            {
                Assert.Throws<ArgumentException>(() => { planet = new Planet(name, 130.45); }, "Invalid planet Name");
                
            }
            [Test]
            public void ConstructorShouldThrrowExceptionWhenBudgetIsNegativeAmount()
            {
                Assert.Throws<ArgumentException>(() => { planet = new Planet("BOKA", -1); }, "Budget cannot drop below Zero!");          
            }
            [Test]
            public void ProfitShouldIncreaseBudgetWithCurrentAmount()
            {
                double expectedBudget = 130.45 + 50;
                planet = new Planet("BOKA", 130.45);
                planet.Profit(50);
                Assert.AreEqual(expectedBudget, planet.Budget);
            }
            [Test]
            public void SpendFundsShouldThrowExceptionWhenBudgetIsNotEnough()
            {
                planet = new Planet("BOKA", 130.45);
                Assert.Throws<InvalidOperationException>(() => { planet.SpendFunds(150); }, $"Not enough funds to finalize the deal.");    
            }
            [Test]
            public void SpendFundsShouldDecreaseBudgetWithCurrentAmount()
            {
                double expectedBudget = 130.45 - 30.45;
                planet = new Planet("BOKA", 130.45);
                planet.SpendFunds(30.45);
                Assert.AreEqual(expectedBudget, planet.Budget);
            }
            [Test]
            public void AddWeaponShouldAddWeaponToPlanet()
            {
                double expectedDestructionPower = 5;
                weapon = new Weapon("BOM", 100.5, 5);
                planet = new Planet("BOKA", 130.45);
                planet.AddWeapon(weapon);
                Assert.AreEqual(1, planet.Weapons.Count);
                Assert.AreEqual(expectedDestructionPower, planet.MilitaryPowerRatio);
            }
            [Test]
            public void AddWeaponShouldThrowExceptionWhenWeaponIsAlreadyAdded()
            {
                weapon = new Weapon("BOM", 100.5, 5);
                planet = new Planet("BOKA", 130.45);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => { planet.AddWeapon(weapon); }, $"There is already a {weapon.Name} weapon.");
            }
            [Test]
            public void RemoveWeaponShouldRemoveCurrentWeaponFromPlanet()
            {
                weapon = new Weapon("BOM", 100.5, 5);
                planet = new Planet("BOKA", 130.45);
                planet.AddWeapon(weapon);
                CollectionAssert.IsNotEmpty(planet.Weapons);
                planet.RemoveWeapon("BOM");
                CollectionAssert.IsEmpty(planet.Weapons);
            }
            [Test]
            public void UpgradeWeaponShouldThrowExceptionWhenCurrentWeaponIsNotExists()
            {
                string weaponName = "OPA";
                weapon = new Weapon("BOM", 100.5, 5);
                planet = new Planet("BOKA", 130.45);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => { planet.UpgradeWeapon(weaponName); }, $"{weaponName} does not exist in the weapon repository of {planet.Name}");
            }
            [Test]
            public void UpgradeWeaponShouldIncreaseCurrentWeaponDestructionLevel()
            {
                weapon = new Weapon("BOM", 100.5, 5);
                planet = new Planet("BOKA", 130.45);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("BOM");
                var currentWeapon = planet.Weapons.FirstOrDefault(s => s.Name == "BOM");
                Assert.AreEqual(6, currentWeapon.DestructionLevel);
            }
            [Test]
            public void DestructOpponentShouldThrowExceptionWhenOurPowerIsLowerOrEqualToOpponentPower()
            {
                planet = new Planet("BOKA", 130.45);
                Planet planet2 = new Planet("CHUK", 300);
                weapon = new Weapon("BOM", 100.5, 5);
                Weapon weapon2 = new Weapon("OPA", 100, 300);
                planet.AddWeapon(weapon);
                planet2.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);
                Assert.Throws<InvalidOperationException>(() => { planet.DestructOpponent(planet2); }, $"{planet2.Name} is too strong to declare war to!");
            }
            [Test]
            public void DestructOpponentShouldDestroyOpponent()
            {
                planet = new Planet("BOKA", 130.45);
                Planet planet2 = new Planet("CHUK", 300);
                weapon = new Weapon("BOM", 100.5, 5);
                Weapon weapon2 = new Weapon("OPA", 100, 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                planet2.AddWeapon(weapon);
                string expectedResult = $"{planet2.Name} is destructed!";
                Assert.AreEqual(expectedResult, planet.DestructOpponent(planet2));

            }
            [Test]
            public void MilitaryPowerRatioShouldSumDestructionLevelOfAllWeapons()
            {
                planet = new Planet("BOKA", 130.45);
                weapon = new Weapon("BOM", 100.5, 5);
                Weapon weapon2 = new Weapon("OPA", 100, 300);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                Assert.AreEqual(305, planet.MilitaryPowerRatio);
                Assert.AreEqual(2, planet.Weapons.Count);
            }
        }
    }
}
