using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIApsis.Models;

namespace UnitTests
{
    [TestClass]
    public class GameIdTest
    {
        [TestMethod]
        public void Test_if_ID_Exist()
        {
            GameLogs gameLogs = new GameLogs();
            try
            {
                gameLogs.GameId("c42b7522-3f3a-43bb-a572-bfd437da2817");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "ID OK");
            }
        }

        [TestMethod]
        public void Test_if_ID_Exist_not_exist()
        {

            GameLogs gameLogs = new GameLogs();
            try
            {
                gameLogs.GameId("c42b7522-3f3a-43bb-a572-xxxxxxxxx");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "no ID found");
            }
        }
    }
}
