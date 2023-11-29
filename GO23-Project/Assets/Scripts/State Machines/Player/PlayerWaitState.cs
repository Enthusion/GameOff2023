using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaitState : PlayerInactiveState
{
    private float movemnetLength = 0;
    public PlayerWaitState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(Input.GetButtonDown("Swap") && isSecondGrounded){
            stateMachine.ChangeState(playerController.IdleState);
        }
        if(Input.GetButtonDown("Follow") && distanceBetween <= 3.0f){
            stateMachine.ChangeState(playerController.FollowState);
        }
        if (playerController.GroundCheck() && playerController.Body.velocity != Vector2.zero)
        {
            movemnetLength += Time.deltaTime;
            playerController.Body.velocity = Vector2.Lerp(playerController.Body.velocity, Vector2.zero, movemnetLength);
        }else{
            movemnetLength = 0;
        }
    }
}
