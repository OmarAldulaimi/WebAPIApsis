using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIApsis.Models;

namespace WebAPIApsis.Controllers
{
    public class GameLogic
    {
        private FrameList frameList = new FrameList();
        private int score = 0;



        public void ControllInput(Rolls frame)
        {
            if (frame.RollOne  < 0 || frame.RollOne > 10)
                throw new ArgumentException("The number should be between 0 - 10");
            if (frame.RollTwo < 0 || frame.RollTwo > 10)
                throw new ArgumentException("The number should be between 0 - 10");
            if (frame.RollThree < 0 || frame.RollThree > 10)
                throw new ArgumentException("The number should be between 0 - 10");
            if (frame.RollOne + frame.RollTwo > 10)
                throw new ArgumentException("Roll 1 and 2 should be 10");      
        }

 

        public int Strike(int i, FrameList frameList)
        {
            try
            {
                score += frameList.RollsList[i + 1].RollOne + frameList.RollsList[i + 1].RollTwo + frameList.RollsList[i + 2].RollOne + frameList.RollsList[i + 2].RollTwo;
            }
            catch (Exception e)
            {
                return score;
            }

            return score;
        }

       public int Spare(int i, FrameList frameList)
        {
            
            try
            {
                score += frameList.RollsList[i + 1].RollOne;
            }
            catch (Exception e)
            {
                return score;
            }

            return score;
        }
    }
}