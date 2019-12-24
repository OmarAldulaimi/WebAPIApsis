using System;
using WebAPIApsis.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIApsis.Controllers;

namespace UnitTests
{
    [TestClass]
    public class InputTest
    {
        [TestMethod]
        public void ValidInput()
        {
            var gameLogic = new GameLogic();
            try { 
           gameLogic.ControllInput(new Rolls { RollOne = 1 });
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "not valid");
            }
        }
        [TestMethod]
        public void InValidInput()
        {
            var gameLogic = new GameLogic();
            try
            {
                gameLogic.ControllInput(new Rolls { RollOne = 11 });
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "not valid");
            }


        }
    }
}
