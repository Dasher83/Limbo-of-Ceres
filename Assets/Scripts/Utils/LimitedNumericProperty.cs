using LimboOfCeres.Scripts.Shared.Interfaces;
using System;
using UnityEngine;


namespace LimboOfCeres.Scripts.Utils
{
    [Serializable]
    public class LimitedNumericProperty<T> : ILimitedNumericProperty<T> where T : IComparable
    {
        [SerializeField] private T _value;
        [SerializeField] private T _minimum;
        [SerializeField] private T _maximum;
        private readonly INumericLimiter<T> _numericLimiter;

        private LimitedNumericProperty() {}

        public LimitedNumericProperty(T initialValue, T minimum, T maximum)
        {
            _value = initialValue;
            _minimum = minimum;
            _maximum = maximum;
            _numericLimiter = new NumericLimiter<T>();
        }

        public T LimitedValue {
            get => _numericLimiter.GetWithinLimits(
                unlimitedValue: _value,
                minimum: _minimum, maximum: _maximum);

            set => _value = _numericLimiter.GetWithinLimits(
                unlimitedValue: value,
                minimum: _minimum, maximum: _maximum);
        }
    }
}
