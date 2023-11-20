using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Enemy Data", menuName="Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int enemyId;
    public int aggressionLevel; //0 is non attack, 1 is attack back, 2 is on sight
    public float energyValue; //Energy given to palyers on hit
    public bool contactDamage; //Does the enemy do contact damage
    public float damageAmount; //How much damage does the enemy do
    public bool stationary; //Does the stay in one place?
    public float moveForce = 8.0f;
    public float patrolRange; //How far back and forth between the original spawn point the enemy will patrol
    public float lineOfSight; //How far an enemy can see
    public float detectionProximity; //How close umtil the enemy automatically knows the player is there.
    public float edgeDetection; //Can the enemy detect edges
    // public GameObject attackObject; //The attack prefab the enemy uses
    // public float attackOffestX; //The X offset of the attack spawn point
    // public float attackOffsetY; //The Y offset of the attack spawn point
    // public float attackCooldown; //Time between each attack
    // public int multiAttack = 0; //How many attacks does one attack contain
    // public float burstCooldown; //What is the time between each attack in a multi-attack
    public LayerMask isGround;
}
