using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
   public PlayerIdleState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    {}

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(movementInput != 0){
            stateMachine.ChangeState(playerController.MoveState);
        }
    }
}
