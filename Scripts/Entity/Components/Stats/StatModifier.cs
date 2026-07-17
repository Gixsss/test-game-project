namespace Entity.Components.Stats
{
	public class StatModifier
	{
		public readonly StatType StatType;
		public readonly float Value;
		public readonly StatModifierType Type;
		public readonly object Source;

		public StatModifier(StatType statType, float value, StatModifierType type, object source = null) // TODO source rather not nullable
		{
			StatType = statType;
			Value = value;
			Type = type;
			Source = source;
		}
	}
}