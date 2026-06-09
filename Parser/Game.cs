using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Parser
{
    public class Game
    {
        public Player Player { get; set; }
        public List<Room> rooms { get; set; }

        public Game()
        {

        }

        public Game(Player p)
        {

            this.Player = p;
            this.rooms = new List<Room>();

            Room start = new Room();

            Item k = new Item();
            k.types.Add(ItemType.key);
            k.Name = "a big iron key";
            k.KeyId = 421;

            Item c = new Item();
            c.types.Add(ItemType.lockable);
            c.Name = "a small wooden chest";
            c.KeyId = 42;

            p.inventory.Add(k);
            p.inventory.Add(c);

            start.player = p;
            p.location = start;
            start.npcs.Add(new Dog());
            start.npcs.Add(new Dog());
            start.npcs.Add(new Dog());

            start.description = "It's a vast empty void? Huh.";

            this.rooms.Add(start);

            Room east = new Room();
            east.description = "It's still very empty here...";
            
            this.rooms.Add(east);

            start.east = east;
            east.west = start;

            Room eastAgain = new Room();
            eastAgain.description = "Hey... haven't you already been here?";

            this.rooms.Add(eastAgain);

            east.east = eastAgain;
            eastAgain.west = east;

        }

        public Game load()
        {
            if (this.Player.Name is null)
            {
                throw new PlayerNotFoundException("Player name is invalid!");
            }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, "MyRpg");
            path = Path.Combine(path, this.Player.Name);
            path = Path.Combine(path, "save.json");

            if(!File.Exists(path))
            {
                throw new PlayerNotFoundException("No such player.");
            }

            string jsondata;

            using(StreamReader sr = new StreamReader(path))
            {
                jsondata = sr.ReadToEnd();
            }

            //Console.WriteLine(jsondata);

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true,
                IncludeFields = true
            };

            Game? game = JsonSerializer.Deserialize<Game>(jsondata, options);

            if (game is null)
            {
                throw new Exception("Sad face it failed.");
            }
            else
            {
                return game;
            }
        }
        
        public void save()
        {
            //Console.WriteLine(this.Player.Name);

            if(this.Player.Name is null)
            {
                throw new Exception("Player name is invalid!");
            }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            path = Path.Combine(path, "MyRpg");

            if(!Directory.Exists(path))
            {
                //Console.WriteLine("Path did not exist... creating directory...");
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, this.Player.Name);
            if (!Directory.Exists(path))
            {
                //Console.WriteLine("path for " + this.Player.Name + " did not exist. creating.");
                Directory.CreateDirectory(path);
            }
            Console.WriteLine(path);

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true,
                IncludeFields = true
            };

            var jsondata = JsonSerializer.Serialize(this, options);

            using (StreamWriter sw = new StreamWriter(Path.Combine(path, "save.json")))
            {
                sw.Write(jsondata);
            }

        }
    }
}
