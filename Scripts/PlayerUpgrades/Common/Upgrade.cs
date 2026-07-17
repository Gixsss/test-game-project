using Entity.Components;
using Entity.Components.Stats;

namespace PlayerUpgrades.Common
{
    public abstract class Upgrade
    {
        public string Name;
        public string Description;
        
        public abstract void Apply(PlayerStats playerStats);
    }
}