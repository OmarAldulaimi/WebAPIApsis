using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApsis.Models;

namespace WebAPIApsis.Controllers
{
    public class GameController : ApiController
    {
        private GameLogic gameLogic;
        private GameLogs gameLogs;
        private FrameList frameList;
        private string request = "";
        private string response;

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
                gameLogic.AddRollsFrame(frame);
                frameList.RollsList.Add(frame);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            gameLogs.SaveLogs();

            return Request.CreateResponse(HttpStatusCode.Created, frameList);
        }

        [Route("~/api/AddGame")]
        [HttpPost]
        public HttpResponseMessage AddGame()
        {
            gameLogs = new GameLogs();
            gameLogic = new GameLogic();
            

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
