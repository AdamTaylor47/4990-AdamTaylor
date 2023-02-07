using UnityEngine;

namespace BossOne
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

        // You had this as LateUpdate but shouldn't it be FixedUpdate if its just physics?
        private void FixedUpdate()
        {
            _currentState?.UpdatePhysics();
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
        
        private void OnGUI()
        {
            string content = _currentState != null ? _currentState.name : "(no current state)";
            GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        }
    }
}
