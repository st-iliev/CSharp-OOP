namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book;
        [Test]
        public void ConstructorShouldCreateNewBook()
        {
            book = new Book("HOW TO DO IT", "J.J.Failer");
            string expectedBookName = "HOW TO DO IT";
            string expectedAuthorName = "J.J.Failer";
            Assert.AreEqual(expectedAuthorName, book.Author);
            Assert.AreEqual(expectedBookName, book.BookName);
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionWhenBookNameIsInvalid(string name)
        {
            Assert.Throws<ArgumentException>(() => { book = new Book(name, "J.J.Failer"); }, $"Invalid {name}!");
        }
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionWhenAuthorNameIsInvalid(string name)
        {
            Assert.Throws<ArgumentException>(() => { book = new Book("HOW TO DO IT", name); }, $"Invalid {name}!");
        }
        [Test]
        public void AddFootnoteShouldAddFootnote()
        {
            book = new Book("HOW TO DO IT", "J.J.Failer");
            book.AddFootnote(1, "It's broke");
            Assert.AreEqual(1, book.FootnoteCount);
            Assert.AreEqual("Footnote #1: It's broke", book.FindFootnote(1));
        }
        [Test]
        public void AddFootnoteShouldThrowExceptionWhenFootnoneAlreadyExists()
        {
            book = new Book("HOW TO DO IT", "J.J.Failer");
            book.AddFootnote(1, "It's broke");
            Assert.Throws<InvalidOperationException>(() => { book.AddFootnote(1, "True true"); }, "Footnote already exists!");

        }
        [Test]
        public void FindFootnoteShouldThrowExceptionWhenFootnoneDoNotExists()
        {
            book = new Book("HOW TO DO IT", "J.J.Failer");
            book.AddFootnote(1, "It's broke");
            Assert.Throws<InvalidOperationException>(() => { book.FindFootnote(2); }, "Footnote doesn't exists!");
        }
        [Test]
        public void AlterFootnoteShouldThrowExceptionWhenFootnoteDoNotExists()
        {
            book = new Book("HOW TO DO IT", "J.J.Failer");
            book.AddFootnote(1, "It's broke");
            Assert.Throws<InvalidOperationException>(() => { book.AlterFootnote(2,"Go Go Go"); }, "Footnote doesn't exists!");
        }
        [Test]
        public void AlterFootnoteShouldChangeFootnoteText()
        {
            book = new Book("HOW TO DO IT", "J.J.Failer");
            book.AddFootnote(1, "It's broke");
            Assert.AreEqual("Footnote #1: It's broke", book.FindFootnote(1));
            book.AlterFootnote(1, "It's very broken");
            Assert.AreEqual("Footnote #1: It's very broken", book.FindFootnote(1));
        }


    }
}