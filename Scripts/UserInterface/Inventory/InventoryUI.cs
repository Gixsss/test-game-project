using UnityEngine;

namespace UserInterface.Inventory
{
	public class InventoryUI : MonoBehaviour
	{
		[SerializeField] private GameObject inventoryPanel;

		public void Start()
		{
			inventoryPanel.SetActive(false);
		}

		public void ToggleInventory()
		{
			inventoryPanel.SetActive(!inventoryPanel.activeSelf);
		}
	}
}