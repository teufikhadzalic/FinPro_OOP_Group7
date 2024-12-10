
namespace GoblinHunterGame
{
    public abstract class Enemy
    {
        public abstract int AttackPower { get; }
        public abstract int Health { get; set; }
        public abstract int ExpValue { get; }
        public abstract int ScoreValue { get; }

        public abstract void Attack(Player player);
        public abstract void TakeDamage(double damage);
    }
}
