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
            stateMachine.ChangeState(workingController.IdleState);
        }
        else if (movementInput > 0) workingController.Sprite.flipX = false;
        else workingController.Sprite.flipX = true;
        workingController.Body.AddForce(Vector2.right * movementInput * workingController.moveForce);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        workingController.SetVelocityX(Mathf.Clamp(playerVelocity.x, -workingController.maxSpeed, workingController.maxSpeed));
    }

}
