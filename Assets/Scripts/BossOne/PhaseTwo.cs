using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTwo : BaseState
{
    private MovementSM _sm;
    private float _numberOfBullets;


    public PhaseTwo(MovementSM stateMachine) : base("PhaseTwo", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _numberOfBullets = 10f;
        Debug.Log("Entered state 2");

    }

    public override void UpdateLogic()
    {
        Debug.Log("Stuck in Update logic phase 2");
        stateMachine.ChangeState(_sm.decisionState);
        stateMachine.startTimer();
    }
}
