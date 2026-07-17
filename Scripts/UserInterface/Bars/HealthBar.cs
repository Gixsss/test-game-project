using Entity;
using Entity.Common;
using UnityEngine;
using UserInterface.Bars.Common;

namespace UserInterface.Bars
{
    public class HealthBar : DisplayBar
    {
        [SerializeField] private DamageableEntity damageableEntity;

        public void Initialize(DamageableEntity initializedDamageableEntity)
        {
            damageableEntity = initializedDamageableEntity;
        }
        
        private void Start()
        {
            damageableEntity.Health.OnHealthChanged += UpdateValue;
        }
    }
}
