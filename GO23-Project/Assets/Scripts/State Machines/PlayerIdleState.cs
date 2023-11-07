using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
   public PlayerIdleState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    {}
}
