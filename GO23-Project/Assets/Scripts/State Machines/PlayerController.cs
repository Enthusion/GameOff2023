using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : Controller
{
    //STATES
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerWaitState WaitState { get; private set; }
    public PlayerFollowState FollowState { get; private set; }

    public Animator Anima { get; private set; }
    public Rigidbody2D Body { get; private set; }
    public CapsuleCollider2D Collider { get; private set; }
    public SpriteRenderer Sprite { get; private set; }

    [SerializeField]
    private GameObject secondaryPlayer;
    public PlayerController controller2 { get; private set; }
    public bool Active;
    public bool Following;
    public Vector2 initialColliderSize { get; private set; }
    public PlayerData playerData;
    public string characterName { get; private set; }
    public int characterId { get; private set; }
    public bool primaryPlayer { get; private set; }
    public float moveForce { get; private set; }
    public float maxSpeed { get; private set; }
    public float jumpForce { get; private set; }
    public float jumpTime { get; private set; }
    private LayerMask isGround;
    public float baseDamage { get; private set; }
    public float currentEnergy { get; private set; }
    [SerializeField]
    private GameObject groundPoint1;
    [SerializeField]
    private GameObject groundPoint2;


    public override void Awake()
    {
        base.Awake();

        IdleState = new PlayerIdleState(this, stateMachine, "idle");
        MoveState = new PlayerMoveState(this, stateMachine, "move");
        JumpState = new PlayerJumpState(this, stateMachine, "jump");
        FallState = new PlayerFallState(this, stateMachine, "fall");
        WaitState = new PlayerWaitState(this, stateMachine, "idle"); //TODO idle is placeholder animation
        FollowState = new PlayerFollowState(this, stateMachine, "follow");

        characterName = playerData.characterName;
        characterId = playerData.characterId;
        primaryPlayer = playerData.primaryPlayer;
        moveForce = playerData.moveForce;
        maxSpeed = playerData.maxSpeed;
        jumpForce = playerData.jumpForce;
        jumpTime = playerData.jumpTime;
        isGround = playerData.isGround;
        baseDamage = playerData.baseDamage;

        Active = primaryPlayer;
    }
    // Start is called before the first frame update
    public override void Start()
    {
        Anima = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();

        controller2 = secondaryPlayer.GetComponent<PlayerController>();

        initialColliderSize = Collider.size;
        currentEnergy = 0.0f; //TODO set based on GameManager in future;

        IdleState.Ready();
        MoveState.Ready();
        JumpState.Ready();
        FallState.Ready();
        WaitState.Ready();
        FollowState.Ready();

        if (primaryPlayer) stateMachine.Iniitialize(FallState);
        else stateMachine.Iniitialize(WaitState);
    }
    
    public void FlipCharacter(bool faceRight){
        if(faceRight){
            transform.Rotate(Vector3.zero);
        }
        else{
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
    public bool GroundCheck() => Physics2D.OverlapArea(groundPoint1.transform.position, groundPoint2.transform.position, isGround);
    public void SetVelocityX(float xVelocity) => Body.velocity = new Vector2(xVelocity, Body.velocity.y);
    public void SetVelocityY(float yVelocity) => Body.velocity = new Vector2(Body.velocity.x, yVelocity);
    public void SetGravityScale(float newGravity) => Body.gravityScale = newGravity;
    public void InterpolateTranslate(Vector2 location, float speed) => transform.position = Vector3.Lerp(transform.position, new Vector3(location.x, location.y, transform.position.z), speed * Time.deltaTime);
    public void ResizeCollider(Vector2 newSize) => Collider.size = newSize;
    public void AdjustScale(float scaleFactor) => transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
    public void SetScale(float scaleFactor){
        float minSize = 0.33333333333f;
        float maxSize = 1.25f;
        scaleFactor = Mathf.Clamp(scaleFactor, minSize, maxSize);
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
    public void AdjustEnergy(float energy)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + energy, 0, 100);
        float balance = GameManager.Instance.UpdateEnergy(currentEnergy, characterId);
        Debug.Log(characterName + "'s current energy: " + currentEnergy + "\nScale tilt: " + balance);
        SetScale(1 + balance);
        controller2.SetScale(1 - balance);
    }
}
