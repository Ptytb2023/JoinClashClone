using System;
using System.Collections.Generic;
using Model.StateMachine;
using Model.Stickmen;
using Model.Timers;
using UnityEngine;

namespace Model.Sources.Model.StateMachine.States.FightStates
{
    public class StickmanAttackState : StickmanFightStatesGroup
    {
        private readonly float _damage;
        private readonly float _timeBetweenAttacks;

        private readonly Timer _timer = new Timer();

        private readonly AudioSource _audioSource;
        private readonly AudioClip _punchSound;

        public StickmanAttackState(Stickman model,
                                   Func<IEnumerable<Stickman>> enemiesAlive,
                                   Preferences preferences,
                                   AudioSource audioSource,
                                   int animationHash)
            : base(model, enemiesAlive, animationHash)
        {
            _damage = preferences.Damage;
            _timeBetweenAttacks = preferences.TimeBetweenAttacks;
            _audioSource = audioSource;
            _punchSound = preferences.PunchSound;
        }

        public override void Tick(float deltaTime, StickmanStateMachine stateMachine)
        {
            base.Tick(deltaTime, stateMachine);

            if (_timer.IsOver)
                Punch();

            _timer.Tick(deltaTime);
        }

        private void Punch()
        {
            ClosestEnemy.TakeDamage(_damage);

            _audioSource.PlayOneShot(_punchSound);
            _timer.Start(_timeBetweenAttacks);
        }

        protected override void CheckTransitions(StickmanStateMachine stateMachine)
        {
            base.CheckTransitions(stateMachine);

            if (ClosestEnemy.IsDead)
                stateMachine.Enter<StickmanChargeState>();
        }

        [Serializable]
        public struct Preferences
        {
            public float Damage;
            public float TimeBetweenAttacks;
            public AudioClip PunchSound;
        }

    }
}