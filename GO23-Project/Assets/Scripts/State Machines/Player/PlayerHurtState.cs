using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerAbilityState
{
    public PlayerHurtState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(runtime >= 0.5f) abilityTriggered = true;
    }
}
