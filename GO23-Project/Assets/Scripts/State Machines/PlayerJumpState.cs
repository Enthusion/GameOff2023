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
        workingController.SetVelocityY(workingController.jumpForce);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(runtime >= workingController.jumpTime){
            abilityTriggered = true;
        }
    }
}
