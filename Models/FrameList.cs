using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIApsis.Models;

namespace WebAPIApsis.Controllers
{
    public class FrameList
    {
        private string id;
        private List<Rolls> rollsList;
        private int score;


        public FrameList()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RollsList = new List<Rolls>();
            this.TotalScore = 0; 

        }
        
    

    public string Id { get { return this.id; } set { this.id = value; } }
    public List<Rolls> RollsList { get { return this.rollsList; } set { this.rollsList = value; } }
    public int TotalScore { get { return this.score; } set { this.score = value; } }
    }
}