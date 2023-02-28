<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTwo : BaseState
=======
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Bosses
>>>>>>> Stashed changes
{
    private MovementSM _sm;
    private float _numberOfBullets;


    public PhaseTwo(MovementSM stateMachine) : base("PhaseTwo", stateMachine)
    {
<<<<<<< Updated upstream
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _numberOfBullets = 10f;
        Debug.Log("Entered state 2");

    }

    public override void UpdateLogic()
    {
        Debug.Log("Stuck in Update logic phase 2");
        stateMachine.ChangeState(_sm.decisionState);
        stateMachine.startTimer();
=======
        private const float TimeBetweenShots = 0.3f;
        
        private readonly BossOneSm _sm;
        
        private int numberOfBullets;
        private int numberOfActions;
        private int distanceBetweenBullets;
        private float x = 0;
        private float y = 0;
        public float bulletSpeed = 7f;
        private GameObject player = GameObject.FindWithTag("Player");


        public PhaseTwo(BossOneSm stateMachine) : base("PhaseTwo", stateMachine)
        {
            _sm = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            numberOfActions = 12;
            Vector2 direction = player.transform.position - _sm.firePoint.transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _sm.firePoint.transform.rotation = Quaternion.Euler(Vector3.forward * (angle - 90f));
            Debug.Log("Entered Phase 2.");

        }

        public override void UpdateLogic()
        {
            if (ElapsedTime < TimeBetweenShots)
            {
                return;
            }

            ResetElapsedTime();

            numberOfActions--;

            if (numberOfActions > 0)
            {
                if (numberOfActions % 2 == 0)
                {
                    BossShootLine();
                }
                else 
                {
                    BossShootLineOffset();
                }
                
               
                return;
            }
            
            Debug.Log($"Update Phase 2 - Shot, no bullets remaining, switching back to make a decision.");
            stateMachine.ChangeState(_sm.decisionState);
        }

        public override void Exit()
        {
            Debug.Log("Exit Phase 2 - Switching to make a decision.");
        }

        public override void BossShootLine()
        {
            base.BossShootLine();
            numberOfBullets = 10;
            distanceBetweenBullets = 3;

            for (int i = 0; i < numberOfBullets; i++)
            {
                GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
                Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
                rb.transform.Translate(distanceBetweenBullets - 15, 0, 0);
                rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);
                distanceBetweenBullets += 3;
            }
        }
        public override void BossShootLineOffset()
        {
            base.BossShootLineOffset();
            numberOfBullets = 10;
            distanceBetweenBullets = 0;

            for (int i = 0; i < numberOfBullets; i++)
            {
                GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
                Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
                rb.transform.Translate(distanceBetweenBullets - 14f, 0, 0);
                rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);
                distanceBetweenBullets += 3;
            }
        }
>>>>>>> Stashed changes
    }
}
