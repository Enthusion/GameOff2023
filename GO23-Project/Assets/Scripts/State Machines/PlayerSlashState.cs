using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlashState : PlayerAttackState
{
    public PlayerSlashState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }
}
