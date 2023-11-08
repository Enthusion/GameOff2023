using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool abilityTriggered;
    private bool isGrounded;
    protected float runtime;
    public PlayerAbilityState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        runtime = 0.0f;
        abilityTriggered = false; //Is turned to true within the ability state.
        isGrounded = playerController.GroundCheck();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        runtime += Time.deltaTime;
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
