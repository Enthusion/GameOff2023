using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : KillableEntity
{
    protected Rigidbody2D Body;
    protected SpriteRenderer Sprite;
    public override void Start()
    {
        base.Start();
        Body = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
    }
    public override void TakeDamage(float damageValue, GameObject damageSource)
    {
        base.TakeDamage(damageValue, damageSource);
    }
}
