using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    protected bool inJump;
    public PlayerAttackState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }
}
