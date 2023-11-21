using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : LivingEntity
{
    public EnemyData enemyData;
    protected float baseHealth;
    protected float energyValue;
    protected bool contactDamage;
    protected float damageAmount;
    public override void Awake()
    {
        base.Awake();
        baseHealth = enemyData.baseHealth;
        energyValue = enemyData.energyValue;
        contactDamage = enemyData.contactDamage;
        damageAmount = enemyData.damageAmount;

        health = baseHealth;
    }
    public override void TakeDamage(float damageValue, GameObject damageSource)
    {
        base.TakeDamage(damageValue, damageSource);
        //TODO damaged effect on spirte
        if(damageSource.TryGetComponent<PlayerController>(out PlayerController player)){
            player.AdjustEnergy(energyValue);
        }
    }

    protected void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.TryGetComponent(out IDamageable damageableEntity)){
            damageableEntity.TakeDamage(damageAmount, this.gameObject);
        }
    }
}
