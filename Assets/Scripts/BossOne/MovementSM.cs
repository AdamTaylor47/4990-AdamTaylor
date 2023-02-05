using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Moving movingState;
    [HideInInspector]
    public PhaseOne phaseOneState;
    [HideInInspector]
    public PhaseTwo phaseTwoState;
    [HideInInspector]
    public Decision decisionState;

    public Rigidbody2D rigidbody;
    public float speed = 4f;

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        phaseOneState = new PhaseOne(this);
        phaseTwoState = new PhaseTwo(this);
        decisionState = new Decision(this);
    }

    protected override BaseState GetInitialState()
    {
        return decisionState;
    }
}
