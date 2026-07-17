using System.Collections.Generic;
using Entity.Components.Stats;
using Items.Data;

namespace Items.Equipment
{
	public class EquipmentItem
	{
		public ItemData Data { get; }
		public EquipmentSlot Slot => Data.equipmentSlot;
		public List<StatModifier> Modifiers { get; } = new();

		public EquipmentItem(ItemData data)
		{
			Data = data;
		}
	}
}