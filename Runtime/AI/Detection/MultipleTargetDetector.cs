using System.Collections.Generic;
using System.Linq;
using Codetox.Attributes;
using Codetox.Core;
using UnityEngine;
using UnityEngine.Events;

namespace Codetox.AI.Detection
{
    public abstract class MultipleTargetDetector<T> : MonoBehaviour, ITargetDetector<List<T>>
    {
        [SerializeField] private DetectionStrategy detectionStrategy;

        [SerializeField] [ShowIf(nameof(detectionStrategy), DetectionStrategy.RepetitionsPerSecond)]
        private float repetitionsPerSecond;

        public UnityEvent<T> onTargetDetected;
        public UnityEvent<T> onTargetLost;

        private CoroutineBuilder _coroutine;

        public List<T> CurrentTargets { get; private set; } = new();

        public bool HasTargets => CurrentTargets.Count > 0;

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

        public abstract (List<T>, bool) DetectTarget();

        private void HandleTargetDetection()
        {
            var (newTargets, detected) = DetectTarget();
            var oldTargets = CurrentTargets;

            CurrentTargets = newTargets;

            foreach (var target in oldTargets.Where(target => !newTargets.Contains(target)))
                onTargetLost?.Invoke(target);

            foreach (var target in newTargets.Where(target => !oldTargets.Contains(target)))
                onTargetDetected?.Invoke(target);
        }
    }
}