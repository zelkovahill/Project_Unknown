using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    
    private PlayerController player;
    
    public JumpState(PlayerController player)
    {
        this.player = player;
    }
    
    public void Enter()
    {
       
    }

    public void Update()
    {
        if (player.isGrounded)
        {
            player.stateMachine.TransitionTo(new IdleState(player));
        }
    }

    public void Exit()
    {
       
    }
}

