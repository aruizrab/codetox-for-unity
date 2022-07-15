using System;

namespace Codetox.Misc
{
    [Serializable]
    public struct Range<T> where T: IComparable<T>
    {
        public T min, max;

        public Range(T min, T max)
        {
            this.min = min;
            this.max = max;
        }

        public bool IsInRange(T value)
        {
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }
    }
}