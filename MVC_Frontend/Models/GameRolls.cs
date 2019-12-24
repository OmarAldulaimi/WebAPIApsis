using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apsis_Test.Models
{
    public class GameRolls
    {
        private int frameNbr;
        private int rollOne;
        private int rollTwo;
        private int rollThree;

        public int FrameNbr { get; set; }

        public int RollOne
        {
            get { return rollOne; }   
            set { rollOne = value; }
        }

        public int RollTwo
        {
            get { return rollTwo; }   
            set { rollTwo = value; }
        }

        public int RollThree
        {
            get { return rollThree; }   
            set { rollThree = value; }
        }

    }

}