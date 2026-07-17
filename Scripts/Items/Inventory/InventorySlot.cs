using System;

namespace Items.Inventory
{
	public class InventorySlot
	{
		public Item Item;
		public event Action<Item> OnInventorySlotUpdated;

		public bool IsEmpty => Item is null;

		public void SetItem(Item item)
		{
			Item = item;
			OnInventorySlotUpdated?.Invoke(Item);
		}

		public void ClearItem()
		{
			SetItem(null);
			OnInventorySlotUpdated?.Invoke(Item);
		}

		public void AddAmount(int amount)
		{
			Item.AddAmount(amount);
			OnInventorySlotUpdated?.Invoke(Item);
		}
		
		public void RemoveAmount(int amount)
		{
			Item.RemoveAmount(amount);
			OnInventorySlotUpdated?.Invoke(Item);
		}
	}
}