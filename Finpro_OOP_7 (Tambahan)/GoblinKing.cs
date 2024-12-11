using System;

namespace GoblinHunterGame
{
    public class GoblinKing : Enemy
    {
        public override int AttackPower => 5;
        public override int Health { get; set; } = 10;
        public override int ExpValue => 50;
        public override int ScoreValue => 500;

        public override void Attack(Player player)
        {
            Console.WriteLine("Raja Goblin menyerang dengan kekuatan besar!");
            player.TakeDamage(AttackPower);
        }

        public override void TakeDamage(double damage)
        {
            Health -= (int)damage;
            if (Health <= 0)
                Console.WriteLine("Raja Goblin dikalahkan!");
        }
    }
}
