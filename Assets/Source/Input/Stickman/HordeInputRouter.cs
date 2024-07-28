using Input.Touches;
using Model.Stickmans;
using UnityEngine;

using Touch = Input.Touches.Touch;

namespace Input.Stickman
{
    public class HordeInputRouter
    {
        private readonly InputSwipePanel _swipePanel;
        private readonly InputTouchPanel _touchPanel;

        private readonly StickmanHordeMovement _movement;
        private readonly Camera _camera;

        public void OnEnable()
        {
            _swipePanel.SwipeBegun += BeginAdjustHorizontalMovement;
            _swipePanel.Swiping += AdjustHorizontalMovement;

            _touchPanel.Holding += Accelerate;
            _touchPanel.Released += Slowdown;
        }

        public void OnDisable()
        {
            _swipePanel.SwipeBegun -= BeginAdjustHorizontalMovement;
            _swipePanel.Swiping -= AdjustHorizontalMovement;

            _touchPanel.Holding -= Accelerate;
            _touchPanel.Released -= Slowdown;
        }

        private void Accelerate(Touch touch)
        => _movement.Accelerate(Time.deltaTime);


        private void Slowdown(Touch touch) => 
            _movement.Slowdown(Time.deltaTime);

        private void BeginAdjustHorizontalMovement(Swipe swipe) => 
            _movement.UpdateStartMovingRight();

        private void AdjustHorizontalMovement(Swipe swipe)
        {
            Vector3 viewportEnd = _camera.ScreenToViewportPoint(swipe.EndPosition);
            Vector3 viewportStart = _camera.ScreenToViewportPoint(swipe.StartPosition);

            float axis = Mathf.Clamp(viewportEnd.x - viewportStart.x, -1, 1);

            _movement.MoveRight(axis);
        }
    }
}
