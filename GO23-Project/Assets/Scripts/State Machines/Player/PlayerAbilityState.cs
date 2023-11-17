using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool abilityTriggered;
    private bool isGrounded;
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
                stateMachine.ChangeState(playerController.IdleState);
            }
            else{
                stateMachine.ChangeState(playerController.FallState);
            }
        }
    }
}