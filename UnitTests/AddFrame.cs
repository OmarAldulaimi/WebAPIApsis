using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIApsis.Controllers;
using WebAPIApsis.Models;

namespace UnitTests
{
    [TestClass]
    public class AddFrame
    {
        [TestMethod]
        public void AddFrameToGame()
        {
            GameController controller = new GameController();
            try
            {
                controller.AddFrame("c42b7522-3f3a-43bb-a572-bfd437da2817", new Rolls { RollOne = 1, RollTwo = 5 });
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "ID OK");
            }
        }
    }
}
