using System;

namespace GoblinHunterGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = Player.GetInstance();
            Console.WriteLine("Selamat datang di Goblin Hunter!");

            // Ini Tambahan Fitur Pilihan Tingkat Kesulitan
            GameSettings.ChooseDifficulty(); // Memilih tingkat kesulitan

            // Ini Tambahan Fitur Sistem Save dan Load Game
            Console.WriteLine("Apakah Anda ingin melanjutkan permainan dari simpanan? (y/n)");
            var input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                player = GameSaveLoad.LoadGame(); // Memuat game yang disimpan
            }

            while (true)
            { 
                Console.WriteLine("\nPilih aksi: 1. Temui musuh 2. Gunakan item 3. Tampilkan status 4. Lihat High Score");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        EncounterEnemy(player);
                        break;
                    case "2":
                        player.UseItem();
                        break;
                    case "3":
                        player.ShowStatus();
                        break;
                    case "4":
                        ShowHighScore(player);
                        break;
                    // Ini Tambahan Fitur Sistem Save dan Load Game
                    case "5":
                        GameSaveLoad.SaveGame(player); // Menyimpan permainan
                        break;
                    default:
                        Console.WriteLine("Aksi tidak valid.");
                        break;
                }
            }
        }

        static void EncounterEnemy(Player player)
        {
            var enemyType = new Random().Next(3);
            Enemy enemy = enemyType switch
            {
                0 => EnemyFactory.CreateEnemy("Goblin"),
                1 => EnemyFactory.CreateEnemy("ArcherGoblin"),
                _ => EnemyFactory.CreateEnemy("GoblinKing")
            };

            Console.WriteLine($"Anda bertemu dengan {enemy.GetType().Name}!");

            while (enemy.Health > 0)
            {
                enemy.Attack(player);
                Console.WriteLine("Pemain menyerang balik!");
                enemy.TakeDamage(player.FireRate);
                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"Anda mengalahkan {enemy.GetType().Name}!");
                    player.GainExp(enemy.ExpValue);
                    player.AddScore(enemy.ScoreValue);
                }
            }
        }

        static void ShowHighScore(Player player)
        {
            Console.WriteLine($"High Score: {player.Score}");
        }
        
        // Ini Fungsi untuk Tambahan Fitur Leaderboard Skor
        static void ShowHighScore(Player player)
        {
            Leaderboard.ShowLeaderboard();
            Console.WriteLine($"Skor Anda: {player.Score}");
            Leaderboard.SaveScore(player.Score); // Menyimpan skor ke leaderboard setelah setiap game
        }
    }
}