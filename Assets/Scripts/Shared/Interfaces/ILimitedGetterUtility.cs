using System;


namespace LimboOfCeres.Scripts.Shared.Interfaces
{
    public interface ILimitedGetterUtility<T> where T : IComparable
    {
        T GetWithinLimits(T unlimitedValue, T minimum, T maximum);
    }
}
