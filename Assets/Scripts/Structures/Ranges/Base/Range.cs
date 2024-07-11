using System;
using UnityEngine;

namespace Structures.Ranges.Base
{
    [Serializable]
    public class Range<T> : IRange<T>
    {
        [field: SerializeField] public T Min { get; set; }
        [field: SerializeField] public T Max { get; set; }
    }
}
