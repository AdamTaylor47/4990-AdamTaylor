
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bosses
{
public class PhaseOne : BaseState{

        private readonly BossOneSm _sm;

        private int _numberOfActions;
        private int numberOfBullets;
        public float distanceBetweenBullets;
        private float x = 0;
        private float y = 0;
        public float bulletSpeed = 10f;
        private const float TimeBetweenShots = 0.3f;

        public Walkable bossControllerMovement;
        public GameObject player;
        public GameObject boss;

        public PhaseOne(BossOneSm stateMachine) : base("PhaseOne", stateMachine)
        {
            _sm = stateMachine;
        }




        public override void Enter()
        {
            base.Enter();
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            if (boss == null)
            {
                boss = GameObject.FindGameObjectWithTag("Boss");
            }
            
            _numberOfActions = 15;
            Debug.Log("Entered Phase 1.");


            //hhave boss stop while firing
            bossControllerMovement = boss.GetComponent<Walkable>();
            bossControllerMovement.speed = 0f;
            bossControllerMovement.force = 10f;

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
            bossControllerMovement.speed = 5f;
            bossControllerMovement.force = 5f;
            Debug.Log("Exit Phase 1 - Switching to make a decision.");
        }

        public override void BossShootRing()
        {
            base.BossShootRing();
            numberOfBullets = 8;
            

            distanceBetweenBullets = 360 / numberOfBullets;
            for (int i = 0; i < numberOfBullets; i++) 
            {
                GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
                Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
                rb.transform.Rotate(0, 0, x);
                x += distanceBetweenBullets;
                rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);

            }
            x += 8;


        }
        public override void BossShootRingReverse()
        {
            base.BossShootRingReverse();
            numberOfBullets = 8;
            


            distanceBetweenBullets = 360 / numberOfBullets;
            for (int i = 0; i < numberOfBullets; i++)
            {
                GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
                Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
                rb.transform.Rotate(0, 0, y);
                y -= distanceBetweenBullets;
                rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);

            }
            y -= 8;


        }
    }
}
