using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault vault;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldCreateNewItem()
        {
            string expectedOwnerName = "Peshaka";
            string expectedId = "1337";
            item = new Item("Peshaka", "1337");
            Assert.AreEqual(expectedOwnerName, item.Owner);
            Assert.AreEqual(expectedId, item.ItemId);
        }
        [TestCase("A1")]
        [TestCase("A2")]
        [TestCase("A3")]
        [TestCase("A4")]
        [TestCase("B1")]
        [TestCase("B2")]
        [TestCase("B3")]
        [TestCase("B4")]
        [TestCase("C1")]
        [TestCase("C2")]
        [TestCase("C3")]
        [TestCase("C4")]
        public void ConstructorShouldCreateEmptyVault(string cell)
        {
            vault = new BankVault();
            Assert.AreEqual(null, vault.VaultCells[cell]);
        }
        [Test]
        public void AddItemSuccessfullySavedInCell()
        {
            vault = new BankVault();
            item = new Item("Peshaka", "1337");
            vault.AddItem("A1", item);
            Assert.AreSame(item, vault.VaultCells["A1"]);
        }
        [Test]
        public void AddItemShouldThrowExceptionWhenCellDoNotExist()
        {
            vault = new BankVault();
            item = new Item("Peshaka", "1337");
            Assert.Throws<ArgumentException>(() => { vault.AddItem("C5", item); }, "Cell doesn't exists!");
        }
        [Test]
        public void AddItemShouldThrowExceptionWhenCellIsNotEmpty()
        {
            vault = new BankVault();
            item = new Item("Peshaka", "1337");
            vault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => { vault.AddItem("A1",new Item("Mozz","123")); }, "Cell is already taken!");
           
        }
        [Test]
        public void AddItemShouldThrowExceptionWhenItemIsAlreadyAdded()
        {
            vault = new BankVault();
            item = new Item("Peshaka", "1337");
            vault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => { vault.AddItem("B1", item); }, "Item is already in cell!");     
        }
        [Test]
        public void RemoveItemShouldThrowExceptionWhenCellDoNotExist()
        {
            vault = new BankVault();
            item = new Item("Peshaka", "1337");
            vault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => { vault.RemoveItem("A6", item); }, "Cell doesn't exists!");         
        }
        [Test]
        public void RemoveITemShouldThrowExceoptionWhenItemDoNotExist()
        {
            vault = new BankVault();
            item = new Item("Peshaka", "1337");
            vault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => { vault.RemoveItem("A1", new Item("G-Glass", "2020")); }, $"Item in that cell doesn't exists!");  
        }
        [Test]
        public void RemoveItemSuccessfullyRemoveItemFromCell()
        {
            vault = new BankVault();
            item = new Item("Peshaka", "1337");
            vault.AddItem("A1", item);
            vault.RemoveItem("A1", item);
            Assert.AreEqual(null, vault.VaultCells["A1"]);
        }
    }
}