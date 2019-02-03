using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConsoleApplication1;

namespace PlayerTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestPlayerCreate()
        {
            Player player = new Player("Test Player");

            Assert.AreEqual("Test Player", player.Name);
            Assert.AreEqual(player.Position, 1);
        }
        [TestMethod]
        public void TestRollDice()
        {
            Player player = new Player("NewPlayer");

            int dice = player.Roll();
            Assert.IsTrue(dice >= 1 && dice <= 6);

        }
        [TestMethod]
        public void ValidatePlayerMovement()
        {
            Player player = new Player("Player1");
            Dictionary<int, int> SnakeAndLadder = new Dictionary<int, int>();
            Elements board = new Elements(SnakeAndLadder);
            Boolean status = false;
            status = player.Update(6,SnakeAndLadder);

            Assert.AreEqual(7, player.Position);
        }

        [TestMethod]
        public void ValidatePlayerWin()
        {
            Player player = new Player("Player1");
            player.Position = 95;
            int dice = 5;
            Dictionary<int, int> SnakeAndLadder = new Dictionary<int, int>();
            Elements board = new Elements(SnakeAndLadder);
            bool status = false;
            status = player.Update(dice, SnakeAndLadder);

            Assert.IsTrue(status);

        }

        [TestMethod]
        public void ValidatePlayerUpTheLadder()
        {
            Player player = new Player("player");
            player.Position = 65;
            int dice = 5;
            bool status = false;
            Dictionary<int, int> SnakeAndLadder = new Dictionary<int, int>();
            Elements board = new Elements(SnakeAndLadder);
            status = player.Update(dice, SnakeAndLadder);

            Assert.AreEqual(player.Position, 89);
        }

        [TestMethod]
        public void ValidatePlayerDownSnake()
        {
            Player player = new Player("player");
            player.Position = 90;
            int dice = 2;
            bool status = false;
            Dictionary<int, int> SnakeAndLadder = new Dictionary<int, int>();
            Elements board = new Elements(SnakeAndLadder);
            status = player.Update(dice, SnakeAndLadder);

            Assert.AreEqual(player.Position, 35);
        }

        [TestMethod]
        public void ValidatePlayerNoMove()
        {
            Player player = new Player("player");
            player.Position = 96;
            int dice = 5;
            bool status = false;
            Dictionary<int, int> SnakeAndLadder = new Dictionary<int, int>();
            Elements board = new Elements(SnakeAndLadder);
            status = player.Update(dice, SnakeAndLadder);

            Assert.AreEqual(player.Position, 96);
        }

    }
}
