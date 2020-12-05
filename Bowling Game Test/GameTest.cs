using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling_Game_System;

namespace Bowling_Game_Test
{
    [TestClass]
    public class GameTest
    {
        private BowlingRound round;
        [TestInitialize]
        public void Initialize()
        {round = new BowlingRound();
        }

        [TestMethod]
        public void CanRollGutterGame()
        {
            RollMany(0, 20);
            Assert.AreEqual(0, round.Score);
        }

        [TestMethod]
        public void CanRollAllOnes()
        {
            RollMany(2, 20);
            Assert.AreEqual(40, round.Score);
        }

        [TestMethod]
        public void CanRollSpare()
        {
            round.Roll(5);
            round.Roll(5);
            round.Roll(5);
            round.Roll(5);
            round.Roll(3);
            RollMany(1, 15);
            Assert.AreEqual(46, round.Score);
        }

        [TestMethod]
        public void CanRollStrike()
        {
            round.Roll(10);
            round.Roll(3);
            round.Roll(4);
            RollMany(1, 16);
            Assert.AreEqual(40, round.Score);
        }

        [TestMethod]
        public void CanRollPerfectGame()
        {
            //Even in a perfect game the player score 10 strikes, a maximum of 2 rolls will be awarded in the 10th strike frame 
            //since a maximum of 3 rolls can be awarded in the 10th frame.
            RollMany(10, 12);
            Assert.AreEqual(300, round.Score);
        }

        private void RollMany(int pins, int roll)
        {
            for (var i = 0; i < roll; i++)
                round.Roll(pins);
        }
    }
}
