using DG.Tweening;
using Structures.Ranges;
using UnityEngine;

namespace Animations
{
    public class MovableBetweenTwoPointsAnimation : MonoBehaviour
    {
        [SerializeField] private Range<Transform> _startAndEndPoint;

        [Header("Setting Animation")]
        [SerializeField] private float _duration;
        [SerializeField] private Ease _movmentCurve;

        private Tween _animation;

        private void OnEnable()
        {
            Vector3 startPostion = _startAndEndPoint.Min.position;
            Vector3 endPostion = _startAndEndPoint.Max.position;

            transform.position = startPostion;

            _animation = transform.
                 DOMove(endPostion, _duration).
                 SetEase(_movmentCurve).
                 SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDisable() =>
            _animation?.Kill();
    }
}