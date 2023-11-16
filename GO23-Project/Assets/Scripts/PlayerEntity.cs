using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void TakeDamage(float damageValue, GameObject damageSource)
    {
        base.TakeDamage(damageValue, damageSource);
    }
    public override void Die()
    {
        base.Die();
    }
}
