using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    private Vector2 initialVelocity;
    public PlayerIdleState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        initialVelocity = playerController.Body.velocity;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (movementInput != 0)
        {
            stateMachine.ChangeState(playerController.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (playerVelocity != Vector2.zero)
        {
            playerController.Body.velocity = Vector2.Lerp(initialVelocity, Vector2.zero, runtime / 0.2f);
        }
        
    }
}
