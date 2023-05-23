using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ZooManagementSystem;

namespace ZooManagement.Tests
{
    [TestClass]
    public class ZooManagementTests
    {
        [TestMethod]
        public void ZooIsOpened()
        {
            //Arrange
            VisitigSchedule visitigSchedule = new(DayOfWeek.Tuesday, DateTime.Now);

            //Act
            bool IsOpen = visitigSchedule.ZooSchedule();
            
            //Assert
            Assert.IsTrue(IsOpen);
        }

        [TestMethod]
        public void ZooIsClosedOnMonday()
        {
            //Arrange
            VisitigSchedule visitigSchedule = new(DayOfWeek.Monday, DateTime.Now);

            //Act
            bool IsOpen = visitigSchedule.ZooSchedule();

            //Assert
            Assert.IsFalse(IsOpen);
        }

        [TestMethod]
        public void AnimlasAreFed()
        {
            //Arrange
            Animal elephant = new("Elephant", "Dumbo", "Veggies", ConsoleColor.Blue);
            elephant.Greet();
            Animal giraffe = new("Giraffe", "Mellaman", "Leaves", ConsoleColor.DarkYellow);
            giraffe.Greet();
            Animal panther = new("Panther", "Baaghera", "Meat", ConsoleColor.Red);
            panther.Greet();

            List<Animal> animalList = new()
            {
                elephant,
                giraffe,
                panther
            };
            Caretaker caretaker = new("Mark", animalList);
            
            //Act
            caretaker.FeedAnimals();
            
            //Assert
            foreach (Animal a in caretaker.animalList)
            {
                Assert.IsTrue(a.IsFed);
            }
        }
    }
}