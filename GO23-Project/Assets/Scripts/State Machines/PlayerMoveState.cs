using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (movementInput == 0)
        {
            stateMachine.ChangeState(playerController.IdleState);
        }
        else if (movementInput > 0) playerController.Sprite.flipX = false;
        else playerController.Sprite.flipX = true;
        playerController.Body.AddForce(Vector2.right * movementInput * playerController.moveForce);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        playerController.Body.velocity = new Vector2(Mathf.Clamp(playerVelocity.x, -playerController.maxSpeed, playerController.maxSpeed), playerVelocity.y);
    }

}
