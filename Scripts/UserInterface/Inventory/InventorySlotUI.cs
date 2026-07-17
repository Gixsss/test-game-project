using Entity;
using Items;
using Items.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UserInterface.Inventory
{
	public class InventorySlotUI : MonoBehaviour, IDropHandler
	{
		private Player _player;
		private InventorySlot _inventorySlot;
		
		[SerializeField] private int slotIndex;
		[SerializeField] private Image image;
		[SerializeField] private TextMeshProUGUI textMeshPro;
		
		public void Start()
		{
			_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
			_inventorySlot = _player.Inventory.GetSlot(slotIndex);
			image.enabled = false;
			textMeshPro.enabled = false;
			_inventorySlot.OnInventorySlotUpdated += UpdateUI;
		}

		private void UpdateUI(Item item)
		{
			var itemHasAmount = item is { Amount: > 0 };
			textMeshPro.text = itemHasAmount ? item.Amount.ToString() : "";
			textMeshPro.enabled = itemHasAmount;
			image.sprite = item?.Data.icon;
			image.enabled = itemHasAmount; // TODO when amount goes to 0, remove item from inventory (so it doesn't stay empty in UI)
		}

		public void OnDrop(PointerEventData eventData)
		{
			var sourceDraggableItem = eventData.pointerDrag.GetComponentInParent<DraggableItem>();
			var sourceInventorySlotUI = sourceDraggableItem.originalParent.GetComponent<InventorySlotUI>();
			_player.Inventory.MoveItem(sourceInventorySlotUI.slotIndex, slotIndex);
		}
	}
}