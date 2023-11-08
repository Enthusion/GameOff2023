using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    protected float initialSpeed;
    public PlayerFallState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        initialSpeed = Mathf.Abs(playerController.Body.velocity.x);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        float movementInput = Input.GetAxis("Horizontal");
        if (playerController.GroundCheck() && playerController.Body.velocity.y < 0.01f)
        {
            stateMachine.ChangeState(playerController.IdleState);
        }
        playerController.Body.AddForce(Vector2.right * movementInput * (playerController.moveForce / 2));
        if (movementInput > 0) playerController.Sprite.flipX = false;
        else playerController.Sprite.flipX = true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        playerController.SetVelocityX(Mathf.Clamp(playerController.Body.velocity.x, -initialSpeed, initialSpeed));
    }
}
