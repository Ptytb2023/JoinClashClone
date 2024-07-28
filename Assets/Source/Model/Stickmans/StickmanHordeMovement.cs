using System.Linq;

namespace Model.Stickmans
{
    public class StickmanHordeMovement
    {
        private readonly StickmanHorde _horde;

        public StickmanHordeMovement(StickmanHorde horde) => 
            _horde = horde;

        public void Accelerate(float deltaTime)
        {
            foreach (StickmanMovement stickman in _horde.Stickmans)
                stickman.Accelerate(deltaTime);
        }

        public void Slowdown(float deltaTime)
        {
            foreach (StickmanMovement stickman in _horde.Stickmans)
                stickman.Slowdown(deltaTime);
        }

        public void UpdateStartMovingRight()
        {
            foreach (StickmanMovement stickman in _horde.Stickmans)
                stickman.UpdateMovingRight();
        }

        public void MoveRight(float axis)
        {
            if (!CanMove(axis))
                return;

            foreach (StickmanMovement stickman in _horde.Stickmans)
                stickman.MoveRight(axis);
        }

        private bool CanMove(float axis) =>
            _horde.Stickmans.Any(x => x.OnRightBound && axis > 0.0f || x.OnLeftBound && axis < 0.0f) == false;
    }
}
