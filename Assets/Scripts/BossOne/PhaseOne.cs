<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseOne : BaseState
=======
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Bosses
>>>>>>> Stashed changes
{
    private MovementSM _sm;
    private float _numberOfBullets;

    public PhaseOne(MovementSM stateMachine) : base("PhaseOne", stateMachine)
    {
<<<<<<< Updated upstream
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _numberOfBullets = 5f;
        Debug.Log("Entered state 1");

    }

    public override void UpdateLogic()
    {
        Debug.Log("Stuck in Update logic phase 1");
        stateMachine.ChangeState(_sm.decisionState);
        stateMachine.startTimer();


=======
        private readonly BossOneSm _sm;
        public PhaseOne(BossOneSm stateMachine) : base("PhaseOne", stateMachine)
        {
            _sm = stateMachine;
        }

        private int _numberOfActions;
        private int numberOfBullets;
        public float distanceBetweenBullets;
        private float x = 0;
        private float y = 0;
        public float bulletSpeed = 5f;
        private const float TimeBetweenShots = 0.2f;

        public override void Enter()
        {
            base.Enter();
            _numberOfActions = 20;
            Debug.Log("Entered Phase 1.");
        }

        public override void UpdateLogic()
        {
            if (ElapsedTime < TimeBetweenShots)
            {
                return;
            }
            ResetElapsedTime();

            _numberOfActions--;

            if (_numberOfActions >= 10)
            {
                BossShootRing();
                return;
            }
            if (_numberOfActions < 10 && _numberOfActions >= 0) 
            {
                BossShootRingReverse();
                return;
            }

            Debug.Log($"Update Phase 1 - Shot, no bullets remaining, switching back to make a decision.");
            stateMachine.ChangeState(_sm.decisionState);
        }

        public override void Exit()
        {
            Debug.Log("Exit Phase 1 - Switching to make a decision.");
        }

        public override void BossShootRing()
        {
            base.BossShootRing();
            numberOfBullets = 10;
            

            distanceBetweenBullets = 360 / numberOfBullets;
            for (int i = 0; i < numberOfBullets; i++) 
            {
                GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
                Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
                rb.transform.Rotate(0, 0, x);
                x += distanceBetweenBullets;
                rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);

            }
            x += 10;


        }
        public override void BossShootRingReverse()
        {
            base.BossShootRingReverse();
            numberOfBullets = 10;
            


            distanceBetweenBullets = 360 / numberOfBullets;
            for (int i = 0; i < numberOfBullets; i++)
            {
                GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
                Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
                rb.transform.Rotate(0, 0, y);
                y -= distanceBetweenBullets;
                rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);

            }
            y -= 10;


        }
>>>>>>> Stashed changes
    }
}
