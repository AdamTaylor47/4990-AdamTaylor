using UnityEngine;

namespace BossOne
{
    public class Moving : BaseState
    {
        private readonly MovementSm _sm;
        private float _horizontalInput;

        public Moving(MovementSm stateMachine) : base("Moving", stateMachine)
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
            if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
                stateMachine.ChangeState(_sm.idleState);
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            Vector2 vel = _sm.rb.velocity;
            vel.x = _horizontalInput * _sm.speed;
            _sm.rb.velocity = vel;
        }
    }
}