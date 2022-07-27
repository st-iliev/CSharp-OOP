namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warAttack;
        private Warrior warDefence;
        // Warrior warAttack = new Warrior("Goshe", 150, 150);
        // Warrior warDefence = new Warrior("Toshe", 50, 50);
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();


        }
        [Test]
        public void ConstructorShouldInitializeEmptyCollection()
        {
            arena = new Arena();
            List<Warrior> actualCollection = arena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>();

            CollectionAssert.AreEqual(expectedCollection, actualCollection);

        }
        [Test]
        public void ConstructorShouldAddValidWarrior()
        {
            warAttack = new Warrior("Goshe", 150, 150);
            arena.Enroll(warAttack);

            Assert.AreEqual(1, arena.Count);
            Assert.That(arena.Warriors, Has.Member(warAttack));
        }
        [Test]
        public void EnrollShouldThrowExceptionWhenWarriorIsAlreadyInArena()
        {
            warAttack = new Warrior("Goshe", 150, 150);
            arena.Enroll(warAttack);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warAttack);
            }, "Warrior is already enrolled for the fights!");
        }
        [TestCase]
        public void FightShouldThrowExceptionWhenAttackerWarriorNameIsMissing()
        {
            Warrior warAttack = new Warrior("Goshe", 150, 150);
            Warrior warDefence = new Warrior("Toshe", 50, 50);
            arena.Enroll(warAttack);
            arena.Enroll(warDefence);

            Assert.Throws<InvalidOperationException>(() => { arena.Fight(null, "Toshe"); ; }, $"There is no fighter with name {warAttack.Name} enrolled for the fights!");
        }
        [TestCase]
        public void FightShouldThrowExceptionWhenDefenseWarriorNameIsMissing()
        {
            Warrior warAttack = new Warrior("Goshe", 150, 150);
            Warrior warDefence = new Warrior("Toshe", 50, 50);
            arena.Enroll(warAttack);
            arena.Enroll(warDefence);

            Assert.Throws<InvalidOperationException>(() => { arena.Fight("Goshe", null); ; }, $"There is no fighter with name {warDefence.Name} enrolled for the fights!");
        }
        [TestCase]
        public void FightShouldBeSuccessfull()
        {
            Warrior warAttack = new Warrior("Goshe", 50, 100);
            Warrior warDefence = new Warrior("Toshe", 50, 120);
            arena.Enroll(warAttack);
            arena.Enroll(warDefence);
            arena.Fight("Goshe", "Toshe");
            int actualAttackerHP = warAttack.HP;
            int expectedAttackerHP = 100 - warDefence.Damage;

            int actualDefenderHP = warDefence.HP;
            int expectedDefenderHP = 120 - warAttack.Damage;

            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);

        }
    }
}
