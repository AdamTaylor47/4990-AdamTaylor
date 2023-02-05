using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseOne : BaseState
{
    private MovementSM _sm;
    private float _numberOfBullets;

    public PhaseOne(MovementSM stateMachine) : base("PhaseOne", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _numberOfBullets = 5f;
        Debug.Log("Entered state 1");

    }

    public override void UpdateLogic()
    {
        Debug.Log("Stuck in Update logic phase 1");
        stateMachine.ChangeState(_sm.decisionState);
        stateMachine.startTimer();


    }
}
