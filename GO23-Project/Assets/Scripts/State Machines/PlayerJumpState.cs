using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    {}

    public override void Enter()
    {
        base.Enter();
        playerController.SetVelocityY(playerController.jumpForce);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(runtime >= playerController.jumpTime){
            abilityTriggered = true;
        }
    }
}
