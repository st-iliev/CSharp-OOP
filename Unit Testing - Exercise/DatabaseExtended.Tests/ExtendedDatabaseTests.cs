namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person person;
        private Database db;
        [SetUp]
        public void SetUp()
        {
            db = new Database();
            person = new Person(123456789123, "Pesho");
        }
        [Test]
        public void AddShouldNotAddAnotherPersonWithSameUsername()
        {

            db.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            {
                person = new Person(123456789124, "Pesho");
                db.Add(person);
            }, "There is already user with this username!");
        }
        [Test]
        public void AddShouldNotAddAnotherPersonWithSameId()
        {

            db.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            {
                person = new Person(123456789123, "Gosho");
                db.Add(person);
            }, "There is already user with this Id!");
        }
        [Test]
        public void AddShouldNotAddMoreThan16PersonsInDatabase()
        {
            for (int i = 0; i < 16; i++)
            {
                long id = 123456789123 + i;
                string name = $"Pesho{i}";
                Person person = new Person(id, name);
                db.Add(person);
            }
            person = new Person(123456789113, "Gosho");
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(person);
            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void RemoveShouldRemoveLastPersonFromDatabase()
        {
            for (int i = 0; i < 16; i++)
            {
                long id = 123456789123 + i;
                string name = $"Pesho{i}";
                Person person = new Person(id, name);
                db.Add(person);
            }
            db.Remove();
            Assert.Throws<InvalidOperationException>(() =>
          {
              db.FindByUsername("Pesho15");
          }, "No user is present by this username!");
        }
        [Test]
        public void RemoveShouldThrowExeptionWhenThereIsNoPerson()
        {
            Assert.Throws<InvalidOperationException>(() =>
           {
               db.Remove();
           }, "Method cann't remove from empty database!");
        }
        [Test]
        public void FindByUsernameShouldThrowExeptionWhenSearchedByInvalidUsername()
        {

            db.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("Gosho");
            }, "No user is present by this username!");
        }
        [Test]
        public void FindByUsernameShouldThrowExeptionWhenSearchedByValidUsername()
        {
            db.Add(person);

            Person samePerson = db.FindByUsername("Pesho");

            Assert.AreEqual(person, samePerson);

        }
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameShouldThrowExeptionWhenSearchedUsernameIsNullOrEmpty(string name)
        {
            db.Add(person);
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(name);
            }, "Username parameter is null!");
        }
        [Test]
        public void FindByIdShouldThrowExeptionWhenSearchedIdIsLessThanZero()
        {
            db.Add(person);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-1);
            }, "Id should be a positive number!");
        }
        [Test]
        public void FindByIdShouldThrowExeptionWhenSearchedByInvalidId()
        {
            db.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(123456789147);
            }, "No user is present by this ID!");
        }
        [Test]
        public void FindByIdShouldReturnPersonWithSearchedId()
        {
            db.Add(person);

            Person samePerson = db.FindById(123456789123);

            Assert.AreEqual(person, samePerson);

        }
        [Test]
        public void ConstructorShouldNotAddRangeMoreThan16Persons()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 17; i++)
            {
                long id = 123456789123 + i;
                string name = $"Pesho{i}";
                Person person = new Person(id, name);
                persons.Add(person);
            }
            Person[] newPersons = persons.ToArray();
            Assert.Throws<ArgumentException>(() => { db = new Database(newPersons); }, "Provided data length should be in range [0..16]!");
        }
        [Test]
        public void ConstructorShouldAddRange16Persons()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 16; i++)
            {
                long id = 123456789123 + i;
                string name = $"Pesho{i}";
                Person person = new Person(id, name);
                persons.Add(person);
            }
            Person[] newPersons = persons.ToArray();
            db = new Database(newPersons);
            int actualCount = db.Count;
            int expectedCount = persons.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}