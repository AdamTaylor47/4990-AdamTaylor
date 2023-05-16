
using UnityEngine;
namespace Bosses
{
    public class RageTwoState : BaseState
    {
        private readonly BossTwoSm _sm;
        public RageTwoState(BossTwoSm stateMachine) : base("RageTwoState", stateMachine)
        {
            _sm = stateMachine;
        }

        public GameObject player;
        public GameObject boss;
        public Walkable bossControllerMovement;

        private const float timeBetweenShots = 0.4f;

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

        }
        public override void UpdateLogic()
        {
            base.UpdateLogic();
            bossControllerMovement = boss.GetComponent<Walkable>();
            bossControllerMovement.speed = 6f;
            bossControllerMovement.force = 6f;
            _sm.bulletSpeed = 8f;

            if (ElapsedTime < timeBetweenShots)
            {
                return;
            }
            
            ResetElapsedTime();
            BossShootRandom();
            BossSingleShot();
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
            rb.transform.Rotate(0, 0, Random.Range(0, 360));
            rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);

        }
    }
}
