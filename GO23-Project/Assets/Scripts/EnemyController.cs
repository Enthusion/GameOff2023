using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D Body;
    private SpriteRenderer Sprite;
    public GameObject GroundPoint;
    private bool atTarget;
    private Vector2 targetPoint;
    private Vector2 OnePoint;
    private Vector2 TwoPoint;
    private bool readyForAction;
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
    private LayerMask isGround;

    //Awake is called as soon as the script is loaded, before start
    void Awake()
    {
        readyForAction = false;

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
        isGround = enemyData.isGround;
    }
    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();

        if (patrolRange == 0)
        {
            targetPoint = Body.position;
        }
        else
        {
            OnePoint = Body.position - new Vector2(patrolRange, 0);
            TwoPoint = Body.position + new Vector2(patrolRange, 0);
            targetPoint = OnePoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!readyForAction && GroundCheck()){
            OnePoint = new Vector2(OnePoint.x, Body.position.y);
            TwoPoint = new Vector2(TwoPoint.x, Body.position.y);
            readyForAction = true;
        }
        
        if (atTarget == true)
        {
            if (targetPoint == TwoPoint)
            {
                targetPoint = OnePoint;
            }
            else
            {
                targetPoint = TwoPoint;
            }
        }

        // If enemy is not within 0.1f of the targetPoint run MoveTowardTarget function
        if (!stationary && Vector2.Distance(Body.position, targetPoint) > 0.15f)
        {
            atTarget = false;
            MoveTowardTarget();
        }
        else
        {
            atTarget = true;
        }

        // If arrived at target come to a stop
        if (atTarget && Body.velocity != Vector2.zero)
        {
            Body.velocity = new Vector2(0, Body.velocity.y);
        }

        // Flip the enemy to face in the direction they are moving.
        if (Body.velocity != Vector2.zero)
        {
            if (Body.velocity.x > 0)
            {
                Sprite.flipX = false;
            }
            else
            {
                Sprite.flipX = true;
            }
        }

    }

    // Calculates the direction to the targetPoint and moves toward them.
    private void MoveTowardTarget()
    {
        if(!readyForAction) return;
        Vector2 directionToTarget = (targetPoint - Body.position).normalized;
        Body.AddForce(directionToTarget * moveForce);
    }
    public bool GroundCheck() => Physics2D.OverlapCircle(GroundPoint.transform.position, 0.15f, isGround);
}
