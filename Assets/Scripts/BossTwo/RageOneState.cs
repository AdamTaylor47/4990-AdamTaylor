using Enemies.Controller;
using UnityEngine;
namespace Bosses
{
    public class RageOneState : BaseState
    {
        private readonly BossTwoSm _sm;
        public RageOneState(BossTwoSm stateMachine) : base("RageOneState",stateMachine) 
        {
            _sm= stateMachine;
        }

        public GameObject player;
        public GameObject boss;
        public Walkable bossControllerMovement;
        public EnemyController bossControllerHealth;

        private const float timeBetweenShots = 0.7f;


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
            
            Debug.Log("Entered Rage State One");
        }
        public override void UpdateLogic()
        {
            base.UpdateLogic();


            if (ElapsedTime < timeBetweenShots)
            {
                return;
            }
            ResetElapsedTime();

            BossShootRandom();
            BossSingleShot();
            bossControllerHealth = boss.GetComponent<EnemyController>();

            stateMachine.ChangeState(_sm.assesmentState);
            
        }
        public override void Exit() 
        { 
            base.Exit();
            
        }

        public override void BossShootRandom()
        {
            base.BossShootRandom();
            GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
            Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
            rb.transform.Rotate(0,0,Random.Range(0,360));
            rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);

        }
        public override void BossSingleShot()
        {
            base.BossSingleShot();
            GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
            Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
            rb.transform.Rotate(0, 0, -90);
            rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
