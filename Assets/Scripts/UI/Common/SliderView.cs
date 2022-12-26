using UI.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    [RequireComponent(typeof(Slider))]
    public sealed class SliderView : BarView
    {
        private Slider _slider;
        
        public override void Init(float minValue, float maxValue, float currentValue)
        {
            _slider = GetComponent<Slider>();
            _slider.minValue = minValue;
            _slider.maxValue = maxValue;
            _slider.value = currentValue;
        }

        public override void UpdateValue(float newValue)
        {
            _slider.value = newValue;
        }
    }
}
