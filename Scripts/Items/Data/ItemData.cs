using Items.Equipment;
using UnityEngine;

namespace Items.Data
{
	[CreateAssetMenu(menuName = "Items/Item")]
	public class ItemData : ScriptableObject
	{
		public int id;
		public string itemName;
		public Sprite icon;

		[Header("Stacking")]
		public bool stackable = true;
		public int maxStack = 999;

		[Header("Economy")]
		public int value;
		
		[Header("Equipment")]
		public bool isEquipment;
		public EquipmentSlot equipmentSlot;
	}
}