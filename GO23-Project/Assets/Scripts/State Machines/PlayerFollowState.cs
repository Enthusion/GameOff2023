using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowState : PlayerInactiveState
{
    private Vector2 followOffset;
    public PlayerFollowState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        playerController.Following = true;
        playerController.Body.gravityScale = 0;
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(Input.GetButtonDown("Swap") && isSecondGrounded){
            stateMachine.ChangeState(playerController.FallState);
        }
        if(Input.GetButtonDown("Follow")){
            stateMachine.ChangeState(playerController.WaitState);
        }
        followOffset = new Vector2(playerController2.Sprite.flipX ? 0.75f : -0.75f, 0.45f);
        Vector2 targetPosition = playerController2.Body.position + followOffset;
        if(Vector3.Distance(playerController.transform.position, new Vector3(targetPosition.x, targetPosition.y, 0.0f)) > 0.005f){
            playerController.InterpolateTranslate(targetPosition, 7.5f);
        }
    }

    public override void Exit()
    {
        base.Exit();
        playerController.Following = false;
        playerController.Body.gravityScale = 1;
    }
}
