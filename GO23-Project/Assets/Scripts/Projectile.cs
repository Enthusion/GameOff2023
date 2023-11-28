using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float Range;
    protected float damage;
    protected GameObject origin;
    // protected Collider2D projectileCollider;
    protected Rigidbody2D body;
    protected float lifeTime = 3;


    public virtual void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public virtual void Initialization(GameObject sourceObj, float damageVal, bool overideStats = false, float newSpeed = 1, float newRange = 10)
    {
        origin = sourceObj;
        damage = damageVal;
        if (overideStats)
        {
            Speed = newSpeed;
            Range = newRange;
        }
        lifeTime = Range / Speed;
    }

}
