using System;
using TMPro;
using UnityEngine;

public class DamageNumbersSystem : MonoBehaviour
{
	private static event Action<HealthChangeEvent> OnHealthChangedGlobal;

	[SerializeField] private TextMeshPro damagePopup;

	public static void RaiseHealthChangedEvent(HealthChangeEvent healthChangeEvent)
	{
		OnHealthChangedGlobal?.Invoke(healthChangeEvent);
	}

	private void Start()
	{
		OnHealthChangedGlobal += PopupDamage;
	}

	private void PopupDamage(HealthChangeEvent healthChangeEvent)
	{
		damagePopup.text = healthChangeEvent.HealthChange.ToString();
		var damagePopupObject = Instantiate(damagePopup, healthChangeEvent.Target.transform.position, Quaternion.identity);
		Destroy(damagePopupObject.gameObject, 1f);
	}
}