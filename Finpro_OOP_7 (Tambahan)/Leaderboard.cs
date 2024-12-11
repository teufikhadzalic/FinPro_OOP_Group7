// Ini Tambahan Fitur Leaderboard Skor
using System;
using System.Collections.Generic;
using System.IO;

namespace GoblinHunterGame
{
    public static class Leaderboard
    {
        private static string leaderboardFile = "leaderboard.txt";

        // Method untuk membaca skor tertinggi dari file
        public static List<int> LoadLeaderboard()
        {
            List<int> scores = new List<int>();
            if (File.Exists(leaderboardFile))
            {
                var lines = File.ReadAllLines(leaderboardFile);
                foreach (var line in lines)
                {
                    if (int.TryParse(line, out int score))
                    {
                        scores.Add(score);
                    }
                }
            }
            return scores;
        }

        // Method untuk menyimpan skor tertinggi ke dalam file
        public static void SaveScore(int score)
        {
            var scores = LoadLeaderboard();
            scores.Add(score);
            scores.Sort((a, b) => b.CompareTo(a)); // Sorting descending

            // Menyimpan hanya 5 skor tertinggi
            if (scores.Count > 5) scores = scores.GetRange(0, 5);

            File.WriteAllLines(leaderboardFile, scores.ConvertAll(s => s.ToString()));
        }

        // Method untuk menampilkan leaderboard
        public static void ShowLeaderboard()
        {
            var scores = LoadLeaderboard();
            Console.WriteLine("Leaderboard:");
            foreach (var score in scores)
            {
                Console.WriteLine($"- {score} Skor");
            }
        }
    }
}