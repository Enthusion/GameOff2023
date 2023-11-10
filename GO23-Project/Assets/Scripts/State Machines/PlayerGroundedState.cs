using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected float movementInput;
    protected Vector2 playerVelocity;
    public PlayerGroundedState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        movementInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            stateMachine.ChangeState(workingController.JumpState);
        }
        else if (!workingController.GroundCheck())
        {
            stateMachine.ChangeState(workingController.FallState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        playerVelocity = workingController.Body.velocity;
    }
}
