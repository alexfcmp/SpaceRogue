using System;

namespace Utilities.Reactive.SubscriptionProperty
{
    public sealed class SubscribedProperty<TValue> : ISubscribedProperty<TValue>
    {
        private TValue _value;
        private Action<TValue> _onValueChange;

        public TValue Value
        {
            get => _value;
            set
            {
                _value = value;
                _onValueChange?.Invoke(_value);
            }
        }
        
        public SubscribedProperty() {}
        public SubscribedProperty(TValue value) => _value = value;

        public void Subscribe(Action<TValue> onChangeCallback) => 
            _onValueChange += onChangeCallback;

        public void Unsubscribe(Action<TValue> onChangeCallback) => 
            _onValueChange -= onChangeCallback;
    }
}