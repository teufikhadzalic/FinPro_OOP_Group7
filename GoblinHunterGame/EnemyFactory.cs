
namespace GoblinHunterGame
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(string type)
        {
            return type switch
            {
                "Goblin" => new Goblin(),
                "ArcherGoblin" => new ArcherGoblin(),
                "GoblinKing" => new GoblinKing(),
                _ => throw new ArgumentException("Tipe musuh tidak dikenal.")
            };
        }
    }
}
