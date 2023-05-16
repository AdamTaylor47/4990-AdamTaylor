using UnityEngine;

namespace Bosses
{
    public class StateMachine : MonoBehaviour
    {
        private BaseState _currentState;

        private void Start()
        {
            _currentState = GetInitialState();
            _currentState?.Enter();
        }

        private void Update()
        {
            if (_currentState == null)
            {
                return;
            }
            // Every tick increase the time value for a state so time-based decisions can be performed.
            _currentState.TickElapsedTime();
            _currentState.UpdateLogic();
        }

        public void ChangeState(BaseState newState)
        {
            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
            // Ensure the new state starts at 0 elapsed time.
            _currentState.ResetElapsedTime();
        }

        protected virtual BaseState GetInitialState()
        {
            return null;
        }
    }
}