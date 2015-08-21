using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Shortcuts
{
    static class SteamDB
    {
        private static List<SteamGame> games;

        public static List<SteamGame> GetGames()
        {
            if (games != null) return games;

            games = new List<SteamGame>();

            foreach (string manifestFile in Directory.GetFiles(Properties.Settings.Default.steamDir + "steamapps", "appmanifest_*.acf"))
            {
                Dictionary<string, object> gameManifest = (Dictionary<string, object>)KeyValues.ReadFile(manifestFile)["AppState"];
                
                games.Add(new SteamGame(
                    int.Parse((string)gameManifest["appid"]), 
                    (string)gameManifest["name"], 
                    (string)gameManifest["installdir"]));
            }

            return games;
        }
    }
}
