using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Range;
    public float KnockbackForce = 0;
    protected float damage;
    protected GameObject origin;
    // protected Collider2D projectileCollider;
    protected Rigidbody2D body;
    protected float lifeTime = 3;
    protected bool useConstantVelocity = true;


    public virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
        lifeTime = Range / Speed;
    }

    public virtual void Update()
    {
        if (useConstantVelocity)
        {
            body.velocity = transform.right * Speed;
        }

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Terminate();
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out IDamageable damageableEntity))
        {
            if (KnockbackForce > 0)
            {
                Rigidbody2D entityBody = col.attachedRigidbody;
                if (entityBody != null)
                {
                    Vector2 collisionDir = entityBody.position - body.position;
                    if (col.gameObject.TryGetComponent(out PlayerEntity player))
                    {
                        player.KnockbackInfo(collisionDir * (KnockbackForce / 2));
                    }
                    else entityBody.AddForce(collisionDir.normalized * KnockbackForce, ForceMode2D.Impulse);

                }
            }
            damageableEntity.TakeDamage(damage, origin);
        }
        Terminate();
    }

    public virtual void Initialization(GameObject sourceObj, float damageVal, bool overideStats = false, float newSpeed = 1, float newRange = 10, float newKnockback = 10)
    {
        origin = sourceObj;
        damage = damageVal;
        if (overideStats)
        {
            Speed = newSpeed;
            Range = newRange;
            KnockbackForce = newKnockback;
        }
        lifeTime = Range / Speed;
    }

    public virtual void Terminate()
    {
        //Any special effects for projectile termination
        Destroy(gameObject);
    }
}
