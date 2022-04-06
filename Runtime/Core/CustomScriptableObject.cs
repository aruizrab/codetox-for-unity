﻿using System;
using UnityEngine;

namespace Codetox
{
    // TODO [$624dc2494a024b0008cb367b]: Add documentation to CustomScriptableObject.cs
    public abstract class CustomScriptableObject : ScriptableObject
    {
        [Tooltip("Provides information about the purpose of this scriptable object.")] [SerializeField]
        private Details details;

        [Serializable]
        private struct Details
        {
            public string title;
            [TextArea] public string description;
            public string author;
        }
    }
}