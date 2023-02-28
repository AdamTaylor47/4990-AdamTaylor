using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bosses
{
    public class AssesmentState : BaseState
    {
        private readonly BossTwoSm _sm;
        public AssesmentState(BossTwoSm stateMachine) : base("AssesmentState", stateMachine) 
        {
            _sm = stateMachine;
        }

        public GameObject player;
        public GameObject boss;
        public EnemyController bossControllerHealth;
       

        public override void Enter()
        {
            base.Enter();
        }
        public override void UpdateLogic()
        {
            base.UpdateLogic();
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            if (boss == null)
            {
                boss = GameObject.FindGameObjectWithTag("Boss");
            }
            bossControllerHealth = boss.GetComponent<EnemyController>();
            double healthPercent = bossControllerHealth.currentHealth / bossControllerHealth.maxHealth;
            Debug.Log(healthPercent);

            
            
            if (healthPercent >= 0.75) 
            {
                Debug.Log("Entering Rage State One");
                stateMachine.ChangeState(_sm.rageOneState);
            }
            if (healthPercent >= 0.50 && healthPercent <= 0.75)
            {
                
                Debug.Log("Entering Rage State Two");
                stateMachine.ChangeState(_sm.rageTwoState);
            }
            if (healthPercent >= 0.25 && healthPercent <= 0.50)
            {
                Debug.Log("Entering Rage State Three");
                stateMachine.ChangeState(_sm.rageThreeState);
            }
            if (healthPercent >= 0 && healthPercent <= 0.25)
            {
                Debug.Log("Entering Rage State Four");
                stateMachine.ChangeState(_sm.rageFourState);
            }
            


        }
        public override void Exit()
        {
            base.Exit();
        }


    }
}
