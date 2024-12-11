using System;

namespace GoblinHunterGame
{
    public class Goblin : Enemy
    {
        public override int AttackPower => 1;
        public override int Health { get; set; } = 3;
        public override int ExpValue => 10;
        public override int ScoreValue => 100;

        public override void Attack(Player player)
        {
            Console.WriteLine("Goblin menyerang!");
            player.TakeDamage(AttackPower);
        }

        public override void TakeDamage(double damage)
        {
            Health -= (int)damage;
            if (Health <= 0)
                Console.WriteLine("Goblin dikalahkan!");
        }
    }
}