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

    public float moveForce = 10f;
    public float maxSpeed = 25f;
    public float jumpForce = 5f;
    public LayerMask isGround;
    public Vector2 groundOffset1 = new Vector2(-0.5f, -2.45f);
    public Vector2 groundOffset2 = new Vector2(0.15f, -2.5f);


    public override void Awake()
    {
        base.Awake();

        IdleState = new PlayerIdleState(this, stateMachine, "idle");
        MoveState = new PlayerMoveState(this, stateMachine, "move");
        JumpState = new PlayerJumpState(this, stateMachine, "jump");
        FallState = new PlayerFallState(this, stateMachine, "fall");
    }
    // Start is called before the first frame update
    public override void Start()
    {
        Anima = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        stateMachine.Iniitialize(IdleState);
    }
    public bool GroundCheck(){
        Vector2 position2D = new Vector2 (transform.position.x, transform.position.y);
        return Physics2D.OverlapArea(groundOffset1 + position2D, groundOffset2 + position2D, isGround);
    }

    public void SetVelocityX(float xVelocity) => Body.velocity = new Vector2(xVelocity, Body.velocity.y);
    public void SetVelocityY(float yVelocity) => Body.velocity = new Vector2(Body.velocity.x, yVelocity);
}
