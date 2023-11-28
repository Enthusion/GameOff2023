using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    protected bool inJump;
    protected Vector2 initialVelocity;
    protected float baseDamage;
    protected float balanceFactor;
    public PlayerAttackState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        baseDamage = playerController.baseDamage;
        initialVelocity = playerController.Body.velocity;
        if(playerController.Body.gravityScale < 1.0f && playerController.Body.gravityScale > 0.8f){
            inJump = true;
        }
        balanceFactor = GameManager.Instance.GetBalance();
    }
}
