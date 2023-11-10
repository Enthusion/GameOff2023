using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowState : PlayerInactiveState
{
    public PlayerFollowState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(Input.GetButtonDown("Swap") && isSecondGrounded){
            stateMachine.ChangeState(playerController.IdleState);
        }
    }
}
