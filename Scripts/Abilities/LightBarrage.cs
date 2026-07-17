using System.Collections;
using Abilities.Common;
using Entity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Abilities
{
	[CreateAssetMenu(fileName = "LightBarrage", menuName = "Abilities/LightBarrage")]
	public class LightBarrage : Ability
	{
		[SerializeField] private float projectileSpeed = 5f;
		[SerializeField] private float projectileInterval = 0.2f;
		[SerializeField] private float projectileDamage = 5f;
		[SerializeField] private float projectileSplashArea = 0.5f;

		[SerializeField] private GameObject lightProjectile;
		
		private Coroutine _coroutine;
		private bool _isChanneling;

		public override void Perform(Player player, InputAction.CallbackContext context)
		{	
			if (context.performed)
			{
				StartSkill(player);
			}
			if (context.canceled)
			{
				StopSkill(player);
			}
		}

		private void StartSkill(Player player)
		{
			_isChanneling =  true;
			_coroutine = player.StartCoroutine(LightBarrageCoroutine(player));
		}
		
		private void StopSkill(Player player)
		{
			player.StopCoroutine(_coroutine);
			_isChanneling =  false;
		}
		
		private IEnumerator LightBarrageCoroutine(Player player)
		{
			while (_isChanneling)
			{
				FireLightProjectile(player);
				yield return new WaitForSeconds(projectileInterval);
			}
		}

		private void FireLightProjectile(Player player)
		{
			Instantiate(lightProjectile, player.transform.position, Quaternion.LookRotation(Vector3.forward, Utils.GetMousePosition() - (Vector2) player.transform.position));
		}
	}
}