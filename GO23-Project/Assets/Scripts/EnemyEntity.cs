using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : LivingEntity
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void TakeDamage(float damageValue, GameObject damageSource)
    {
        base.TakeDamage(damageValue, damageSource);
    }
}
