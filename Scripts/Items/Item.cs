using Items.Data;

namespace Items
{
	public class Item
	{
		public readonly ItemData Data;
		public int Amount { get; private set; }

		public Item(ItemData data, int amount = 1)
		{
			Data = data;
			Amount = amount;
		}

		public void AddAmount(int amount) => Amount += amount;
		
		public void RemoveAmount(int amount) => Amount -= amount;
	}
}