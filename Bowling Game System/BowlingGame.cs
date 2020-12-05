using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Bowling_Game_System
{
    public class BowlingGame
    {
        private List<string>playerNameList= new List<string>();
        private List<string> playerPinsInRolls = new List<string>();
        private Dictionary<string,string[]> playerRecord = new Dictionary<string, string[]>();
        public void PlayerName(string Name)
        {
            playerNameList.Add(Name);
        }
        public string[] PlayerList(int TotalPlayer)
        {
            string[] PlayerSet = new string[TotalPlayer-1];
            PlayerSet = playerNameList.ToArray();
            return PlayerSet;
        }

        public void PlayerRoll(string pins)
        {
            playerPinsInRolls.Add(pins);
        }

        public Dictionary<string, string[]>GeneratePlayerRecord()
        {
            string[] PlayerSet = playerNameList.ToArray();
            string[] PinRecord = playerPinsInRolls.ToArray();
            for(int i=0; i< PlayerSet.Length; i++)
            {
                    playerRecord.Add(PlayerSet[i], PinRecord);
            }
            return playerRecord;
        }

    }
}
