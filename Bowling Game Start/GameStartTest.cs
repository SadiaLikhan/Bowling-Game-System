using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling_Game_System;
using System.Collections.Generic;

namespace Bowling_Game_Start
{
    [TestClass]
    public class GameStartTest
    {
        private BowlingGame game;
        private BowlingRound round;
        private GameStart start;
        
        [TestInitialize]
        public void Initialize()
        {
            game = new BowlingGame();
            round = new BowlingRound();
            start = new GameStart();
        }
        [TestMethod]
        public void CheckPlayerName()
        {
            InitiateNumberofPlayer(2);
            PlayerName("Sadia");
            PlayerName("Rupok");
            string[] check = {"Sadia", "Rupok" };
            CollectionAssert.AreEqual(check, game.PlayerList(2));
        }

        [TestMethod]
        public void CheckPlayerRecord()
        {
            PlayerName("Sadia");
            InitiateNumberofPlayer(1);
            string[] pinRecord = {"5", "5", "6", "3", "5", "4", "4", "3", "6", "3", "8", "1", "7", "2", "5", "2", "4", "4", "6", "1"};
            PlayerGameRecord(pinRecord);
            CollectionAssert.AreEqual(pinRecord, game.GeneratePlayerRecord()["Sadia"]);
        }

        [DataRow]
        public void InitiateNumberofPlayer(int TotalPlayer)
        {
            game.PlayerList(TotalPlayer);
        }
        [DataRow]
        public void PlayerName(string Name)
        {
            game.PlayerName(Name);
        }

        [DataRow]
        public void PlayerGameRecord(string[] PlayerPinsRecord)
        {
            for (int i=0; i< PlayerPinsRecord.Length; i++)
            {
                game.PlayerRoll(PlayerPinsRecord[i]);
            }
        }
        [TestMethod]
        public Dictionary<string, string[]> GeneratePlayersPinHistory()
        {
            //PlayerName("Sadia");
            InitiateNumberofPlayer(1);
            string[] pinRecord = { "5", "5", "6", "3", "5", "4", "4", "3", "6", "3", "8", "1", "7", "2", "5", "2", "4", "4", "6", "1"};
            Dictionary<string, string[]> PlayersPinRecord = new Dictionary<string, string[]>();
            PlayersPinRecord.Add("Sadia", pinRecord);
            return PlayersPinRecord;
        }

        [TestMethod]
        public void StartGaming()
        {
            Dictionary<string, string[]> PlayersPinHistory = GeneratePlayersPinHistory();
            start.StartGame(PlayersPinHistory);
            List<string> Frame = new List<string>() { "6", "1" };
            Dictionary<string, List<string>> check = start.FramesPlayer1;
            CollectionAssert.AreEqual(Frame, start.FramesPlayer1["10"]);
            CollectionAssert.AreEqual(check, start.GameRecord["Sadia"]);

        }       
}
}
