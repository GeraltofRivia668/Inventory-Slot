using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Inventory_Slot
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            var sword = new Item { Name = "Sword" };
            var potion = new Item { Name = "Health Potion" };

           

            var swordSlot = new InventorySlot<Item>(sword, 1);
            var potionSlot = new InventorySlot<Item>(potion, 5);

            swordSlot.AddQuantity(2);
            potionSlot.RemoveQuantity(1);

            Console.WriteLine(swordSlot);
            Console.WriteLine(potionSlot);
        }

        public class Item
        {
            public string Name { get; set; }
           
            public override string ToString() { return Name; }
        }
        public class InventorySlot<T>
        {
            public T Item { get; private set; }
            public int Quantity { get; private set; }

            public InventorySlot(T item, int quantity)
            {
                Item = item;
                Quantity = quantity;
            }
            public void AddQuantity(int amount)
            {
                Quantity += amount;
            }
            public void RemoveQuantity(int amount)
            {
                Quantity -= amount;
                if (Quantity < 0) Quantity = 0;
            }
            public override string ToString()
            {
                return $"{Item} x{Quantity}";
            }
        }
    }
}

