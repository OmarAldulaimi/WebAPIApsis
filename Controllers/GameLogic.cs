using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIApsis.Models;

namespace WebAPIApsis.Controllers
{
    public class GameLogic
    {
        private FrameList frameList;
        private int frame = 0;

  
        public void ControllInput(Rolls frame)
        {
            if (frame.RollOne  < 0 || frame.RollOne > 10)
                throw new ArgumentException("The number should be between 0 - 10");
            if (frame.RollTwo < 0 || frame.RollTwo > 10)
                throw new ArgumentException("The number should be between 0 - 10");
            if (frame.RollOne + frame.RollTwo > 10 && frameList.RollsList.Count < 9)
                throw new ArgumentException("Only 10 pins!");
            if (frame.RollOne + frame.RollTwo > 10 && frame.RollOne != 10)
                throw new ArgumentException("Out of range");
        }

        public int Strike(int i, FrameList frameList)
        {
            var score = 0;
            try
            {
                var next = frameList.RollsList[i + 1];
                if (i == frame - 2)
                {
                    score += next.RollOne + next.RollTwo;
                }
                else if (next.RollOne == 10)
                {
                    score += next.RollOne;
                    score += frameList.RollsList[i + 2].RollOne;
                }
                else
                    score += next.RollOne + next.RollTwo;

            }
            catch (Exception e)
            {
                return score;
            }

            return score;
        }

       public int Spare(int i, FrameList frameList)
        {
            var score = 0;

            try
            {
                var next = frameList.RollsList[i + 1];
                score += next.RollOne;

            }
            catch (Exception e)
            {
                return score;
            }

            return score;
        }
    }
}