using UnityEngine;

namespace BossOne
{
    public class PhaseOne : BaseState
    {
        private const float TimeBetweenShots = 1f;
        
        private readonly MovementSm _sm;
        
        private int _numberOfBullets;

        public PhaseOne(MovementSm stateMachine) : base("PhaseOne", stateMachine)
        {
            _sm = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            _numberOfBullets = 5;
            Debug.Log("Entered Phase 1.");
        }

        public override void UpdateLogic()
        {
            if (ElapsedTime < TimeBetweenShots)
            {
                Debug.Log("Update Phase 1 - Not ready to shoot.");
                return;
            }
            
            ResetElapsedTime();

            _numberOfBullets--;

            if (_numberOfBullets > 0)
            {
                Debug.Log($"Update Phase 1 - Shot, {_numberOfBullets} remaining.");
                return;
            }
            
            Debug.Log($"Update Phase 1 - Shot, no bullets remaining, switching back to make a decision.");
            stateMachine.ChangeState(_sm.decisionState);
        }

        public override void Exit()
        {
            Debug.Log("Exit Phase 1 - Switching to make a decision.");
        }
    }
}
