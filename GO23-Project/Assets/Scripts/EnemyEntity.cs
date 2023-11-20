using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : LivingEntity
{
    public EnemyData enemyData;
    protected float energyValue;
    protected bool contactDamage;
    protected float damageAmount;
    public override void Awake()
    {
        base.Awake();
        energyValue = enemyData.energyValue;
        contactDamage = enemyData.contactDamage;
        damageAmount = enemyData.damageAmount;
    }
    public override void TakeDamage(float damageValue, GameObject damageSource)
    {
        base.TakeDamage(damageValue, damageSource);
        //TODO damaged effect on spirte
        if(damageSource.TryGetComponent<PlayerController>(out PlayerController player)){
            player.AdjustEnergy(energyValue);
        }
    }

    protected void OnCollisionEnter2D(Collider otherEntity){
        if(otherEntity.gameObject.TryGetComponent(out IDamageable damageableEntity)){
            // damageableEntity.TakeDamage
        }
    }
}
