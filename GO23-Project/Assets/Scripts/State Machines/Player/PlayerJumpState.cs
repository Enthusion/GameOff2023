using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private float initialSpeed;
    private float speedCap;
    private bool releasedJump;
    private float sinceReleased;
    private float balance;
    public PlayerJumpState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        //Set a horizontal speed capacity based on either the speed when entering the sate or 5, whatever is greater
        initialSpeed = Mathf.Abs(playerController.Body.velocity.x);
        speedCap = (initialSpeed >= 7.0f) ? initialSpeed : 7.0f;
        releasedJump = false;
        balance = GameManager.Instance.GetBalance();
        balance = playerController.characterId == 0 ? balance : -balance;
        Debug.Log("Blance: " + balance);
        //Jump time is set to 0.16 so a gravity scale of 0.84 is over jumptime
        if (1 - playerController.Body.gravityScale <= playerController.jumpTime)
        {
            runtime = 1 - playerController.Body.gravityScale;
        }
        //Add initial jump force
        if (runtime == 0) playerController.SetVelocityY(playerController.jumpForce * (1.35f + (balance < 0 ? balance * 0.2f : balance * 1.15f) * 0.175f));
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        //Air control
        float movementInput = Input.GetAxis("Horizontal");
        playerController.Body.AddForce(Vector2.right * movementInput * (playerController.moveForce / 1.75f));
        if (movementInput > 0) playerController.Sprite.flipX = false;
        else if (movementInput < 0) playerController.Sprite.flipX = true;

        // if(Input.GetButtonDown("Fire1")){
        //     stateMachine.ChangeState(playerController.ShootState);
        // }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        bool jumpRelease = true;
        if (Input.GetButton("Jump"))
        {
            jumpRelease = false;
        }
        //Variable jump height
        if (!releasedJump && jumpRelease)
        {
            sinceReleased = 0;
            releasedJump = true;
            playerController.Body.AddForce(Vector2.down * playerController.jumpForce * 5.5f);
            playerController.SetGravityScale(1.0f);
        }
        if (!releasedJump)
        {
            if(playerController.Body.velocity.y < 1.25f) playerController.Body.AddForce(Vector2.up * (playerController.jumpForce + (1.1f * balance)) * physicsRuntime);
            if (physicsRuntime < playerController.jumpTime)
            {
                playerController.SetGravityScale(1 - physicsRuntime);
            }
            //Slightly decrease gravity near peak of jump
            else if (playerController.Body.velocity.y < 0.75f)
            {
                playerController.SetGravityScale(0.95f + physicsRuntime - playerController.jumpTime);
                // playerController.Body.AddForce(Vector2.up * playerController.jumpForce * 0.25f);
            }
        }
        else
        {
            sinceReleased += Time.fixedDeltaTime;
            playerController.SetGravityScale(1 + sinceReleased);
        }

        //Exiting jump state when no longer moving up
        if (playerController.Body.velocity.y <= 0.0f)
        {
            playerController.SetGravityScale(1.1f);
            abilityTriggered = true;
        }

        //Ensure horizontal velocity is within speed capacity
        playerController.SetVelocityX(Mathf.Clamp(playerController.Body.velocity.x, -speedCap, speedCap));
    }
}
