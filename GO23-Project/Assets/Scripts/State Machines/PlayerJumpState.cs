using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        playerController.SetVelocityY(playerController.jumpForce);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        float movementInput = Input.GetAxis("Horizontal");
        playerController.Body.AddForce(Vector2.right * movementInput * (playerController.moveForce / 2));
        if (movementInput > 0) playerController.Sprite.flipX = false;
        else if (movementInput < 0) playerController.Sprite.flipX = true;
        if (runtime < playerController.jumpTime && Input.GetButton("Jump"))
        {
            playerController.Body.AddForce(Vector2.up * playerController.jumpForce * 1.66f);
        }
        if (playerController.Body.velocity.y <= 0.0f)
        {
            abilityTriggered = true;
        }
    }
}
