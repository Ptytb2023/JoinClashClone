using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input.Touches
{
	public class InputTouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
        private Coroutine _releasedRoutine;
        private Coroutine _holdingRoutine;
		
		public event Action<Touch> Begun;
		public event Action<Touch> Holding;
		public event Action<Touch> Ended;
		public event Action<Touch> Released;
		
		public void OnPointerDown(PointerEventData eventData)
		{
            if (_releasedRoutine != null)
                StopCoroutine(_releasedRoutine);

            Begun?.Invoke(new Touch());
			_holdingRoutine = StartCoroutine(ProcessHoldingInput());

            _releasedRoutine = StartCoroutine(ProcessReleasedInput());
        }

		public void OnPointerUp(PointerEventData eventData)
		{
			Ended?.Invoke(new Touch());
			StopCoroutine(_holdingRoutine);
		}

		private IEnumerator ProcessHoldingInput()
		{
			while (enabled)
			{
				Holding?.Invoke(new Touch());
				
				yield return null;
			}
		}

        private IEnumerator ProcessReleasedInput()
        {
            while (enabled)
            {
                Released?.Invoke(new Touch());

                yield return null;
            }
        }

    }
}