using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D Body;
    private SpriteRenderer Sprite;
    public GameObject GroundPoint;
    private bool atTarget;
    private bool hitTarget;
    private float timeSinceReached;
    private float distanceToTarget;
    private Vector2 targetPoint;
    private Vector2 OnePoint;
    private Vector2 TwoPoint;
    private bool readyForAction;
    private Vector2 approachVelocity = Vector2.zero;
    public EnemyData enemyData;
    private int enemyId;
    private int aggressionLevel; //0 is non attack, 1 is attack back, 2 is on sight
    private float energyValue; //Energy given to palyers on hit
    private bool contactDamage; //Does the enemy do contact damage
    private float damageAmount; //How much damage does the enemy do
    private bool stationary; //Does the stay in one place?
    private float moveForce; //The force the enemy moves with
    private float maxSpeed;
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
        maxSpeed = enemyData.maxSpeed;
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
        // When first touching the ground update patrol points to ground level
        if (!readyForAction && GroundCheck())
        {
            OnePoint = new Vector2(OnePoint.x, Body.position.y);
            TwoPoint = new Vector2(TwoPoint.x, Body.position.y);
            targetPoint = OnePoint;
            readyForAction = true;
        }

        // Switch target points if arrived at target
        if (atTarget)
        {
            if (targetPoint == TwoPoint)
            {
                targetPoint = OnePoint;
            }
            else
            {
                targetPoint = TwoPoint;
            }
            atTarget = false;
        }

        if (!hitTarget && !stationary) MoveTowardTarget();

        // Flip the enemy to face in the direction they are moving.
        if (Body.velocity.x != 0)
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

    void FixedUpdate()
    {
        distanceToTarget = Vector2.Distance(Body.position, targetPoint);
        if (distanceToTarget <= 0.2f) hitTarget = true;

        // If passed the target come to a stop
        if (hitTarget)
        {
            timeSinceReached += Time.fixedDeltaTime;
            if (approachVelocity == Vector2.zero)
            {
                approachVelocity = Body.velocity;
                timeSinceReached = 0.0f;
            }
            Body.velocity = Vector2.Lerp(approachVelocity, Vector2.zero, timeSinceReached / 0.2f);
            if (Body.velocity == Vector2.zero)
            {
                hitTarget = false;
                atTarget = true;
            }
        }
        else
        {
            approachVelocity = Vector2.zero;
        }
        // Limit movement speed by maxSpeed;
        Body.velocity = new Vector2(Mathf.Clamp(Body.velocity.x, -maxSpeed, maxSpeed), Body.velocity.y);
    }

    // Calculates the direction to the targetPoint and moves toward them.
    private void MoveTowardTarget()
    {
        if (!readyForAction) return;
        Vector2 directionToTarget = (targetPoint - Body.position).normalized;
        Body.AddForce(directionToTarget * moveForce);
    }
    public bool GroundCheck() => Physics2D.OverlapCircle(GroundPoint.transform.position, 0.15f, isGround);
}
