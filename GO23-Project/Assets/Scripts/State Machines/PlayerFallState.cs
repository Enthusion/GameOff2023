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
        initialSpeed = Mathf.Abs(workingController.Body.velocity.x);
        speedCap = (initialSpeed >= 5.0f) ? initialSpeed : 5.0f;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        float movementInput = Input.GetAxis("Horizontal");
        if (workingController.GroundCheck() && workingController.Body.velocity.y < 0.01f)
        {
            stateMachine.ChangeState(workingController.IdleState);
        }
        workingController.Body.AddForce(Vector2.right * movementInput * (workingController.moveForce / 2));
        if (movementInput > 0) workingController.Sprite.flipX = false;
        else workingController.Sprite.flipX = true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        workingController.SetVelocityX(Mathf.Clamp(workingController.Body.velocity.x, -speedCap, speedCap));
    }
}
