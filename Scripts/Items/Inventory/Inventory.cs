using UnityEngine;

namespace Items.Inventory
{
	public class Inventory
	{
		private readonly InventorySlot[] _slots = new InventorySlot[36];
		
		public Inventory()
		{
			for (var i = 0; i < _slots.Length; i++) _slots[i] = new InventorySlot();
		}
		
		public InventorySlot GetSlot(int index) => _slots[index];

		public bool AddItem(Item item)
		{
			foreach (var slot in _slots)
			{
				if (!slot.IsEmpty &&
				    slot.Item.Data.id == item.Data.id &&
				    item.Data.stackable &&
				    slot.Item.Amount < item.Data.maxStack)
				{
					slot.AddAmount(item.Amount);
					return true;
				}
			}
			foreach (var slot in _slots)
			{
				if (slot.IsEmpty)
				{
					slot.SetItem(item);
					return true;
				}
			}
			return false;
		}
		
		public bool MoveItem(int fromIndex, int toIndex)
		{
			Debug.Log(fromIndex + " -> " + toIndex);
			var fromItem = _slots[fromIndex].Item;
			var toItem = _slots[toIndex].Item;
			_slots[fromIndex].SetItem(toItem);
			_slots[toIndex].SetItem(fromItem);
			return true;
		}
	}
}