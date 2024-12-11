// Ini Tambahan Fitur Pilihan Tingkat Kesulitan
namespace GoblinHunterGame
{
    public enum Difficulty { Easy, Medium, Hard }

    public class GameSettings
    {
        public static Difficulty CurrentDifficulty { get; set; }

        public static void ChooseDifficulty()
        {
            Console.WriteLine("Pilih tingkat kesulitan: 1. Mudah 2. Sedang 3. Sulit");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CurrentDifficulty = Difficulty.Easy;
                    break;
                case "2":
                    CurrentDifficulty = Difficulty.Medium;
                    break;
                case "3":
                    CurrentDifficulty = Difficulty.Hard;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid, memilih Mudah secara default.");
                    break;
            }

            Console.WriteLine($"Tingkat kesulitan: {CurrentDifficulty}");
        }
    }

    public class Enemy
    {
        public virtual int AttackPower => 1;
        public virtual int Health { get; set; } = 3;
        public virtual int ExpValue => 10;
        public virtual int ScoreValue => 100;

        // Menyesuaikan Health berdasarkan tingkat kesulitan
        public void AdjustForDifficulty()
        {
            switch (GameSettings.CurrentDifficulty)
            {
                case Difficulty.Easy:
                    Health = (int)(Health * 0.8); // Mengurangi Health untuk tingkat kesulitan mudah
                    break;
                case Difficulty.Medium:
                    break; // Tidak ada perubahan untuk tingkat kesulitan sedang
                case Difficulty.Hard:
                    Health = (int)(Health * 1.5); // Meningkatkan Health untuk tingkat kesulitan sulit
                    AttackPower = (int)(AttackPower * 1.5); // Meningkatkan serangan untuk tingkat kesulitan sulit
                    break;
            }
        }
    }
}
