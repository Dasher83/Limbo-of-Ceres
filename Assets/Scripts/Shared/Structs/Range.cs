using System;

namespace LimboOfCeres.Scripts.Shared.Structs
{
    public struct Range<T> where T : IComparable
    {
        private T minimum;
        private T maximum;

        public T Minimum => minimum;
        public T Maximum => maximum;

        public Range(T minimum, T maximum)
        {
            this.minimum = minimum;
            this.maximum = maximum;
        }
    }
}
