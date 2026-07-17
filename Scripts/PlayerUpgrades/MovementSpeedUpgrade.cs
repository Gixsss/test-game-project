using Entity.Components;
using Entity.Components.Stats;
using PlayerUpgrades.Common;

namespace PlayerUpgrades
{
    public class MovementSpeedUpgrade : Upgrade
    {
        public override void Apply(PlayerStats playerStats)
        {
            playerStats.Speed.AddModifier(new StatModifier(StatType.Speed, 0.2f, StatModifierType.PercentAdditive, this));
        }
    }
}