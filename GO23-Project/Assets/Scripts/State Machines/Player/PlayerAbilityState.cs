using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool abilityTriggered;
    protected bool isGrounded;
    public PlayerAbilityState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        abilityTriggered = false; //Is turned to true within the ability state.
        isGrounded = playerController.GroundCheck();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(abilityTriggered){
            if(isGrounded && playerController.Body.velocity.y < 0.01f){
                playerController.SetGravityScale(1.0f);
                stateMachine.ChangeState(playerController.IdleState);
            }
            else{
                stateMachine.ChangeState(playerController.FallState);
            }
        }
    }
}
