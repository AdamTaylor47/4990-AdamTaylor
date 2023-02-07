using UnityEngine;

namespace BossOne
{
    public class Idle : BaseState
    {
        private readonly MovementSm _sm;
        private float _horizontalInput;

        public Idle(MovementSm stateMachine) : base("Idle", stateMachine)
        {
            _sm = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            _horizontalInput = 0f;
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            _horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
                stateMachine.ChangeState(_sm.movingState);
        }
    }
}

