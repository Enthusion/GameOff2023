using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(playerController.GroundCheck() && playerController.Body.velocity.y < 0.01f){
            stateMachine.ChangeState(playerController.IdleState);
        }
    }
}
