using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private float movementScaleFactor;
    public PlayerMoveState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        movementScaleFactor = 1 + (Mathf.Abs(playerVelocity.x) / playerController.maxSpeed) * 4;
        if (movementInput == 0)
        {
            stateMachine.ChangeState(playerController.IdleState);
        }
        else if (movementInput > 0)
        {
            playerController.Sprite.flipX = false;
            if (playerVelocity.x >= 0)
            {
                movementScaleFactor = 1.0f;
            }
        }
        else
        {
            playerController.Sprite.flipX = true;
            if (playerVelocity.x <= 0)
            {
                movementScaleFactor = 1.0f;
            }
        }
        playerController.Body.AddForce(Vector2.right * movementInput * playerController.moveForce * movementScaleFactor);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        playerController.SetVelocityX(Mathf.Clamp(playerVelocity.x, -playerController.maxSpeed, playerController.maxSpeed));
    }

}
