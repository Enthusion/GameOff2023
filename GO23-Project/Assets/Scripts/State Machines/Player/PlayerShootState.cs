using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerAttackState
{
    public PlayerShootState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }
}
