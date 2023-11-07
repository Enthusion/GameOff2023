using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    //STATES
    // public PlayerIdleState IdleState { get; private set; }
    // public PlayerMoveState MoveState { get; private set; }

    public Animator Anima { get; private set; }
    public Rigidbody2D Body { get; private set; }

    public override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    public override void Start()
    {
        Anima = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
        //Initialize state machine
    }
}
