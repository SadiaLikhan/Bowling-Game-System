using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Bowling_Game_System
{
    public class GameStart
    {
        public Dictionary<string, Dictionary<string, List<string>>> GameRecord= new Dictionary<string, Dictionary<string, List<string>>>();
        public Dictionary<string, List<string>> FramesPlayer1 = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> FramesPlayer2 = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> FramesPlayer3= new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> FramesPlayer4 = new Dictionary<string, List<string>>();

        public void StartGame(Dictionary <string, string[]>PlayersPinInfo)
        {
            int NumberOfPlayer = PlayersPinInfo.Count;
            
            List<string> PlayerNameList = new List<string>();
            
            foreach (KeyValuePair<string, string[]> kvp in PlayersPinInfo)
            {
                PlayerNameList.Add ( kvp.Key);
            }
            string[] PlayerList = PlayerNameList.ToArray();

            int RollIndex = 0;
            for (int i=0; i<10; i++)
            {
                for (int j=0; j< NumberOfPlayer; j++)
                {
                    string[] PinsInRolls = PlayersPinInfo[PlayerList[j]];
                    List<string> Frame = new List<string>();

                    if (Int32.Parse(PinsInRolls[RollIndex]) == 10)
                    {
                        if (i == 9)
                        {
                            IfLastFrameStrike(PinsInRolls, RollIndex, Frame);
                        }
                        else
                        {
                            IfStrike(PinsInRolls, RollIndex, Frame);
                            RollIndex++;
                        }
                    }
                    else if (Int32.Parse(PinsInRolls[RollIndex]) + Int32.Parse(PinsInRolls[RollIndex + 1]) == 10 && i == 9)
                    {
                        IfLastFrameSpare(PinsInRolls, RollIndex, Frame);
                    }
                    else
                    {
                        MakeFrame(PinsInRolls, RollIndex, Frame);
                        RollIndex += 2;
                    }
                    PlayerFrame(i, j, Frame);   
                }
            }
            GameRecordGeneration(PlayerList);
        }

        private void MakeFrame(string[] PinsInRolls, int RollIndex, List<string> Frame)
        {
            Frame.Add(PinsInRolls[RollIndex]);
            Frame.Add(PinsInRolls[RollIndex + 1]);
        }

        private void IfLastFrameSpare(string[] PinsInRolls, int RollIndex, List<string> Frame)
        {
            Frame.Add(PinsInRolls[RollIndex]);
            Frame.Add(PinsInRolls[RollIndex + 1]);
            Frame.Add(PinsInRolls[RollIndex + 2]);
        }

        private void IfStrike(string[] PinsInRolls, int RollIndex, List<string> Frame)
        {
            Frame.Add(PinsInRolls[RollIndex]);
            Frame.Add("Strike");
        }

        private void IfLastFrameStrike(string[] PinsInRolls, int RollIndex, List<string> Frame)
        {
            Frame.Add(PinsInRolls[RollIndex]);
            Frame.Add("Strike");
            Frame.Add(PinsInRolls[RollIndex + 1]);
        }

        private void PlayerFrame(int i, int j, List<string> Frame)
        {
            if(j==0)
            {
                FramesPlayer1.Add(Convert.ToString(i+1), Frame);
            }
            else if (j == 1)
            {
                FramesPlayer2.Add(Convert.ToString(i+1), Frame);
            }
            else if (j == 2)
            {
                FramesPlayer3.Add(Convert.ToString(i+1), Frame);
            }
            else
            {
                FramesPlayer4.Add(Convert.ToString(i+1), Frame);
            }
        }
        
        private void GameRecordGeneration(string[] PlayerList)
        {
            for (int j = 0; j < PlayerList.Length; j++)
            {
                if (j == 0)
                {
                    GameRecord.Add(PlayerList[j], FramesPlayer1);
                }
                else if (j == 1)
                {
                    GameRecord.Add(PlayerList[j], FramesPlayer2);
                }
                else if (j == 2)
                {
                    GameRecord.Add(PlayerList[j], FramesPlayer3);
                }
                else
                {
                    GameRecord.Add(PlayerList[j], FramesPlayer4);
                }
            }
        }
    }
}
