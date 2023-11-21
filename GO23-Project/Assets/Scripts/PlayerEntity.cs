using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
    protected PlayerController playerContol;
    protected Vector2 kbForce;
    public override void Awake()
    {
        base.Awake();
        health = 15;
    }
    public override void Start()
    {
        base.Start();
        playerContol = GetComponent<PlayerController>();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void TakeDamage(float damageValue, GameObject damageSource)
    {
        base.TakeDamage(damageValue, damageSource);
        if(playerContol.GroundCheck()){
            kbForce += Vector2.up;
        }
        playerContol.ApplyKnockback(kbForce);
        Debug.Log("Health: " + health);
    }
    public override void Die()
    {
        base.Die();
    }
    public void KnockbackInfo(Vector2 knockbackForce) => kbForce = knockbackForce;
}
