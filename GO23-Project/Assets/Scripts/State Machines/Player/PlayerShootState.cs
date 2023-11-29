using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerAttackState
{
    private float damageValue;
    private Vector3 shootPoint;
    private Projectile projectileInstance;
    public PlayerShootState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        if (playerController.characterId == 0)
        {
            damageValue = baseDamage + balanceFactor;
        }
        else
        {
            damageValue = baseDamage - balanceFactor;
        }
        shootPoint = new Vector3(playerController.Body.position.x + (!playerController.Sprite.flipX ? 0.6f : -0.6f), playerController.Body.position.y, 0);
        GameObject createdInstance = playerController.CreateObject(playerController.mainProjectile, shootPoint);
        createdInstance.transform.right = new Vector3(shootPoint.x + (!playerController.Sprite.flipX ? 1 : -1), shootPoint.y, 0) - createdInstance.transform.position;
        projectileInstance = createdInstance.GetComponent<Projectile>();
        projectileInstance.Initialization(playerController.gameObject, damageValue);
        if(inJump) stateMachine.ChangeState(playerController.JumpState);
        else abilityTriggered = true;
    }
}
