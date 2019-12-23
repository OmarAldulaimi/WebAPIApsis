using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApsis.Models
{
    public class Rolls
    {
       
        private int frameNbr;
        private int rollOne;
        private int rollTwo;
        private int rollThree;
        private int totalScore;
        public bool IsSpare
        {
            get
            {
                return RollOne != 10 && RollOne + RollTwo == 10;
            }

        }
        public bool IsStrike
        {
            get
            {
                return RollOne == 10;
            }
        }


        public Rolls(int frameNbr, int rollOne, int rollTwo)
        {
            this.frameNbr = frameNbr;
            this.rollOne = rollOne;
            this.rollTwo = rollTwo;
        }

        public Rolls(int frameNr, int rollOne, int rollTwo, int rollThree)
        {
            this.frameNbr = frameNr;
            this.rollOne = rollOne;
            this.rollTwo = rollTwo;
            this.rollThree = rollThree;
        }

        public Rolls() { }

        public int FrameNbr
        {
            get { return frameNbr; }
            set { frameNbr = value; }
        }

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
        public int TotalScore
        {
            get { return totalScore; }
            set { totalScore = value; }
        }
    }
}