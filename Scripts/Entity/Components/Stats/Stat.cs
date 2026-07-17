using System.Collections.Generic;
using UnityEngine;

namespace Entity.Components.Stats
{
	public class Stat
	{
		private readonly float _baseValue;
		private readonly List<StatModifier> _modifiers = new();

		public Stat(float baseValue)
		{
			_baseValue = baseValue;
		}

		public void AddModifier(StatModifier modifier)
		{
			_modifiers.Add(modifier);
		}

		public void RemoveModifier(StatModifier modifier)
		{
			_modifiers.Remove(modifier);
		}

		public void RemoveAllFromSource(object source)
		{
			_modifiers.RemoveAll(modifier => modifier.Source == source);
		}

		public float Value
		{
			get
			{
				var finalValue = _baseValue;
				var percentAdditive = 0f;
				foreach (var modifier in _modifiers)
				{
					switch (modifier.Type)
					{
						case StatModifierType.Flat:
							finalValue += modifier.Value;
							break;
						case StatModifierType.PercentAdditive:
							percentAdditive += modifier.Value;
							break;
						case StatModifierType.PercentMultiplicative:
							finalValue *= 1 + modifier.Value;
							break;
						default:
							Debug.LogWarning("Modifier type unknown: " + modifier.Type);
							break;
					}
				}
				finalValue *= 1 + percentAdditive;
				return finalValue;
			}
		}
	}
}