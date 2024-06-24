using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
    private PlayerController player;
    
    public WalkState(PlayerController player)
    {
        this.player = player;
    }
    
    public void Enter()
    {
     
    }
    
    public void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float strafeInput = Input.GetAxis("Horizontal");
        player.Move(moveInput,strafeInput);

        if (moveInput == 0)
        {
            player.stateMachine.TransitionTo(new IdleState(player));
        }
        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
        }
    }
    
    public void Exit()
    {
     
    }
}
