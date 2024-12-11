using System;
using System.Collections.Generic;

namespace GoblinHunterGame
{
    public class Inventory
    {
        private List<string> items = new List<string>();

        public void AddItem(string item)
        {
            items.Add(item);
            Console.WriteLine($"Item {item} ditambahkan ke inventori.");
        }

        public void GetItemList()
        {
            Console.WriteLine("Item di inventori:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item}");
            }
        }

        public void UseItem(Player player, string item)
        {
            if (items.Contains(item))
            {
                Console.WriteLine($"Menggunakan {item} dari inventori.");
                items.Remove(item);

                switch (item)
                {
                    case "Potion Heal":
                        player.Heal(3);
                        break;
                    default:
                        Console.WriteLine("Item tidak dikenal.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Item tidak tersedia di inventori.");
            }
        }
    }
}