using System;
using UnityEngine;

namespace Entity.Components
{
    public class Health
    {
        public event Action<float, float> OnHealthChanged;
        public event Action OnDeath;
        
        private const float MinHealth = 0f;
        
        private float _currentHealth = 100f;
        private float _maxHealth = 100f;

        private float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
            }
        }
        
        private float MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
            }
        }
        
        public void Heal(float healedAmount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + healedAmount, MinHealth, MaxHealth);
        }

        public void Damage(float damageDealt, GameObject target)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damageDealt, MinHealth, MaxHealth);
            DamageNumbersSystem.RaiseHealthChangedEvent(new HealthChangeEvent
            {
                HealthChange = (int) damageDealt,
                Target = target
            });
            if (CurrentHealth <= MinHealth)
            {
                OnDeath?.Invoke();
            }
        }
    }
}