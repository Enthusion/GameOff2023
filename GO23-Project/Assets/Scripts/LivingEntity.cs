using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : KillableEntity
{
    protected Rigidbody2D Body;
    protected Vector2 damageDriection;
    public override void Start()
    {
        base.Start();
        Body = GetComponent<Rigidbody2D>();

        damageDriection = Vector2.zero;
    }
    public override void TakeDamage(float damageValue, GameObject damageSource)
    {
        base.TakeDamage(damageValue, damageSource);
        damageDriection = damageSource.transform.position - transform.position;
        damageDriection = damageDriection.normalized;

    }
}
