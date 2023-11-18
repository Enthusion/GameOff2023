using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D Body;
    public EnemyData enemyData;
    private int enemyId;
    private int aggressionLevel; //0 is non attack, 1 is attack back, 2 is on sight
    private float energyValue; //Energy given to palyers on hit
    private bool contactDamage; //Does the enemy do contact damage
    private float damageAmount; //How much damage does the enemy do
    private bool stationary; //Does the stay in one place?
    private float moveForce; //The force the enemy moves with
    private float patrolRange; //How far back and forth between the original spawn point the enemy will patrol
    private float lineOfSight; //How far an enemy can see
    private float detectionProximity; //How close umtil the enemy automatically knows the player is there.
    private float edgeDetection; //Can the enemy see edges

    //Awake is called as soon as the script is loaded, before start
    void Awake(){
        enemyId = enemyData.enemyId;
        aggressionLevel = enemyData.enemyId;
        energyValue = enemyData.energyValue;
        contactDamage = enemyData.contactDamage;
        damageAmount = enemyData.damageAmount;
        stationary = enemyData.stationary;
        moveForce = enemyData.moveForce;
        patrolRange = enemyData.patrolRange;
        lineOfSight = enemyData.lineOfSight;
        detectionProximity = enemyData.detectionProximity;
        edgeDetection = enemyData.edgeDetection;
    }
    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: If enemy is not within BLANK distance to target run MoveTowardTarget function
        
    }

    //TODO: Set up MoveTowardTarget function that calculates the direction of the target and moves toward them.
}
