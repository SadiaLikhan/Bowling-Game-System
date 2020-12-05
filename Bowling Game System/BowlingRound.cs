using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Bowling_Game_System
{
    public class BowlingRound
    {
        private List<int> pinsInRolls = new List<int>();

        private Dictionary<int, int[]> rollsFrame = new Dictionary<int, int[]>();

        public int[] RollArray
        {
            get
            {
                int[] rollPin = pinsInRolls.ToArray();
                return rollPin;
            }
        }

        public int Score
        {
            get
            {
                int score = 0;
                int RollArrayIndex = 0;
                for (int frame = 0; frame < 10; frame ++)
                {
                    if (IsStrike(RollArrayIndex))
                    {
                        score += GetStrikeScore(RollArrayIndex);
                        RollArrayIndex++;
                    }
                    else if (IsSpare(RollArrayIndex))
                    {
                        score += GetSpareScore(RollArrayIndex);
                        RollArrayIndex +=2;
                    }
                    else
                    {
                        score = GetStandardScore(score, RollArrayIndex);
                        RollArrayIndex +=2;
                    }
                }
                return score;
            }
        }

        public void Roll(int pins)
        {
            pinsInRolls.Add(pins);
        }
        private bool IsSpare(int RollArrayIndex)
        {
            //Spare is when a player knocks down all 10 pins in his two rolls of a frame.
            return RollArray[RollArrayIndex] + RollArray[RollArrayIndex + 1] == 10;
        }
        private bool IsStrike(int RollArrayIndex)
        {
            //Strike is when a player knocks down all 10 pins in his first roll of a frame.
            return RollArray[RollArrayIndex] == 10;
        }
        private int GetStandardScore(int score, int RollArrayIndex)
        {
            score += RollArray[RollArrayIndex] + RollArray[RollArrayIndex + 1];
            return score;
        }
        private int GetSpareScore(int RollArrayIndex)
        {
            //if a player scores a spare the score of the first roll of the next frame will be added with spare frame as a bonus.
            return RollArray[RollArrayIndex] + RollArray[RollArrayIndex + 1] + RollArray[RollArrayIndex + 2];
        }
        private int GetStrikeScore(int RollArrayIndex)
        {
            //if a player scores a strike the score of two rolls of the next frame will be added with spare frame as a bonus.
            return RollArray[RollArrayIndex] + RollArray[RollArrayIndex + 1] + RollArray[RollArrayIndex + 2];
        }

    }
}
