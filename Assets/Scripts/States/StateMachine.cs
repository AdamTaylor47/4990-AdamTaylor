using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream:Assets/Scripts/BossOne/StateMachine.cs
public class StateMachine : MonoBehaviour
=======
namespace Bosses
>>>>>>> Stashed changes:Assets/Scripts/States/StateMachine.cs
{
    BaseState currentState;


    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

<<<<<<< Updated upstream:Assets/Scripts/BossOne/StateMachine.cs
    public void ChangeState(BaseState newState)
    {
        
        currentState.Exit();
        currentState = newState;
        StartCoroutine(phaseTimer());
        currentState.Enter();
        //currentState.UpdateLogic();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    IEnumerator phaseTimer() 
    {
        yield return new WaitForSecondsRealtime(5);
    }

    public void startTimer() 
    {
        StartCoroutine(phaseTimer());
    }
    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
=======
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
        
        /*
        private void OnGUI()
        {
            string content = _currentState != null ? _currentState.name : "(no current state)";
            GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        }
        */
>>>>>>> Stashed changes:Assets/Scripts/States/StateMachine.cs
    }
}
