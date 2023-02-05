using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
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
    }
}
