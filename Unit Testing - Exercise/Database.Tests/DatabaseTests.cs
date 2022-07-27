namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;
        [SetUp]
        public void SetUp()
        {
            this.db = new Database();
        }
        [TestCase(new int[] { })]
        [TestCase(new int[] { 0,1,2})]
        [TestCase(new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15 })]
        public void ConstructorShouldAddLessThan16Elements(int[] elements)
        {
                db = new Database(elements);
            int[] actualDb = db.Fetch();
            int[] expectedDb = elements;

            int actualCount = db.Count;
            int expectedCount = expectedDb.Length;

            CollectionAssert.AreEqual(expectedDb, actualDb, "Database constructor should initialize data field currectly!");
            Assert.AreEqual(expectedCount, actualCount,"Constructor should initialize value for count field!");
        }
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,16 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,16,17,18})]
        public void ConstructorShouldAddMoreThan16Elements(int[] elements)
        {
            Assert.Throws<InvalidOperationException>(() =>
           {
               db = new Database(elements);
           }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void ConstructorShouldNotAllowToExceedMaximumCount()
        {

            Assert.That(() =>
            {
                db = new Database(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
                db.Add(5);
            },Throws.Exception.TypeOf<InvalidOperationException>(),"Database capacity must be exacly 16 integers long!");
        }
        

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void RemoveShouldRemoveLastElemenetFromDatabaseOnce(int[] elements)
        {
            foreach (var el in elements)
            {
                db.Add(el);
            }
            db.Remove();
            List<int> list = new List<int>(elements);
            list.RemoveAt(list.Count - 1);
            int[] testDB = list.ToArray();
            int[] currentDB = db.Fetch();

            int actualCount = db.Count;
            int expectedCount = testDB.Length;

            CollectionAssert.AreEqual(testDB, currentDB);
            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestCase(new int[] { })]
        public void RemoveShouldThrowExeptionWhenThereAreNoElemenets(int[] elemenets)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db = new Database(elemenets);
                db.Remove();
            }, "The collection is empty!");
        }
        [TestCase(new int[] { 0, 1, 2 })]
        public void RemoveShouldRemoveElemenetFromDatabaseMoreThanOnce(int[] elements)
        {
            db = new Database(elements);
            for (int i = 0; i < elements.Length; i++)
            {
                db.Remove();
            }
            int actualCount = db.Count;
            int expectedCount = 0;
            int[] actualDB = db.Fetch();
            int[] expectedDb = new int[] { };
            CollectionAssert.AreEqual(expectedDb, actualDB);
            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestCase(new int[] { })]
        [TestCase(new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void FletchShouldReturnCoppyArray(int[] elements)
        {
            db = new Database(elements);
            int[] currentDb = db.Fetch();
            CollectionAssert.AreEqual(elements, currentDb);
        }
    }
}
