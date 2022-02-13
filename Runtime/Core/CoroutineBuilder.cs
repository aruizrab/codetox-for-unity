using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Codetox.Core
{
    public class CoroutineBuilder : MonoBehaviour
    {
        private readonly Queue<ExecutionStep> _sequence = new();
        private Coroutine _coroutine;
        private bool _destroyOnFinish, _cancelOnDisable;
        private WaitForEndOfFrame _waitForEndOfFrame;
        private WaitForFixedUpdate _waitForFixedUpdate;
        private WaitForSeconds _waitForSeconds;
        private WaitUntil _waitUntil;
        private WaitWhile _waitWhile;

        public bool IsRunning { get; private set; }

        private void OnDisable()
        {
            if (_cancelOnDisable) Cancel();
        }

        public CoroutineBuilder Invoke(Action action)
        {
            _sequence.Enqueue(new ExecutionStep(StepType.Invoke, action));
            return this;
        }

        public CoroutineBuilder WaitForSeconds(float seconds)
        {
            _waitForSeconds = new WaitForSeconds(seconds);
            _sequence.Enqueue(new ExecutionStep(StepType.WaitForSeconds, seconds));
            return this;
        }

        public CoroutineBuilder ForTimes(int times)
        {
            _sequence.Enqueue(new ExecutionStep(StepType.ForTimes, times));
            return this;
        }

        public CoroutineBuilder While(Func<bool> predicate)
        {
            _sequence.Enqueue(new ExecutionStep(StepType.While, predicate));
            return this;
        }

        public CoroutineBuilder WaitForEndOfFrame()
        {
            _waitForEndOfFrame = new WaitForEndOfFrame();
            _sequence.Enqueue(new ExecutionStep(StepType.WaitForEndOfFrame));
            return this;
        }

        public CoroutineBuilder WaitForFixedUpdate()
        {
            _waitForFixedUpdate = new WaitForFixedUpdate();
            _sequence.Enqueue(new ExecutionStep(StepType.WaitForFixedUpdate));
            return this;
        }

        public CoroutineBuilder WaitUntil(Func<bool> predicate)
        {
            _waitUntil = new WaitUntil(predicate);
            _sequence.Enqueue(new ExecutionStep(StepType.WaitUntil, predicate));
            return this;
        }

        public CoroutineBuilder WaitWhile(Func<bool> predicate)
        {
            _waitWhile = new WaitWhile(predicate);
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
                        yield return StartCoroutine(RunWaitForSeconds(step.Value is float value ? value : 0));
                        break;
                    case StepType.WaitForEndOfFrame:
                        yield return StartCoroutine(RunWaitForEndOfFrame());
                        break;
                    case StepType.WaitForFixedUpdate:
                        yield return StartCoroutine(RunWaitForFixedUpdate());
                        break;
                    case StepType.WaitUntil:
                        yield return StartCoroutine(RunWaitUntil(step.Value as Func<bool>));
                        break;
                    case StepType.WaitWhile:
                        yield return StartCoroutine(RunWaitWhile(step.Value as Func<bool>));
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

        private IEnumerator RunWaitForSeconds(float seconds)
        {
            yield return _waitForSeconds;
        }

        private IEnumerator RunWaitForEndOfFrame()
        {
            yield return _waitForEndOfFrame;
        }

        private IEnumerator RunWaitForFixedUpdate()
        {
            yield return _waitForFixedUpdate;
        }

        private IEnumerator RunWaitUntil(Func<bool> predicate)
        {
            yield return _waitUntil;
        }

        private IEnumerator RunWaitWhile(Func<bool> predicate)
        {
            yield return _waitWhile;
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