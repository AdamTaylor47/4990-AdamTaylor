using UnityEngine;

namespace Bosses
{
    public class BossOneSm : StateMachine
    {

        public Rigidbody2D rb;
        public Transform firePoint;
        public GameObject enemyBullet;
        public float speed = 4f;
        public float bulletSpeed = 5f;

        public PhaseOne phaseOneState;
        public PhaseTwo phaseTwoState;
        public Decision decisionState;

        private void Awake()
        {
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
