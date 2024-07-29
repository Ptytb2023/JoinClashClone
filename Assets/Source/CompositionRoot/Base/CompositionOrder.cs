using CopositionRoot.Base;
using System;
using UnityEngine;

namespace CompositionRoot.Base
{
    public class CompositionOrder : MonoBehaviour
    {
        [SerializeField] private BaseCompositionRoot[] _order = Array.Empty<BaseCompositionRoot>();

        private void OnValidate()
        {
            foreach (BaseCompositionRoot compositionRoot in _order)
                if (compositionRoot != null)
                    compositionRoot.enabled = false;
        }

        private void Awake()
        {
            foreach (BaseCompositionRoot compositionRoot in _order)
            {
                compositionRoot.Compose();
                compositionRoot.enabled = true;
            }
        }
    }
}
