using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Decision : BaseState
{
    
    private MovementSM _sm;

    private float distance;
    public GameObject player;
    public GameObject boss;

    public Decision(MovementSM stateMachine) : base("Decision", stateMachine)
    {
        _sm = stateMachine;
    }



    public override void Enter()
    {
        base.Enter();
        
        
    }

    public override void UpdateLogic()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        distance = Vector2.Distance(boss.transform.position, player.transform.position);
        Debug.Log("distance = " + distance);
        if (distance < 10)
        {
            Debug.Log("Changing to state 1");
            stateMachine.ChangeState(_sm.phaseOneState);
            


        }
        else if (distance >= 10)
        {
            Debug.Log("Changing to state 2");
            stateMachine.ChangeState(_sm.phaseTwoState);
            

        }
        //base.UpdateLogic();

    }

}
