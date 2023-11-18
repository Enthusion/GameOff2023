using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Enemy Data", menuName="Enemy Data")]
public class EnemyData : ScriptableObject
{
    public int enemyId;
    public int aggressionLevel; //0 is non attack, 1 is attack back, 2 is on sight
    public float energyValue; //Energy given to palyers on hit
    public bool contactDamage; //Does the enemy do contact damage
    public bool stationary; //Does the stay in one place?
    public float moveForce = 8.0f;
    public float patrolRange; //How far back and forth between the original spawn point the enemy will patrol
    public float LineOfSight; //How far an enemy can see
    public float detectionProximity; //How close umtil the enemy automatically knows the player is there.
    public float edgeDetection; //Can the enemy detect edges
}
