using UnityEngine;
namespace Bosses
{
    public class Decision : BaseState { 
        private readonly BossOneSm _sm;
        public Decision(BossOneSm stateMachine) : base("Decision", stateMachine)
        {
            _sm = stateMachine;
        }
        private Vector2 movement;
        private const float MakeDecisionTime = 4f;

        public GameObject player;
        public GameObject boss;


        private float distance;
        private float speed = 3f;
        private float _elapsedTime;
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

            player = GameObject.FindGameObjectWithTag("Player");
            boss = GameObject.FindGameObjectWithTag("Boss");
            distance = Vector2.Distance(boss.transform.position, player.transform.position);
            Debug.Log("distance = " + distance);
            if (distance < 12)
            {
                Debug.Log("Changing to state 1");
                stateMachine.ChangeState(_sm.phaseOneState);

            }
            else if (distance >= 12)
            {
                Debug.Log("Changing to state 2");
                stateMachine.ChangeState(_sm.phaseTwoState);


            }
        }

        

        public override void Exit()
        {
            Debug.Log("Exited Decision - Switching to a phase.");
        }
    }

}
