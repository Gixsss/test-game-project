using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.Bars.Common
{
    public class DisplayBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        protected void UpdateValue(float currentValue, float maxValue)
        {
            slider.value = currentValue / maxValue;
        }
    }
}