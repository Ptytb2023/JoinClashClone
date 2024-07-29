using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CopositionRoot.Base;
using UnityEditor.Animations;
using View.Sources.View.Broadcasters;
using Sources.View;
using Model.Stickmans;
using Model.Components;
using Model.Physics;
using Sources.View.Extensions;
using CompositionRoot.Extensions;
using Model.StateMachine;
using Model.StateMachine.States;
using StateMachine.States.Movement;

namespace CompositionRoot
{
    public class AlliesCompositionRoot : BaseCompositionRoot
    {
        //[Header("Roots")]
        //[SerializeField] private EnemiesCompositionRoot _enemiesRoot;

        [Header("Preferences")]
        [SerializeField] private float _distanceBetweenBounds;
        [SerializeField] private float _maxMovementSpeed;
        [SerializeField] private float _accelerationTime;
        [SerializeField] private float _health;
        //[SerializeField] private StickmanChargeState.Preferences _chargePreferences;
        //[SerializeField] private StickmanAttackState.Preferences _attackPreferences;

        [Header("Used assets")]
        [SerializeField] private AnimatorController _controller;
        [SerializeField] private CapsuleCollider _pickTriggerZonePrefab;

        [Header("Scene")]
        [SerializeField] private EventTrigger _pathFinishTrigger;

        [Header("Views")]
        [SerializeField] private PhysicsTransformableView _playerView;
        [SerializeField] private PhysicsTransformableView[] _otherViews = Array.Empty<PhysicsTransformableView>();

        private Dictionary<StickmanMovement, PhysicsTransformableView> _placedEntities;

        public override void Compose()
        {
            _placedEntities = new Dictionary<StickmanMovement, PhysicsTransformableView>(_otherViews.Length);

            Player = Compose(_playerView);
            _placedEntities.Add(Player, _playerView);

            foreach (PhysicsTransformableView view in _otherViews)
            {
                StickmanMovement movement = Compose(view);
                _placedEntities.Add(movement, view);
            }
        }

        public IReadOnlyDictionary<StickmanMovement, PhysicsTransformableView> PlacedEntities => _placedEntities;

        public StickmanMovement Player { get; private set; }

        private StickmanMovement Compose(PhysicsTransformableView view)
        {
            var health = new Health(_health);
            var model = new Stickman(health, view.transform.position, view.transform.rotation);
            var inertialMovement = new InertialMovement(_maxMovementSpeed, _accelerationTime);
            var surfaceSliding = new SurfaceSliding();
            var movement = new StickmanMovement(model, surfaceSliding, inertialMovement, _distanceBetweenBounds);

            view
                .Initialize(model)
                .AddComponent<CollisionBroadcaster>()
                .Initialize(surfaceSliding)
                .RequireComponent<Animator>(out var animator)
                .BindController(_controller)
                .AddComponent<TickBroadcaster>()
                .InitializeAs(new StickmanStateMachine( new StickmanState[]
                {
                    new StickmanIdleState(movement, StickmanAnimatorParameters.Idle),
                    new StickmanRunState(movement, StickmanAnimatorParameters.IsRunning),
                }), out var stateMachine)
                .ContinueWith(stateMachine.Enter<StickmanIdleState>)
                .Append(_pickTriggerZonePrefab)
                .GoToParent()
                .AddComponent<Trigger>()
                .Between<StickmanMovement, (StickmanHorde, StickmanMovement)>(movement, handler => handler.Item1.Add(movement))
            
                .OnTrigger(_pathFinishTrigger)
                .Do(stateMachine.Enter<StickmanChargeState>)
                .ContinueWith(() => model.Died += stateMachine.Enter<StickmanDeathState>);

            return movement;
        }
    }
}
