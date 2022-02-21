using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Codetox.Core
{
    public class CoroutineBuilder : MonoBehaviour
    {
        private readonly Queue<ExecutionStep> _sequence = new();
        private readonly WaitForEndOfFrame _waitForEndOfFrame = new();
        private readonly WaitForFixedUpdate _waitForFixedUpdate = new();
        private Coroutine _coroutine;
        private bool _destroyOnFinish = true, _cancelOnDisable = true;

        public bool IsRunning { get; private set; }

        private void OnDisable()
        {
            if (_cancelOnDisable) Cancel();
        }

        public CoroutineBuilder Invoke([NotNull] Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _sequence.Enqueue(new ExecutionStep(StepType.Invoke, action));
            return this;
        }

        public CoroutineBuilder WaitForSeconds(float seconds)
        {
            if (seconds < 0) throw new ArgumentOutOfRangeException(nameof(seconds));
            _sequence.Enqueue(new ExecutionStep(StepType.WaitForSeconds, seconds));
            return this;
        }

        public CoroutineBuilder ForTimes(int times)
        {
            if (times < 0) throw new ArgumentOutOfRangeException(nameof(times));
            _sequence.Enqueue(new ExecutionStep(StepType.ForTimes, times));
            return this;
        }

        public CoroutineBuilder While([NotNull] Func<bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            _sequence.Enqueue(new ExecutionStep(StepType.While, predicate));
            return this;
        }

        public CoroutineBuilder WaitForEndOfFrame()
        {
            _sequence.Enqueue(new ExecutionStep(StepType.WaitForEndOfFrame));
            return this;
        }

        public CoroutineBuilder WaitForFixedUpdate()
        {
            _sequence.Enqueue(new ExecutionStep(StepType.WaitForFixedUpdate));
            return this;
        }

        public CoroutineBuilder WaitUntil([NotNull] Func<bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            _sequence.Enqueue(new ExecutionStep(StepType.WaitUntil, predicate));
            return this;
        }

        public CoroutineBuilder WaitWhile([NotNull] Func<bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            _sequence.Enqueue(new ExecutionStep(StepType.WaitWhile, predicate));
            return this;
        }

        public CoroutineBuilder DestroyOnFinish(bool condition = true)
        {
            _destroyOnFinish = condition;
            return this;
        }

        public CoroutineBuilder CancelOnDisable(bool condition = true)
        {
            _cancelOnDisable = condition;
            return this;
        }

        public void Run()
        {
            if (IsRunning) Cancel();
            _coroutine = StartCoroutine(RunCoroutine());
        }

        public void Cancel()
        {
            if (IsRunning)
            {
                StopCoroutine(_coroutine);
                IsRunning = false;
            }

            if (_destroyOnFinish) Destroy(this);
        }

        private IEnumerator RunCoroutine()
        {
            IsRunning = true;

            var iterations = 0;
            var start = 0;

            for (var i = 0; i < _sequence.Count; i++)
            {
                var step = _sequence.ElementAt(i);

                switch (step.Type)
                {
                    case StepType.Invoke:
                        (step.Value as Action)?.Invoke();
                        break;
                    case StepType.WaitForSeconds:
                        yield return new WaitForSeconds((float) step.Value);
                        break;
                    case StepType.WaitForEndOfFrame:
                        yield return _waitForEndOfFrame;
                        break;
                    case StepType.WaitForFixedUpdate:
                        yield return _waitForFixedUpdate;
                        break;
                    case StepType.WaitUntil:
                        yield return new WaitUntil(step.Value as Func<bool>);
                        break;
                    case StepType.WaitWhile:
                        yield return new WaitWhile(step.Value as Func<bool>);
                        break;
                    case StepType.ForTimes when iterations < (int) step.Value - 1:
                        i = start - 1;
                        iterations++;
                        break;
                    case StepType.ForTimes:
                        iterations = 0;
                        start = i + 1;
                        break;
                    case StepType.While when (step.Value as Func<bool>)?.Invoke() ?? false:
                        i = start - 1;
                        iterations++;
                        break;
                    case StepType.While:
                        iterations = 0;
                        start = i + 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            IsRunning = false;
            if (_destroyOnFinish) Destroy(this);
        }

        private enum StepType
        {
            Invoke,
            WaitForSeconds,
            WaitForEndOfFrame,
            ForTimes,
            While,
            WaitForFixedUpdate,
            WaitUntil,
            WaitWhile
        }

        private readonly struct ExecutionStep
        {
            public readonly StepType Type;
            public readonly object Value;

            public ExecutionStep(StepType type, object value = null)
            {
                Type = type;
                Value = value;
            }
        }
    }
}