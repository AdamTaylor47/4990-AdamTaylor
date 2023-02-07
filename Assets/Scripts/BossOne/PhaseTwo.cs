using UnityEngine;

namespace BossOne
{
    public class PhaseTwo : BaseState
    {
        private const float TimeBetweenShots = 1f;
        
        private readonly MovementSm _sm;
        
        private int _numberOfBullets;

        public PhaseTwo(MovementSm stateMachine) : base("PhaseTwo", stateMachine)
        {
            _sm = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            _numberOfBullets = 10;
            Debug.Log("Entered Phase 2.");

        }

        public override void UpdateLogic()
        {
            if (ElapsedTime < TimeBetweenShots)
            {
                Debug.Log("Update Phase 2 - Not ready to shoot.");
                return;
            }

            ResetElapsedTime();

            _numberOfBullets--;

            if (_numberOfBullets > 0)
            {
                Debug.Log($"Update Phase 2 - Shot, {_numberOfBullets} remaining.");
                return;
            }
            
            Debug.Log($"Update Phase 2 - Shot, no bullets remaining, switching back to make a decision.");
            stateMachine.ChangeState(_sm.decisionState);
        }

        public override void Exit()
        {
            Debug.Log("Exit Phase 2 - Switching to make a decision.");
        }
    }
}
