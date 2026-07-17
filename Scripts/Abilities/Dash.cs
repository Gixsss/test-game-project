using System.Collections;
using Abilities.Common;
using Entity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Abilities
{
    [CreateAssetMenu(fileName = "Dash", menuName = "Abilities/Dash")]
    public class Dash : Ability
    {
        [SerializeField] private float dashTime = 0.2f;
        [SerializeField] private float dashDistance = 5f;

        public override void Perform(Player player, InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                player.StartCoroutine(DashCoroutine(player));
            }
        }

        private IEnumerator DashCoroutine(Player player)
        {
            var normalizedDirection = (Utils.GetMousePosition() - (Vector2) player.transform.position).normalized;
            Vector2 startLocation = player.transform.position;
            var targetLocation = startLocation + normalizedDirection * dashDistance;
            var currentTime = 0f;
            while (currentTime < dashTime)
            {
                var t =  currentTime / dashTime;
                player.playerRigidbody.MovePosition(Vector2.Lerp(startLocation, targetLocation, t));
                currentTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}