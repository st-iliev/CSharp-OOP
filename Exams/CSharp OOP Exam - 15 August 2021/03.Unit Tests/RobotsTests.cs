namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldCreatenewRobot()
        {
            string expectedName = "Robcho";
            int expectedMaxBattery = 100;
            int currentBattery = 10;
            Robot robot = new Robot("Robcho", 100);
            robot.Battery = 10;
            Assert.AreEqual(expectedName, robot.Name);
            Assert.AreEqual(expectedMaxBattery, robot.MaximumBattery);
            Assert.AreEqual(currentBattery, robot.Battery);
        }
        [Test]
        public void ConstructorShouldCreateNewRobotManager()
        {
            int expectedCapacity = 1;
            int expectedRobots = 0;
            RobotManager robotManager = new RobotManager(1);
            Assert.AreEqual(expectedCapacity, robotManager.Capacity);
            Assert.AreEqual(expectedRobots, robotManager.Count);
        }
        [Test]
        public void ConstructorShouldThrowExceptionWhenCapacityIsBelowZero()
        {

            Assert.Throws<ArgumentException>(() => { RobotManager robotManager = new RobotManager(-2); }, "Invalid capacity!");
        }
        [Test]
        public void ConstructorShouldCreateNewRobotManagerWithZeroCapacity()
        {
            RobotManager robotManager = new RobotManager(0);
            Assert.AreEqual(0, robotManager.Capacity);
            Assert.AreEqual(0, robotManager.Count);
        }
        [Test]
        public void ConstructorShouldCreaterManagerWithProperlyCapacity()
        {
            RobotManager robotManager = new RobotManager(110);
            Assert.AreEqual(110, robotManager.Capacity);
            Assert.AreEqual(0, robotManager.Count);
        }
        [Test]
        public void AddShouldThrowExceptionWhenRobotIsAlreadyAdded()
        {
            Robot robot = new Robot("Robcho", 100);
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => { robotManager.Add(new Robot("Robcho",10)); },"There is already a robot with name Robcho !");
        }
        [Test]
        public void AddShouldThrowExceptionWhenCapacityIsFull()
        {
            Robot robot = new Robot("Robcho", 100);
            Robot robot1 = new Robot("Robcho1", 100);
            Robot robot2 = new Robot("Robcho2", 100);
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(robot);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() => { robotManager.Add(robot2); }, "Not enough capacity!");
        }
        [Test]
        public void AddShouldAddRobotToRobotManager()
        {
            int expectedRobots = 1;
            Robot robot = new Robot("Robcho", 100);
            RobotManager robotManager = new RobotManager(10);
            Assert.AreEqual(0, robotManager.Count);
            robotManager.Add(robot);
            Assert.AreEqual(expectedRobots, robotManager.Count);
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenRobotDoNotExist()
        {
            string name = "Joreto";
            Robot robot = new Robot("Robcho", 100);
            RobotManager robotManager = new RobotManager(1);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => { robotManager.Remove(name); }, $"Robot with the name {name} doesn't exist!"); 
        }
        [Test]
        public void RemoveShouldRemoveRobotsFromRobotManager()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot = new Robot("Robcho", 100);
            Robot robot2 = new Robot("Robcho2", 10);
            robotManager.Add(robot);
            robotManager.Add(robot2);
            Assert.AreEqual(2, robotManager.Count);
            robotManager.Remove("Robcho");
            Assert.AreEqual(1, robotManager.Count);
            robotManager.Remove("Robcho2");
            Assert.AreEqual(0, robotManager.Count);
        }
        [Test]
        public void WorkShouldThrowExceptionWhenRobotDoNotExist()
        {
            string name = "Machiiine";
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Robcho", 100);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => { robotManager.Work(name, "Fight", 100); }, $"Robot with the name {name} doesn't exist!");     
        }
        [Test]
        public void WorkShouldThrowExceptionWhenRobotBatteryIsNotEnough()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Robcho", 150);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => { robotManager.Work("Robcho", "Fight", 200); }, $"{robot.Name} doesn't have enough battery!");
        }
        [Test]
        public void WorkShouldMakeRobotToWork()
        {     
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Robcho", 150);
            robotManager.Add(robot);
            robotManager.Work("Robcho", "Fight", 50);
            Assert.AreEqual(100, robot.Battery);
        }
        [Test]
        public void ChargeShouldThrowExceptionWhenRobotDoNotExist()
        {
            string name = "Peezy";
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Robcho", 150);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => { robotManager.Charge(name); }, $"Robot with the name {name} doesn't exist!");
        }
        [Test]
        public void ChargeShouldFullyChargeBattery()
        {       
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Robcho", 150);
            robot.Battery = 100;
            int expectedBattery = 150;
            robotManager.Add(robot);
            robotManager.Charge("Robcho");
            Assert.AreEqual(expectedBattery, robot.Battery);
            Assert.AreEqual(expectedBattery, robot.MaximumBattery);
        }
        [Test]
        public void ChargeShouldReturnFullCharge()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Robcho", 150);
            int expectedBattery = 150;
            robotManager.Add(robot);
            robotManager.Work("Robcho", "Fight", 100);
            Assert.AreEqual(50, robot.Battery);
            robotManager.Charge("Robcho");
            Assert.AreEqual(expectedBattery, robot.Battery);
            robotManager.Work("Robcho", "Fight", 150);
            Assert.AreEqual(0, robot.Battery);
        }
    }
}

