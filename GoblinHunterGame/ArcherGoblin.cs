
using System;

namespace GoblinHunterGame
{
    public class ArcherGoblin : Enemy
    {
        public override int AttackPower => 2;
        public override int Health { get; set; } = 5;
        public override int ExpValue => 15;
        public override int ScoreValue => 150;

        public override void Attack(Player player)
        {
            Console.WriteLine("Goblin Pemanah menyerang dari jauh!");
            player.TakeDamage(AttackPower);
        }

        public override void TakeDamage(double damage)
        {
            Health -= (int)damage;
            if (Health <= 0)
                Console.WriteLine("Goblin Pemanah dikalahkan!");
        }
    }
}
