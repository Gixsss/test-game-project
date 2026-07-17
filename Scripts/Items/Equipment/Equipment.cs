using System.Collections.Generic;
using Entity.Components.Stats;

namespace Items.Equipment
{
	public class Equipment
	{
		private Dictionary<EquipmentSlot, EquipmentItem> _equipped = new();
		private PlayerStats _stats;

		public Equipment(PlayerStats stats)
		{
			_stats = stats;
		}

		public EquipmentItem GetItem(EquipmentSlot slot)
		{
			_equipped.TryGetValue(slot, out var item);
			return item;
		}

		public void Equip(EquipmentItem item)
		{
			Unequip(item.Slot);
			_equipped[item.Slot] = item;
			ApplyModifiers(item);
		}

		public void Unequip(EquipmentSlot slot)
		{
			if (!_equipped.TryGetValue(slot, out var item)) return;
			RemoveModifiers(item);
			_equipped.Remove(slot);
		}

		private void ApplyModifiers(EquipmentItem item)
		{
			foreach (var mod in item.Modifiers) ApplyModifierToCorrectStat(mod);
		}

		private void RemoveModifiers(EquipmentItem item)
		{
			foreach (var mod in item.Modifiers) RemoveModifierFromCorrectStat(mod);
		}

		private void ApplyModifierToCorrectStat(StatModifier modifier)
		{
			_stats.Speed.AddModifier(modifier);
		}

		private void RemoveModifierFromCorrectStat(StatModifier modifier)
		{
			_stats.Speed.RemoveModifier(modifier);
		}
	}
}