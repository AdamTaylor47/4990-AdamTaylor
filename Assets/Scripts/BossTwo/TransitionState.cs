using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Bosses
{
    public class TransitionState : BaseState
    {
        private readonly BossTwoSm _sm;
        public TransitionState(BossTwoSm stateMachine) : base("TransitionState",stateMachine) 
        {
            _sm = stateMachine;
        }

        public GameObject player;
        public GameObject boss;
        public Walkable bossControllerMovement;

        private int numberOfBullets;
        private float x = 0;
        public float distanceBetweenBullets;
        public float pause = 3f;

        public override void Enter()
        {
            base.Enter();

        }
        public override void UpdateLogic()
        {

            base.UpdateLogic();
            if (ElapsedTime > pause) 
            {
                BossShootRing();
                stateMachine.ChangeState(_sm.assesmentState);
            }

        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void BossShootRing()
        {
            base.BossShootRing();
            numberOfBullets = 5;


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
    }
}
