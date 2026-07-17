using Entity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Abilities.Common
{
	public abstract class Ability : ScriptableObject
	{
		public abstract void Perform(Player player, InputAction.CallbackContext context);
	}
}