
using System;
using System.Collections.Generic;

namespace GoblinHunterGame
{
    public class Player
    {
        private static Player _instance;

        public int Health { get; private set; } = 5;
        public int Level { get; private set; } = 1;
        public double FireRate { get; private set; } = 1.0;
        public int Exp { get; private set; } = 0;
        public int Score { get; private set; } = 0;
        public List<string> Inventory { get; private set; } = new List<string>();

        private Player() { }

        public static Player GetInstance()
        {
            if (_instance == null)
                _instance = new Player();

            return _instance;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Console.WriteLine("Game Over! Kamu kalah!");
                Environment.Exit(0);
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"Kesehatan bertambah {amount}. Sekarang: {Health} HP");
        }

        public void GainExp(int amount)
        {
            Exp += amount;
            if (Exp >= 100)
                LevelUp();
        }

        private void LevelUp()
        {
            Level++;
            Exp = 0;
            Health++;
            FireRate += 0.1;
            Console.WriteLine($"Level up! Sekarang Level {Level}, HP: {Health}, Fire Rate: {FireRate}");
        }

        public void AddScore(int amount)
        {
            Score += amount;
            Console.WriteLine($"Skor bertambah {amount}. Skor saat ini: {Score}");
        }

        public void UseItem()
        {
            if (Inventory.Count > 0)
            {
                Console.WriteLine("Menggunakan item dari inventori...");
                Inventory.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Inventori kosong.");
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Health: {Health}, Level: {Level}, Fire Rate: {FireRate}, Score: {Score}");
        }
    }
}
