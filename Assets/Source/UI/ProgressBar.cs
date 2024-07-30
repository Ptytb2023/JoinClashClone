using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        [SerializeField] private Transform _hordeGroub;

        private Slider _slider;

        private float _distance;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            _distance = _endPoint.position.z - _startPoint.position.z;
        }

        private void Update() => 
            _slider.value = _hordeGroub.position.z / _distance;
    }
}
