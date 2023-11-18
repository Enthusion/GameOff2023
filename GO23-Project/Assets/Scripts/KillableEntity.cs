using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableEntity : MonoBehaviour, IDamageable
{
    protected float health;
    protected Collider2D Collider;
    public virtual void Awake(){}
    public virtual void Start(){
        if(TryGetComponent<BoxCollider2D>(out BoxCollider2D colliderA)){
            Collider = colliderA;
        }
        else if(TryGetComponent<CapsuleCollider2D>(out CapsuleCollider2D colliderB)){
            Collider = colliderB;
        }
        else if(TryGetComponent<CircleCollider2D>(out CircleCollider2D colliderC)){
            Collider = colliderC;
        }
    }
    public virtual void Update(){}
    public virtual void FixedUpdate(){}
    public virtual void TakeDamage(float damageValue, GameObject damageSource){
        health -= damageValue;
        if(health <= 0){
            Die();
        }
    }

    public virtual void Die(){}
}
