namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {

        }

        [TestCase(null)]
        [TestCase(" ")]
        public void ConstructorShouldThrowExeptionWhenTryToSetNameWithInvalidInput(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, 50, 150);
            }, "Name should not be empty or whitespace!");
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-26)]
        public void ConstructorShouldThrowExeptionWhenTryToSetDamageEqualOrLessThanZero(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Goshe", damage, 150);
            }, "Damage value should be positive!");
        }
        [TestCase(-1)]
        [TestCase(-50)]
        public void ConstructorShouldThrowExeptionWhenTryToSetHPLessThanZero(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Goshe", 50, hp);
            }, "HP should not be negative!");
        }
        [Test]
        public void ConstructorShouldCreateNewWarrior()
        {
            warrior = new Warrior("Goshe", 50, 150);
            Assert.AreEqual("Goshe", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(150, warrior.HP);
        }
        [TestCase(30)]
        [TestCase(20)]
        [TestCase(0)]
        public void AttackShouldThrowExceptionWhenYourHpIsLow(int hp)
        {
            Warrior warAttack = new Warrior("Goshe", 50, hp);
            Warrior warDefence = new Warrior("Toshe", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warAttack.Attack(warDefence);
            }, "Your HP is too low in order to attack other warriors!");
        }
        [TestCase(30)]
        [TestCase(20)]
        [TestCase(0)]
        public void AttackShouldThrowExceptionWhenTryToAttackEnemyWithLowHP(int hp)
        {
            Warrior warAttack = new Warrior("Goshe", 50, 100);
            Warrior warDefence = new Warrior("Toshe", 50, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warAttack.Attack(warDefence);
            }, $"Enemy HP must be greater than 30 in order to attack him!");
        }
        [TestCase(30, 50)]
        [TestCase(0, 100)]
        [TestCase(59, 60)]
        public void AttackShouldThrowExceptionWhenYouTryToAttackStrongEnemy(int hp, int attack)
        {
            Warrior warAttack = new Warrior("Goshe", 50, hp);
            Warrior warDefence = new Warrior("Toshe", attack, 300);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warAttack.Attack(warDefence);
            }, $"You are trying to attack too strong enemy");
        }
        [Test]
        public void AttackShouldBeSuccessfullHpAndDamageIsEqual()
        {
            Warrior warAttack = new Warrior("Goshe", 50, 50);
            Warrior warDefence = new Warrior("Toshe", 50, 50);
            warAttack.Attack(warDefence);
            Assert.AreEqual(0, warAttack.HP);
            Assert.AreEqual(0, warDefence.HP);
        }
        [Test]
        public void AttackShouldBeSuccessfullWhenAttackDamageIsMoreThanDefenceHp()
        {
            Warrior warAttack = new Warrior("Goshe", 150, 150);
            Warrior warDefence = new Warrior("Toshe", 50, 50);
            warAttack.Attack(warDefence);
            Assert.AreEqual(0, warDefence.HP);
        }
        [TestCase(50)]
        [TestCase(70)]
        public void AttackShouldBeSuccessfullWhenAttackDamageIsLessOrEqualDefenceHp(int damage)
        {
            Warrior warAttack = new Warrior("Goshe", damage, 150);
            Warrior warDefence = new Warrior("Toshe", 50, 70);
            warAttack.Attack(warDefence);
            int warDefenceHP = 70 - damage;
            Assert.AreEqual(warDefenceHP, warDefence.HP);
        }
    }
}