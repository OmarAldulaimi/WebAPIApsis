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

        public void AddRollsFrame(Rolls frame)
        {
            frameList = new FrameList();
            if (frameList.RollsList.Count == 10)
                throw new Exception("Game over");

            frameList.RollsList.Add(frame);

            
        }


    }
}