using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream:Assets/Scripts/BossOne/BaseState.cs
public class BaseState
=======
namespace Bosses
>>>>>>> Stashed changes:Assets/Scripts/States/BaseState.cs
{
    public string name;
    protected StateMachine stateMachine;


    public BaseState(string name, StateMachine stateMachine)
    {
<<<<<<< Updated upstream:Assets/Scripts/BossOne/BaseState.cs
        this.name = name;
        this.stateMachine = stateMachine;
=======
        public readonly string name;
        protected readonly StateMachine stateMachine;
        
        public float ElapsedTime { get; private set; }

        public BaseState(string name, StateMachine stateMachine)
        {
            this.name = name;
            this.stateMachine = stateMachine;
        }

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
>>>>>>> Stashed changes:Assets/Scripts/States/BaseState.cs
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}
