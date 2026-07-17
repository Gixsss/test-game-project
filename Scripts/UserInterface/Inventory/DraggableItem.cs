using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UserInterface.Inventory
{
	public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[SerializeField] private Image image;
		[HideInInspector] public Transform originalParent;
		
		public void OnBeginDrag(PointerEventData eventData)
		{
			originalParent = transform.parent;
			transform.SetParent(transform.root);
			transform.SetAsLastSibling();
			image.raycastTarget = false;
		}

		public void OnDrag(PointerEventData eventData)
		{
			transform.position = eventData.position;
			//Debug.Log("hovering over: " + eventData.pointerEnter?.GetComponentInParent<InventorySlotUI>());
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			transform.SetParent(originalParent);
			image.raycastTarget = true;
		}
	}
}