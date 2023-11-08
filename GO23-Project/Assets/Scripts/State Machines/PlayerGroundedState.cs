using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected float movementInput;
    protected Vector2 playerVelocity;
    public PlayerGroundedState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    {}

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        movementInput = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump")){
            stateMachine.ChangeState(playerController.JumpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        playerVelocity = playerController.Body.velocity;
    }
}
