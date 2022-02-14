using JetBrains.Annotations;

namespace Codetox.Pooling
{
    public interface IObjectPool<T>
    {
        [NotNull]
        T Get();

        void Return([NotNull] T item);
    }
}