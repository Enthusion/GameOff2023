using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    protected float initialSpeed;
    private float speedCap;
    private bool fromJump;
    private bool countForJump;
    private float sinceJumpPressed;
    public PlayerFallState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        countForJump = false;
        sinceJumpPressed = 100.0f;
        //Set a horizontal speed capacity based on either the speed when entering the sate or 5, whatever is greater
        initialSpeed = Mathf.Abs(playerController.Body.velocity.x);
        speedCap = (initialSpeed >= 5.0f) ? initialSpeed : 5.0f;
        // Check if fall is from a jump (when switching from jump to fall gravity is set to 1.1)
        fromJump = playerController.Body.gravityScale == 1.1f;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        //Air control
        float movementInput = Input.GetAxis("Horizontal");
        playerController.Body.AddForce(Vector2.right * movementInput * (playerController.moveForce / 2));
        if (movementInput > 0) playerController.Sprite.flipX = false;
        else if (movementInput < 0) playerController.Sprite.flipX = true;

        // if(Input.GetButtonDown("Fire1")){
        //     stateMachine.ChangeState(playerController.ShootState);
        // }
        
        //Increase gravity scale to fall faster once falling for JumpTime
        if (runtime >= playerController.jumpTime)
        {
            playerController.SetGravityScale(1.66f);
            if (Input.GetButtonDown("Jump"))
            {
                countForJump = true;
                sinceJumpPressed = 0.0f;
            }
        }
        else
        {
            //Unsure what this gravity set was for
            // playerController.SetGravityScale(0.8f + runtime * 1.5f);

            //Coyote time
            if (!fromJump && playerController.sinceLastGrounded < playerController.jumpTime)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    // Debug.Log("Coyote Time");
                    playerController.SetGravityScale(1.0f);
                    stateMachine.ChangeState(playerController.JumpState);
                }
            }
        }
        if (countForJump)
        {
            sinceJumpPressed += Time.deltaTime;
        }
        //Exit fall state and reset gravity when ground is detected
        if (playerController.GroundCheck() && playerController.Body.velocity.y < 0.01f)
        {
            playerController.SetGravityScale(1.0f);
            if (sinceJumpPressed > playerController.jumpTime) stateMachine.ChangeState(playerController.IdleState);
            else stateMachine.ChangeState(playerController.JumpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //Ensure horizontal velocity is within speed capacity
        playerController.SetVelocityX(Mathf.Clamp(playerController.Body.velocity.x, -speedCap, speedCap));
    }
}
