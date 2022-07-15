using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Codetox.UI
{
    public class OptionSelector : Selectable
    {
        [Flags]
        private enum Axis
        {
            Horizontal, Vertical
        }
        
        [SerializeField] private TMP_Text text;
        [SerializeField] private Axis axis;
        [SerializeField] private List<string> options;

        public UnityEvent<int> onValueChanged;

        private int _currentIndex;

        public int value
        {
            get => _currentIndex;
            set
            {
                SetValueWithoutNotify(value);
                onValueChanged?.Invoke(value);
            }
        }

        public void SetOptions([NotNull] List<string> optionsList)
        {
            options = optionsList ?? throw new ArgumentNullException(nameof(optionsList));
            _currentIndex = 0;
        }

        public void AddOption([NotNull] string option)
        {
            if (option == null) throw new ArgumentNullException(nameof(option));
            options.Add(option);
            _currentIndex = 0;
        }

        public void AddOptions([NotNull] List<string> optionsList)
        {
            if (optionsList == null) throw new ArgumentNullException(nameof(optionsList));
            options.AddRange(optionsList);
            _currentIndex = 0;
        }

        public void SelectNext()
        {
            value = GetNextIndex();
        }

        public void SelectPrevious()
        {
            value = GetPreviousIndex();
        }

        private int GetNextIndex()
        {
            _currentIndex++;
            if (_currentIndex >= options.Count) _currentIndex = 0;
            return _currentIndex;
        }

        private int GetPreviousIndex()
        {
            _currentIndex--;
            if (_currentIndex < 0) _currentIndex = options.Count - 1;
            return _currentIndex;
        }

        public override void OnMove(AxisEventData eventData)
        {
            if (!IsActive() || !IsInteractable())
            {
                base.OnMove(eventData);
                return;
            }

            switch (eventData.moveDir)
            {
                case MoveDirection.Left when axis == Axis.Horizontal:
                    if (FindSelectableOnLeft() == null) SelectPrevious();
                    else base.OnMove(eventData);
                    break;
                case MoveDirection.Right when axis == Axis.Horizontal:
                    if (FindSelectableOnRight() == null) SelectNext();
                    else base.OnMove(eventData);
                    break;
                case MoveDirection.Up when axis == Axis.Vertical:
                    if (FindSelectableOnUp() == null) SelectPrevious();
                    else base.OnMove(eventData);
                    break;
                case MoveDirection.Down when axis == Axis.Vertical:
                    if (FindSelectableOnDown() == null) SelectNext();
                    else base.OnMove(eventData);
                    break;
                default:
                    base.OnMove(eventData);
                    break;
            }
        }

        public void SetValueWithoutNotify(int value)
        {
            if (value < 0 || value >= options.Count) throw new ArgumentOutOfRangeException(nameof(value));
            _currentIndex = value;
            text.text = options[_currentIndex];
        }
    }
}