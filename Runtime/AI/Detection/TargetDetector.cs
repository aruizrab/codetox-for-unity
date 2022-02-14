using Codetox.Attributes;
using Codetox.Core;
using UnityEngine;
using UnityEngine.Events;

namespace Codetox.AI.Detection
{
    public enum DetectionStrategy
    {
        Passive,
        RepetitionsPerSecond,
        OnUpdate,
        OnFixedUpdate
    }

    public abstract class TargetDetector<T> : MonoBehaviour, ITargetDetector<T>
    {
        [SerializeField] private DetectionStrategy detectionStrategy;

        [SerializeField] [ShowIf(nameof(detectionStrategy), DetectionStrategy.RepetitionsPerSecond)]
        private float repetitionsPerSecond;

        public UnityEvent<T> onTargetDetected;
        public UnityEvent<T> onTargetLost;

        private CoroutineBuilder _coroutine;

        public T CurrentTarget { get; private set; }
        public bool HasTarget { get; private set; }

        private void Update()
        {
            if (detectionStrategy != DetectionStrategy.OnUpdate) return;
            HandleTargetDetection();
        }

        private void FixedUpdate()
        {
            if (detectionStrategy != DetectionStrategy.OnFixedUpdate) return;
            HandleTargetDetection();
        }

        private void OnEnable()
        {
            if (detectionStrategy != DetectionStrategy.RepetitionsPerSecond) return;
            _coroutine ??= this.Coroutine(false).Invoke(HandleTargetDetection).WaitForSeconds(1 / repetitionsPerSecond)
                .While(() => gameObject.activeSelf);

            _coroutine.Run();
        }

        private void OnDisable()
        {
            if (detectionStrategy != DetectionStrategy.RepetitionsPerSecond) return;
            _coroutine.Cancel();
        }

        public abstract (T, bool) DetectTarget();

        protected virtual void HandleTargetDetection()
        {
            var (target, detected) = DetectTarget();

            switch (detected)
            {
                case true when !HasTarget:
                    CurrentTarget = target;
                    HasTarget = true;
                    onTargetDetected?.Invoke(CurrentTarget);
                    break;
                case true when !Equals(target, CurrentTarget):
                    onTargetLost?.Invoke(CurrentTarget);
                    CurrentTarget = target;
                    onTargetDetected?.Invoke(CurrentTarget);
                    break;
                case false when HasTarget:
                    HasTarget = false;
                    onTargetLost?.Invoke(CurrentTarget);
                    CurrentTarget = default;
                    break;
            }
        }
    }
}