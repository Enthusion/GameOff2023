using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    protected float initialSpeed;
    private float speedCap;
    public PlayerFallState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        //Set a horizontal speed capacity based on either the speed when entering the sate or 5, whatever is greater
        initialSpeed = Mathf.Abs(playerController.Body.velocity.x);
        speedCap = (initialSpeed >= 5.0f) ? initialSpeed : 5.0f;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        //Air control
        float movementInput = Input.GetAxis("Horizontal");
        playerController.Body.AddForce(Vector2.right * movementInput * (playerController.moveForce / 2));
        if (movementInput > 0) playerController.Sprite.flipX = false;
        else if (movementInput < 0) playerController.Sprite.flipX = true;
        //Increase gravity scale to fall faster once falling for JumpTime
        if(runtime >= playerController.jumpTime){
            playerController.SetGravityScale(1.66f);
        }
        else{
            playerController.SetGravityScale(0.8f + runtime * 1.5f);
        }
        //Exit fall state and reset gravity when ground is detected
        if (playerController.GroundCheck() && playerController.Body.velocity.y < 0.01f)
        {
            playerController.SetGravityScale(1.0f);
            stateMachine.ChangeState(playerController.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //Ensure horizontal velocity is within speed capacity
        playerController.SetVelocityX(Mathf.Clamp(playerController.Body.velocity.x, -speedCap, speedCap));
    }
}
