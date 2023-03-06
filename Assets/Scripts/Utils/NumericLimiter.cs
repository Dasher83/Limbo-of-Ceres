using LimboOfCeres.Scripts.Shared.Interfaces;
using System;


namespace LimboOfCeres.Scripts.Utils
{
    public class NumericLimiter<T> : INumericLimiter<T> where T : IComparable
    {
        public T GetWithinLimits(T unlimitedValue, T minimum, T maximum)
        {
            if (maximum.CompareTo(unlimitedValue) < 0)
            {
                return maximum;
            }

            if (minimum.CompareTo(unlimitedValue) > 0)
            {
                return minimum;
            }

            return unlimitedValue;
        }
    }
}
