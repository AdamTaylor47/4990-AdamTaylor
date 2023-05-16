
using UnityEngine;
namespace Bosses
{
    public class PhaseTwo : BaseState { 
        private const float TimeBetweenShots = 1f;
        
        private readonly BossOneSm _sm;

        
        private int numberOfBullets;
        private int numberOfActions;
        private int distanceBetweenBullets;
        private float x = 0;
        private float y = 0;
        public float bulletSpeed = 10f;
  
        public Walkable bossControllerMovement;
        public GameObject player;
        public GameObject boss;


        public PhaseTwo(BossOneSm stateMachine) : base("PhaseTwo", stateMachine)
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

            numberOfActions = 5;
            //adjust fire point to face player
            Vector2 direction = player.transform.position - _sm.firePoint.transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _sm.firePoint.transform.rotation = Quaternion.Euler(Vector3.forward * (angle - 90f));
            
            Debug.Log("Entered Phase 2.");

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
            bossControllerMovement.speed = 5f;
            bossControllerMovement.force = 5f;
            Debug.Log("Exit Phase 2 - Switching to make a decision.");
        }

        public override void BossShootLine()
        {
            base.BossShootLine();
            numberOfBullets = 6;
            distanceBetweenBullets = 3;

            for (int i = 0; i < numberOfBullets; i++)
            {
                GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
                Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
                rb.transform.Translate(distanceBetweenBullets - 15, 0, 0);
                rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);
                distanceBetweenBullets += 5;
            }
        }
        public override void BossShootLineOffset()
        {
            base.BossShootLineOffset();
            numberOfBullets = 6;
            distanceBetweenBullets = 0;

            for (int i = 0; i < numberOfBullets; i++)
            {
                GameObject activeEnemyBullet = GameObject.Instantiate(_sm.enemyBullet, _sm.firePoint.position, _sm.firePoint.rotation);
                Rigidbody2D rb = activeEnemyBullet.GetComponent<Rigidbody2D>();
                rb.transform.Translate(distanceBetweenBullets - 14, 0, 0);
                rb.AddForce(rb.transform.up * _sm.bulletSpeed, ForceMode2D.Impulse);
                distanceBetweenBullets += 5;
            }
        }
    }
}
