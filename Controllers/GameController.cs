using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIApsis.Models;

namespace WebAPIApsis.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GameController : ApiController
    {
        private GameLogic gameLogic;
        private GameLogs gameLogs;
        private FrameList frameList;
        private string request = "";
        private string response;
        private int score = 0;
        private int frames = 0;



        [Route("~/api/AddFrame")]
        [HttpPost]
        public HttpResponseMessage AddFrame(string id, [FromBody]Rolls frame)
        {
            gameLogic = new GameLogic();
            gameLogs = new GameLogs();

            if (frame == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No Input");
            frameList= gameLogs.GameId(id);
            if (frameList == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Please create a game first!");

            try
            {
               gameLogic.ControllInput(frame);
               frameList.RollsList.Add(frame);
               AddRollsFrame(frame);
            }         
           
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            gameLogs.SaveLogs();

            return Request.CreateResponse(HttpStatusCode.Created, frameList);
        }

        public void AddRollsFrame(Rolls frame)
        {
            if (frameList.RollsList.Count == 10)
                throw new Exception("Game over");
        
            for (int i = 0; i < frameList.RollsList.Count; i++)
            {

                if (frameList.RollsList[i].RollOne == 10 && i != frames - 1)
                { 
                    score += frameList.RollsList[i].RollOne + gameLogic.Strike(i, frameList);
                }
                else if (frameList.RollsList[i].RollOne + frameList.RollsList[i].RollTwo == 10 && i != frames - 1) { 
                    score += frameList.RollsList[i].RollOne + frameList.RollsList[i].RollTwo + gameLogic.Spare(i, frameList);
                }
                else
                {
                    score += frameList.RollsList[i].RollOne + frameList.RollsList[i].RollTwo + frameList.RollsList[i].RollThree;
                }
                frameList.RollsList[i].TotalScore = score;
            }
            frameList.TotalScore = score;

        }

        //generate an API key to each game
        [Route("~/api/AddGame")]
        [HttpPost]
        public HttpResponseMessage AddGame()
        {
            gameLogs = new GameLogs();
  
            try
            {
             frameList = gameLogs.AddNewGame();
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }

            var responseMessage = Request.CreateResponse(HttpStatusCode.Created, frameList);

            for (var i = 0; i < Request.RequestUri.Segments.Length - 1; i++)
            {
                request += Request.RequestUri.Segments[i];
            }

            response = Request.RequestUri.Scheme + "://" + Request.RequestUri.Authority + request + frameList.Id;

            responseMessage.Headers.Location = new Uri(response);
            return responseMessage;
        }
    }
}
