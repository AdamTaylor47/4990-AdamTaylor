using UnityEngine;

namespace BossOne
{
    public class BaseState
    {
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
        public virtual void UpdatePhysics() { }
        public virtual void Exit() { }
    }
}
