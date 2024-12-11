// Ini Tambahan Fitur Sistem Save dan Load Game
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GoblinHunterGame
{
    public static class GameSaveLoad
    {
        private static string saveFile = "savegame.dat";

        // Menyimpan status permainan pemain
        public static void SaveGame(Player player)
        {
            using (FileStream fs = new FileStream(saveFile, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, player);
                Console.WriteLine("Game saved successfully!");
            }
        }

        // Memuat status permainan pemain
        public static Player LoadGame()
        {
            if (File.Exists(saveFile))
            {
                using (FileStream fs = new FileStream(saveFile, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Player player = (Player)formatter.Deserialize(fs);
                    Console.WriteLine("Game loaded successfully!");
                    return player;
                }
            }
            else
            {
                Console.WriteLine("No saved game found.");
                return Player.GetInstance(); // Return a new player if no save exists
            }
        }
    }
}
