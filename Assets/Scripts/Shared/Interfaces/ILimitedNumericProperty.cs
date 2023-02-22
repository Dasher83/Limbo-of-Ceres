using System;

namespace LimboOfCeres.Scripts.Shared.Interfaces
{
    public interface ILimitedNumericProperty<T> where T : IComparable
    {
        T LimitedValue { get; set; }
    }
}
