using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroRepo;
    [Test]
    public void ConstructorShouldCrateNewHero()
    {
        string expectedName = "Muncho";
        int expectedLevel = 100;
        hero = new Hero("Muncho", 100);
        Assert.AreEqual(expectedName, hero.Name);
        Assert.AreEqual(expectedLevel, hero.Level);
    }
    [Test]
    public void ConstructorShouldCreateNewEmptyRepo()
    {
        heroRepo = new HeroRepository();
        CollectionAssert.IsEmpty(heroRepo.Heroes);
    }
    [Test]
    public void CreateShouldThrowExceptionWhenHeroIsNull()
    {
        heroRepo = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepo.Create(null);
        }, "Hero is null");
    }
    [Test]
    public void CreateShouldThrowExceptionWhenHeroIsAlreadyExists()
    {
        heroRepo = new HeroRepository();
        hero = new Hero("Muncho", 100);
        heroRepo.Create(hero);
        Assert.Throws<InvalidOperationException>(() => { heroRepo.Create(hero); }, $"Hero with name {hero.Name} already exists");
    }
    [Test]
    public void CreateShouldAddHeroToCollection()
    {
        heroRepo = new HeroRepository();
        hero = new Hero("Muncho", 100);
        var actualResult = heroRepo.Create(hero);
        Assert.AreEqual(1, heroRepo.Heroes.Count);
        var expectedResult = $"Successfully added hero {hero.Name} with level {hero.Level}";
        Assert.AreEqual(expectedResult, actualResult);
    }
    [TestCase(null)]
    [TestCase(" ")]
    public void RemoveShouldThrowExceptionWhenHeroNameIsInvalid(string name)
    {
        heroRepo = new HeroRepository();
        hero = new Hero("Muncho", 100);
        heroRepo.Create(hero);
        Assert.Throws<ArgumentNullException>(() => { heroRepo.Remove(name); }, "Name cannot be null");
    }
    [Test]
    public void RemoveShouldRemoveHeroFromCollection()
    {
        heroRepo = new HeroRepository();
        hero = new Hero("Muncho", 100);
        heroRepo.Create(hero);
        Assert.AreEqual(1, heroRepo.Heroes.Count);
        bool actualResult = heroRepo.Remove("Muncho");
        Assert.True(actualResult);
    }
    [Test]
    public void GetHeroWithHighestLevelShouldReturnHighestLevelHero()
    {
        heroRepo = new HeroRepository();
        Hero hero3 = new Hero("Tosheto", 59);
        hero = new Hero("Muncho", 100);
        Hero hero2 = new Hero("Bojko", 70);
        heroRepo.Create(hero3);
        heroRepo.Create(hero);
        heroRepo.Create(hero2);
        Hero actualHero = heroRepo.GetHeroWithHighestLevel();
        Assert.AreEqual(hero, actualHero);
    }
    [Test]
    public void GetHeroShouldReturnHeroWithCurrentName()
    {
        heroRepo = new HeroRepository();
        hero = new Hero("Muncho", 100);
        Hero hero2 = new Hero("Bojko", 70);
        heroRepo.Create(hero2);
        heroRepo.Create(hero);
        Hero actualHero = heroRepo.GetHero("Muncho");
        Assert.AreEqual(hero, actualHero);
    }
    [Test]
    public void GetHeroShouldReturnNullIsHeroIsNotExists()
    {
        heroRepo = new HeroRepository();
        hero = new Hero("Muncho", 100);
        Hero hero2 = new Hero("Bojko", 70);
        heroRepo.Create(hero2);
        heroRepo.Create(hero);
        Hero actualHero = heroRepo.GetHero("Tosheto");
        Assert.IsNull(actualHero);
    }
}