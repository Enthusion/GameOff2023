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
            stateMachine.ChangeState(playerController.JumpState);
        }
        else if (!playerController.GroundCheck())
        {
            stateMachine.ChangeState(playerController.FallState);
        }

        if (Input.GetButtonDown("Swap"))
        {
            if (!playerController2.GroundCheck())
            {
                stateMachine.ChangeState(playerController.FollowState);
            }
            else {
                stateMachine.ChangeState(playerController.WaitState);
            }
        }

        // if (Input.GetKeyDown("q"))
        // {
        //     playerController.AdjustScale(0.25f);
        //     playerController2.AdjustScale(-0.25f);
        // }
        // if (Input.GetKeyDown("r"))
        // {
        //     playerController.AdjustScale(-0.25f);
        //     playerController2.AdjustScale(0.25f);
        // }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        playerVelocity = playerController.Body.velocity;
    }
}
