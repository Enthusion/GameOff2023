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
    public PlayerWaitState WaitState { get; private set; }

    public Animator Anima { get; private set; }
    public Rigidbody2D Body { get; private set; }
    public SpriteRenderer Sprite { get; private set; }

    [SerializeField]
    private GameObject secondaryPlayer;
    public PlayerController controller2 { get; private set; }
    public bool Active;
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

        IdleState = new PlayerIdleState(this, stateMachine, "idle");
        MoveState = new PlayerMoveState(this, stateMachine, "move");
        JumpState = new PlayerJumpState(this, stateMachine, "jump");
        FallState = new PlayerFallState(this, stateMachine, "fall");
        WaitState = new PlayerWaitState(this, stateMachine, "idle"); //TODO idle is placeholder animation

        primaryPlayer = playerData.primaryPlayer;
        moveForce = playerData.moveForce;
        maxSpeed = playerData.maxSpeed;
        jumpForce = playerData.jumpForce;
        jumpTime = playerData.jumpTime;
        isGround = playerData.isGround;
        groundOffset1 = playerData.groundOffset1;
        groundOffset2 = playerData.groundOffset2;

        Active = primaryPlayer;
    }
    // Start is called before the first frame update
    public override void Start()
    {
        Anima = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();

        controller2 = secondaryPlayer.GetComponent<PlayerController>();

        if (primaryPlayer) stateMachine.Iniitialize(FallState);
        else stateMachine.Iniitialize(WaitState);

        IdleState.Ready();
        MoveState.Ready();
        JumpState.Ready();
        FallState.Ready();
        WaitState.Ready();
    }

    public bool GroundCheck()
    {
        Vector2 position2D = new Vector2(transform.position.x, transform.position.y);
        return Physics2D.OverlapArea(groundOffset1 + position2D, groundOffset2 + position2D, isGround);
    }

    public void SetVelocityX(float xVelocity) => Body.velocity = new Vector2(xVelocity, Body.velocity.y);
    public void SetVelocityY(float yVelocity) => Body.velocity = new Vector2(Body.velocity.x, yVelocity);
}
