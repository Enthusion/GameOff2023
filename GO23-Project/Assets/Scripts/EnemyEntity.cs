using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : LivingEntity
{
    //TODO: Create EnemyData ScriptableObject
    // public EnemyData enemyData;
    protected float energyValue;
    public override void Awake()
    {
        base.Awake();
        // energyValue = enemyData.energyValue;
    }
    public override void TakeDamage(float damageValue, GameObject damageSource)
    {
        base.TakeDamage(damageValue, damageSource);
        //TODO damaged effect on spirte
        if(damageSource.TryGetComponent<PlayerController>(out PlayerController player)){
            player.AdjustEnergy(energyValue);
        }
    }
}
