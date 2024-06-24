using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController player;
    
    public IdleState(PlayerController player)
    {
        this.player = player;
    }
    
    public void Enter()
    {
        
    }

    public void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            player.stateMachine.TransitionTo(new WalkState(player));
        }
        if (Input.GetButtonDown("Jump"))
        {
            player.stateMachine.TransitionTo(new JumpState(player));
        }
    }

    public void Exit()
    {
       
    }
}

