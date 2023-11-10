using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    //STATES
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }

    public Animator Anima { get; private set; }
    public Rigidbody2D Body { get; private set; }
    public SpriteRenderer Sprite { get; private set; }

    [SerializeField]
    private GameObject secondaryPlayer;
    private PlayerController controller2;
    public PlayerController workingController { get; private set; }
    public PlayerData playerData;
    public bool primaryPlayer { get; private set; }
    public float moveForce { get; private set; }
    public float maxSpeed { get; private set; }
    public float jumpForce { get; private set; }
    public float jumpTime { get; private set; }
    private LayerMask isGround;
    private Vector2 groundOffset1;
    private Vector2 groundOffset2;


    public override void Awake()
    {
        base.Awake();
        primaryPlayer = playerData.primaryPlayer;
        if (secondaryPlayer)
        {
            controller2 = secondaryPlayer.GetComponent<PlayerController>();
        }
        if (primaryPlayer)
        {
            IdleState = new PlayerIdleState(this, stateMachine, "idle");
            MoveState = new PlayerMoveState(this, stateMachine, "move");
            JumpState = new PlayerJumpState(this, stateMachine, "jump");
            FallState = new PlayerFallState(this, stateMachine, "fall");
            if (secondaryPlayer)
            {
                controller2.StateSetup(IdleState, MoveState, JumpState, FallState);
            }
        }
        moveForce = playerData.moveForce;
        maxSpeed = playerData.maxSpeed;
        jumpForce = playerData.jumpForce;
        jumpTime = playerData.jumpTime;
        isGround = playerData.isGround;
        groundOffset1 = playerData.groundOffset1;
        groundOffset2 = playerData.groundOffset2;
    }
    // Start is called before the first frame update
    public override void Start()
    {
        Anima = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        if (primaryPlayer) stateMachine.Iniitialize(FallState);
    }

    public override void Update()
    {
        if (primaryPlayer)
        {
            base.Update();
            if (Input.GetButtonDown("Swap")) workingController = (workingController == this) ? this : controller2;
        }
    }

    public override void FixedUpdate()
    {
        if (primaryPlayer) base.FixedUpdate();
    }

    public void StateSetup(PlayerIdleState playerIdleState, PlayerMoveState playerMoveState, PlayerJumpState playerJumpState, PlayerFallState playerFallState)
    {
        Debug.Log("States Set");
        IdleState = playerIdleState;
        MoveState = playerMoveState;
        JumpState = playerJumpState;
        FallState = playerFallState;
    }
    public bool GroundCheck()
    {
        Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
        return Physics2D.OverlapArea(groundOffset1 + position2D, groundOffset2 + position2D, isGround);
    }

    public void SetVelocityX(float xVelocity) => Body.velocity = new Vector2(xVelocity, Body.velocity.y);
    public void SetVelocityY(float yVelocity) => Body.velocity = new Vector2(Body.velocity.x, yVelocity);
}
