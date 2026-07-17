using Abilities.Common;
using Entity.Common;
using Entity.Components;
using Entity.Components.Stats;
using Items.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using UserInterface;

namespace Entity
{
    public class Player : DamageableEntity
    {
        private static readonly int IsWalking = Animator.StringToHash("isWalking");

        public readonly PlayerStats Stats = new();
        public readonly Experience Experience = new();
        public readonly Inventory Inventory = new();
        
        [Header("Components")]
        [SerializeField] private Animator animator;
        [SerializeField] public Rigidbody2D playerRigidbody;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        [Header("Abilities")]
        [SerializeField] private Ability autoAttack;
        [SerializeField] private Ability movementAbility;
        [SerializeField] private Ability ability1;
        [SerializeField] private Ability ability2;
        [SerializeField] private Ability ability3;
        
        public void OnMove(InputAction.CallbackContext context)
        {
            var movement = context.ReadValue<Vector2>();
            var isWalking = movement.magnitude > 0;
            animator.SetBool(IsWalking, isWalking);
            if (isWalking)
            {
                spriteRenderer.flipX = movement.x < 0;
            }
            playerRigidbody.linearVelocity = movement * Stats.Speed.Value;
        }
        
        public void OnMovementAbility(InputAction.CallbackContext context)
        {
            movementAbility?.Perform(this, context);
        }

        public void OnAutoAttack(InputAction.CallbackContext context)
        {
            autoAttack?.Perform(this, context);
        }

        public void OnAbility1(InputAction.CallbackContext context)
        {
            ability1?.Perform(this, context);
        }
        
        public void OnAbility2(InputAction.CallbackContext context)
        {
            ability2?.Perform(this, context);
        }
        
        public void OnAbility3(InputAction.CallbackContext context)
        {
            ability3?.Perform(this, context);
        }
        
        public void OnInventory(InputAction.CallbackContext context)
        {
            if (context.performed) UIManager.Instance.inventoryUI.ToggleInventory();
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            if (context.performed) UIManager.Instance.pauseMenuUI.PauseGame();
        }
    }
}
