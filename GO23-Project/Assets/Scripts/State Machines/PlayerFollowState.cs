using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowState : PlayerInactiveState
{
    public PlayerFollowState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        playerController.Following = true;
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(Input.GetButtonDown("Swap")){
            if(isSecondGrounded) stateMachine.ChangeState(playerController.IdleState);
            else stateMachine.ChangeState(playerController.FallState);
        }
        if(Input.GetButtonDown("Follow")){
            stateMachine.ChangeState(playerController.WaitState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        playerController.Following = false;
    }
}
