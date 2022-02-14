using System;

namespace Codetox.Serializable
{
    [Serializable]
    public class Range<T>
    {
        public T min, max;
    }
}