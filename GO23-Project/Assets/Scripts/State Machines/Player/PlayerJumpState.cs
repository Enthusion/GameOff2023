using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private float initialSpeed;
    private float speedCap;
    public PlayerJumpState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        //Set a horizontal speed capacity based on either the speed when entering the sate or 5, whatever is greater
        initialSpeed = Mathf.Abs(playerController.Body.velocity.x);
        speedCap = (initialSpeed >= 7.0f) ? initialSpeed : 7.0f;
        //Add initial jump force
        playerController.SetVelocityY(playerController.jumpForce);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        //Air control
        float movementInput = Input.GetAxis("Horizontal");
        playerController.Body.AddForce(Vector2.right * movementInput * (playerController.moveForce / 2));
        if (movementInput > 0) playerController.Sprite.flipX = false;
        else if (movementInput < 0) playerController.Sprite.flipX = true;
        //Variable jump height
        if (runtime < playerController.jumpTime && Input.GetButton("Jump"))
        {
            playerController.Body.AddForce(Vector2.up * playerController.jumpForce * 1.66f);
        } //Slightly decrease gravity near peak of jump
        else if (runtime >= playerController.jumpTime && playerController.Body.velocity.y < 1.5f)
        {
            playerController.SetGravityScale(0.8f);
        }
        //Exiting jump state when no longer moving up
        if (playerController.Body.velocity.y <= 0.0f)
        {
            abilityTriggered = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //Ensure horizontal velocity is within speed capacity
        playerController.SetVelocityX(Mathf.Clamp(playerController.Body.velocity.x, -speedCap, speedCap));
    }
}