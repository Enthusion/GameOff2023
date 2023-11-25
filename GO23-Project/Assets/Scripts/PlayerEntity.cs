using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntity
{
    protected PlayerController playerContol;
    protected Vector2 kbForce;
    protected float invincibilityTime = 0;
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
        playerContol = GetComponent<PlayerController>();
        health = GameManager.Instance.GetHealth(playerContol.characterId);
        GameManager.Instance.UpdateHealth(health, playerContol.characterId);
    }
    public override void Update()
    {
        base.Update();
        if(invincibilityTime > 0) invincibilityTime -= Time.deltaTime;
    }
    public override void TakeDamage(float damageValue, GameObject damageSource)
    {
        if(invincibilityTime > 0) return;
        base.TakeDamage(damageValue, damageSource);
        invincibilityTime = 0.5f;
        if(playerContol.GroundCheck()){
            kbForce += Vector2.up;
        }
        playerContol.ApplyKnockback(kbForce);
        // Debug.Log("Health: " + health);
        GameManager.Instance.UpdateHealth(health, playerContol.characterId);
    }
    public override void Die()
    {
        base.Die();
    }
    public void KnockbackInfo(Vector2 knockbackForce) => kbForce = knockbackForce;
}
