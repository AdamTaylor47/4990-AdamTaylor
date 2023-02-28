
using UnityEngine;

namespace Bosses 
{
    public class BossTwoSm : StateMachine
    {
        public Rigidbody2D rb;
        public Transform firePoint;
        public GameObject enemyBullet;
        public float speed = 4f;
        public float bulletSpeed = 5f;

        public RageOneState rageOneState;
        public RageTwoState rageTwoState;
        public RageThreeState rageThreeState;
        public RageFourState rageFourState;
        public AssesmentState assesmentState;
        public TransitionState transitionState;

        private void Awake()
        {
            rageOneState = new(this);
            rageTwoState= new(this);
            rageThreeState= new(this);
            rageFourState= new(this);
            assesmentState= new(this);
            transitionState= new(this);
        }

        protected override BaseState GetInitialState()
        {
            return assesmentState;
        }

    }


}

