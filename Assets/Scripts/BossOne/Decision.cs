using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

<<<<<<< Updated upstream
public class Decision : BaseState
=======
namespace Bosses
>>>>>>> Stashed changes
{
    
    private MovementSM _sm;

    private float distance;
    public GameObject player;
    public GameObject boss;

    public Decision(MovementSM stateMachine) : base("Decision", stateMachine)
    {
<<<<<<< Updated upstream
        _sm = stateMachine;
=======

        private readonly BossOneSm _sm;
        public Decision(BossOneSm stateMachine) : base("Decision", stateMachine)
        {
            _sm = stateMachine;
        }
        private Vector2 movement;
        private const float MakeDecisionTime = 4f;

        public GameObject player;
        public GameObject boss;


        private float _distance;
        private float speed = 3f;
        private float _elapsedTime;
        public override void Enter()
        {
            _elapsedTime = 0;
            Debug.Log($"Entered Decision - Need to wait {MakeDecisionTime} before changing to a phase.");
            
        }


        public override void UpdateLogic()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < MakeDecisionTime)
            {
                return;
            }
            
            Debug.Log("Update Decision - Making new decision.");

            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            if (boss == null)
            {
                boss = GameObject.FindGameObjectWithTag("Boss");
            }

            _distance = Vector2.Distance(boss.transform.position, player.transform.position);
             movement = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            
            if (_distance < 11)
            {
                Debug.Log("Update Decision - Changing to Phase 1.");
                stateMachine.ChangeState(_sm.phaseOneState);
            }
            else if (_distance >= 11)
            {
                Rigidbody2D rb = boss.GetComponent<Rigidbody2D>();
                rb.AddForce(movement * speed);
                Debug.Log("Update Decision - Changing to Phase 2.");
                stateMachine.ChangeState(_sm.phaseTwoState);
            }
        }

        public override void Exit()
        {
            Debug.Log("Exited Decision - Switching to a phase.");
        }

>>>>>>> Stashed changes
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
