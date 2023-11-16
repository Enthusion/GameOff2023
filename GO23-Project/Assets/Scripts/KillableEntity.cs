using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableEntity : MonoBehaviour, IDamageable
{
    public float health{ get; protected set;}
    public float baseHealth{ get; protected set;}

    public virtual void TakeDamage(float damageValue, GameObject damageSource){}

    public virtual void Die(){}
}
