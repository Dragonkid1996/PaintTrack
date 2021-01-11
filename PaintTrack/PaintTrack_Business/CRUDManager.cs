using System;
using System.Linq;
using System.Collections.Generic;

namespace PaintTrack
{
    public class CRUDManager
    {
        public int ID { get; set; }
        static void Main(string[] args) { }

        public void AddGame(string name, string publisher, string link, string miniNo)
        {
            bool isInt = Int32.TryParse(miniNo, out int result);
            if (!isInt)
                throw new Exception("Mini No is not an integer");

            using(var db = new PaintTrackerContext())
            {
                var newGame = new Game
                {
                    GameName = name,
                    GamePublisher = publisher,
                    GameLink = link,
                    GameMaximumMiniatures = result
                };

                db.Games.Add(newGame);
                db.SaveChanges();
            }
        }

        public void DeleteGame(int gameID)
        {
            using (var db = new PaintTrackerContext())
            {
                var miniList = GetMiniaturesForGame(gameID);
                foreach (var item in miniList)
                {
                    db.Miniatures.Remove(item);
                }
                db.Games.Remove(db.Games.Where(g => g.GameId == gameID).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void AddMiniature(string name, string photoLink, int gameID)
        {
            using(var db = new PaintTrackerContext())
            {
                var newMini = new Miniature
                {
                    MiniName = name,
                    MiniPhoto = photoLink,
                    GameId = gameID
                };

                db.Miniatures.Add(newMini);
                db.SaveChanges();
            }
        }

        public void AddPainted(string id)
        {
            var idToInt = Int32.Parse(id);
            using(var db = new PaintTrackerContext())
            {
                var painted = db.Games.Where(g => g.GameId == idToInt).FirstOrDefault();
                painted.GameMiniaturesPainted += 1;
                db.SaveChanges();
            }
        }

        public List<Game> GetAllGames()
        {
            using(var db = new PaintTrackerContext())
            {
                var games = (from g in db.Games
                select g).ToList();

                return games;
            }
        }

        public List<Miniature> GetMiniaturesForGame(int gameID)
        {
            using(var db = new PaintTrackerContext())
            {
                var minis = (from m in db.Miniatures
                             where m.GameId == gameID
                             select m).ToList();

                return minis;
            }
        }

        public Game GetGameFromName(string name)
        {
            using(var db = new PaintTrackerContext())
            {
                var game = db.Games.Where(g => g.GameName == name).FirstOrDefault();
                return game;
            }
        }
    }
}
