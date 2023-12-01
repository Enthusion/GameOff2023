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
    public PlayerShootState ShootState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerWaitState WaitState { get; private set; }
    public PlayerFollowState FollowState { get; private set; }
    public PlayerHurtState HurtState { get; private set; }

    public Animator Anima { get; private set; }
    public Rigidbody2D Body { get; private set; }
    public CapsuleCollider2D Collider { get; private set; }
    // public BoxCollider2D TriggerCollider { get; private set; }
    public SpriteRenderer Sprite { get; private set; }

    [SerializeField]
    private GameObject secondaryPlayer;
    public PlayerController controller2 { get; private set; }
    public bool Active;
    public bool Following;
    public bool DefaultToWait = false;
    public Vector2 initialColliderSize { get; private set; }
    public float sinceLastGrounded { get; private set; }
    public PlayerData playerData;
    public string characterName { get; private set; }
    public int characterId { get; private set; }
    public bool primaryPlayer { get; private set; }
    public float moveForce { get; private set; }
    public float maxSpeed { get; private set; }
    public float jumpForce { get; private set; }
    public float jumpTime { get; private set; }
    private LayerMask isGround;
    private LayerMask isInteractable;
    public float baseDamage { get; private set; }
    public GameObject mainProjectile { get; private set; }
    public float currentEnergy { get; private set; }
    [SerializeField]
    private GameObject groundPoint1;
    [SerializeField]
    private GameObject groundPoint2;
    private ContactFilter2D interactionFilter = new ContactFilter2D();
    private float targetScale = 1;


    public override void Awake()
    {
        base.Awake();

        IdleState = new PlayerIdleState(this, stateMachine, "idle");
        MoveState = new PlayerMoveState(this, stateMachine, "move");
        JumpState = new PlayerJumpState(this, stateMachine, "jump");
        ShootState = new PlayerShootState(this, stateMachine, "fall");// TODO: Replace placeholder animation
        FallState = new PlayerFallState(this, stateMachine, "fall");
        WaitState = new PlayerWaitState(this, stateMachine, "idle"); //TODO idle is placeholder animation
        FollowState = new PlayerFollowState(this, stateMachine, "follow");
        HurtState = new PlayerHurtState(this, stateMachine, "fall"); //TODO: Replace placeholder animation

        characterName = playerData.characterName;
        characterId = playerData.characterId;
        primaryPlayer = playerData.primaryPlayer;
        moveForce = playerData.moveForce;
        maxSpeed = playerData.maxSpeed;
        jumpForce = playerData.jumpForce;
        jumpTime = playerData.jumpTime;
        isGround = playerData.isGround;
        isInteractable = playerData.isInteractable;
        baseDamage = playerData.baseDamage;
        mainProjectile = playerData.mainProjectile;

        Active = primaryPlayer;
        
        interactionFilter.SetLayerMask(isInteractable);
        interactionFilter.useTriggers = true;
    }
    // Start is called before the first frame update
    public override void Start()
    {
        Anima = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
        // TriggerCollider = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();

        controller2 = secondaryPlayer.GetComponent<PlayerController>();
        GameManager.Instance?.SetPlayer(this);
        GameManager.Instance?.SetPlayer(controller2);

        initialColliderSize = Collider.size;
        currentEnergy = GameManager.Instance.GetEnergy(characterId);

        IdleState.Ready();
        MoveState.Ready();
        JumpState.Ready();
        FallState.Ready();
        WaitState.Ready();
        FollowState.Ready();

        if (GameManager.Instance.GetActiveCharacter() == characterId) stateMachine.Iniitialize(FallState);
        else if(DefaultToWait) stateMachine.Iniitialize(WaitState);
        else stateMachine.Iniitialize(FollowState);
    }
    public override void Update()
    {
        base.Update();
        float initialScale = transform.localScale.x;
        if(initialScale != targetScale){
            float newScale = initialScale;
            if(initialScale < targetScale){
                newScale += Time.deltaTime;
                newScale = Mathf.Clamp(newScale, initialScale, targetScale);
            }
            else{
                newScale -= Time.deltaTime;
                newScale = Mathf.Clamp(newScale, targetScale, initialScale);
            }
            transform.localScale = new Vector3(newScale, newScale, newScale);

        }
        if(sinceLastGrounded < 5.0f){
            sinceLastGrounded += Time.deltaTime;
        }
    }
    public bool GroundCheck(){
        bool onGround = Physics2D.OverlapArea(groundPoint1.transform.position, groundPoint2.transform.position, isGround);
        if(onGround) sinceLastGrounded = 0.0f;
        return onGround;
    }
    public void SetVelocityX(float xVelocity) => Body.velocity = new Vector2(xVelocity, Body.velocity.y);
    public void SetVelocityY(float yVelocity) => Body.velocity = new Vector2(Body.velocity.x, yVelocity);
    public void SetGravityScale(float newGravity) => Body.gravityScale = newGravity;
    public void InterpolateTranslate(Vector2 location, float speed) => transform.position = Vector3.Lerp(transform.position, new Vector3(location.x, location.y, transform.position.z), speed * Time.deltaTime);
    public void ResizeCollider(Vector2 newSize) => Collider.size = newSize;
    public void AdjustScale(float scaleFactor) => transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
    public void SetScale(float scaleFactor)
    {
        float minSize = 0.5f;
        float maxSize = 1.2f;
        targetScale = Mathf.Clamp(scaleFactor, minSize, maxSize);
    }
    public void AdjustEnergy(float energy)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + energy, 0, 100);
        float balance = GameManager.Instance.UpdateEnergy(currentEnergy, characterId);
        // Debug.Log(characterName + "'s current energy: " + currentEnergy + "\nScale tilt: " + balance);
        SetScale(1 + balance);
        controller2.SetScale(1 - balance);
    }
    public void ApplyKnockback(Vector2 knockbackForce)
    {
        stateMachine.ChangeState(HurtState);
        Body.velocity = knockbackForce;
    }
    public void ForceToWaiting()
    {
        stateMachine.ChangeState(WaitState);
    }
    public void ForceToFollow()
    {
        stateMachine.ChangeState(FollowState);
    }
    public void ForceToActive(){
        stateMachine.ChangeState(FallState);
    }
    public void UpdateActiveStatus(){
        GameManager.Instance.UpdateActiveCharacter();
    }
    public void Interaction(){
        Collider2D[] possibleInteractions = new Collider2D[3];
        Physics2D.OverlapCollider(Collider, interactionFilter,possibleInteractions);
        for (int i = 0; i < possibleInteractions.Length; i++)
        {
            if(possibleInteractions[i] == null) break;
            if(possibleInteractions[i].TryGetComponent(out IInteractable interactableObject)){
                interactableObject.Interact(this);
                break;
            }
        }
    }
    public GameObject CreateObject(GameObject prefab, Vector3 location) => Instantiate(prefab, location, transform.rotation);
}
