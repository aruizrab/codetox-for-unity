namespace Codetox.AI.Detection
{
    public interface ITargetDetector<T>
    {
        (T, bool) DetectTarget();
    }
}