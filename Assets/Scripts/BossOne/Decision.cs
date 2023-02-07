using System.Collections;
using UnityEngine;

namespace BossOne
{
    public class Decision : BaseState
    {
        private const float MakeDecisionTime = 3f;
        
        public GameObject player;
        public GameObject boss;
        
        private readonly MovementSm _sm;

        private float _distance;

        private float _elapsedTime;

        public Decision(MovementSm stateMachine) : base("Decision", stateMachine)
        {
            _sm = stateMachine;
        }

        public override void Enter()
        {
            _elapsedTime = 0;
            Debug.Log($"Entered Decision - Need to wait {MakeDecisionTime} before changing to a phase.");
        }

        public override void UpdateLogic()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < MakeDecisionTime)
            {
                return;
            }
            
            Debug.Log("Update Decision - Making new decision.");

            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            if (boss == null)
            {
                boss = GameObject.FindGameObjectWithTag("Boss");
            }

            _distance = Vector2.Distance(boss.transform.position, player.transform.position);
            //Debug.Log("distance = " + _distance);
            if (_distance < 10)
            {
                Debug.Log("Update Decision - Changing to Phase 1.");
                stateMachine.ChangeState(_sm.phaseOneState);
            }
            else if (_distance >= 10)
            {
                Debug.Log("Update Decision - Changing to Phase 2.");
                stateMachine.ChangeState(_sm.phaseTwoState);
            }
        }

        public override void Exit()
        {
            Debug.Log("Exited Decision - Switching to a phase.");
        }
    }
}
