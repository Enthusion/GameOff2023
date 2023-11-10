using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    private Vector2 initialVelocity;
    private float runtime;
    public PlayerIdleState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        initialVelocity = workingController.Body.velocity;
        runtime = 0.0f;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        runtime += Time.deltaTime;
        if (movementInput != 0)
        {
            stateMachine.ChangeState(workingController.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (playerVelocity != Vector2.zero)
        {
            workingController.Body.velocity = Vector2.Lerp(initialVelocity, Vector2.zero, runtime / 0.25f);
        }
        
    }
}
