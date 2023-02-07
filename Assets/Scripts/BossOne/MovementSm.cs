using UnityEngine;

namespace BossOne
{
    public class MovementSm : StateMachine
    {
        public Idle idleState;
        public Moving movingState;
        public PhaseOne phaseOneState;
        public PhaseTwo phaseTwoState;
        public Decision decisionState;

        public Rigidbody2D rb;
        public float speed = 4f;

        private void Awake()
        {
            idleState = new(this);
            movingState = new(this);
            phaseOneState = new(this);
            phaseTwoState = new(this);
            decisionState = new(this);
        }

        protected override BaseState GetInitialState()
        {
            return decisionState;
        }
    }
}
