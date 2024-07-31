using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Input;
using Input.Stickmen;
using Input.Touches;
using Model.Stickmen;
using Sources.CompositeRoot.Base;
using Sources.CompositeRoot.Extensions;
using Sources.View;
using UnityEngine;
using View.Sources.View.Broadcasters;

namespace Sources.CompositeRoot
{
    public class HordeCompositionRoot : BaseCompositionRoot
	{
		[Header("Input")]
		[SerializeField] private InputSwipePanel _swipePanel;
		[SerializeField] private InputTouchPanel _touchPanel;
		[SerializeField] private Camera _camera;

		[Header("Roots")]
		[SerializeField] private AlliesCompositionRoot _allies;

		[Header("Camera")]
		[SerializeField] private CinemachineTargetGroup _targetGroup;

		[Header("Movement")] 
		[SerializeField] private StickmanHordeMovement.Preferences _preferences;

        [Header("Scene")]
        [SerializeField] private EventTrigger _pathFinishTrigger;

        private HordeInputRouter _inputRouter;
		private HordeViewChanger _viewChanger;
		private StickmanHorde _horde;
		
		public StickmanHordeMovement HordeMovement { get; private set; }

		public override void Compose()
		{
			_horde = new StickmanHorde(_allies.Player);
			HordeMovement = new StickmanHordeMovement(_horde, _preferences).Initialize();
			_inputRouter = new HordeInputRouter(_swipePanel, _touchPanel, HordeMovement, _camera);
			_viewChanger = new HordeViewChanger(_horde, _targetGroup, _allies.PlacedEntities).Initialize();

            foreach (var (movement, view) in _allies.PlacedEntities)
            {
                view
                    .GameObject()
                    .OnTrigger(_pathFinishTrigger)
                    .Do(() => HordeMovement.RemoveStickman(movement));
            }
        }

        public IEnumerable<Entity> Entities() =>
			_horde.Entities.Where(x => x.IsDead == false);

        private void OnEnable()
		{
			HordeMovement.OnEnable();
			_inputRouter.OnEnable();
			_viewChanger.OnEnable();
		}

		private void OnDisable()
		{
			HordeMovement.OnDisable();
			_inputRouter.OnDisable();
			_viewChanger.OnDisable();
		}
	}
}