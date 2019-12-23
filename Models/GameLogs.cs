using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using WebAPIApsis.Controllers;

namespace WebAPIApsis.Models
{
    public class GameLogs
    {
        private List<FrameList> games;
        private string stringPath;

        public GameLogs()
        {
            this.stringPath = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), @"bowlingRecords.json")).LocalPath;
            using (StreamReader r = new StreamReader(stringPath))
            {
                string json = r.ReadToEnd();
                if (json != "")
                    games = JsonConvert.DeserializeObject<List<FrameList>>(json);
                else
                    games = new List<FrameList>();
            }
        }

  public FrameList GameId(string id)
        {
            return games.Find(x => x.Id == id);
        }

        public FrameList AddNewGame()
        {
            var game = new FrameList();
            this.games.Add(game);

            SaveLogs();

            return game;
        }

        public void SaveLogs()
        {
            using (StreamWriter file = File.CreateText(stringPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this.games);
            }
        }
    }
}