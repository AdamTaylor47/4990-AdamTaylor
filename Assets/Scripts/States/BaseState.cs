using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Bosses
{
    public class BaseState
    {
        public readonly string name;
        protected readonly StateMachine stateMachine;
        
        public float ElapsedTime { get; private set; }

        //creating a statemachine

        public BaseState(string name, StateMachine stateMachine)
        {
            this.name = name;
            this.stateMachine = stateMachine;
        }
        //internal clock
        public void TickElapsedTime()
        {
            ElapsedTime += Time.deltaTime;
        }

        public void ResetElapsedTime()
        {
            ElapsedTime = 0;
        }

        public virtual void Enter() { }
        public virtual void UpdateLogic() { }
        public virtual void Exit() { }

        // different methods for shooting patterns
       
        public virtual void BossShootRandom() { }
        public virtual void BossShootRing() { }
        public virtual void BossShootRingReverse() { }
        public virtual void BossShootWave() { }
        public virtual void BossShootLine() { }
        public virtual void BossShootLineOffset() { }
        public virtual void BossSingleShot() { }
    }
    
}
