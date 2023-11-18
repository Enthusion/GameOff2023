using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public virtual void Awake()
    {
        stateMachine = new StateMachine();
    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        //Initialize statemachine
    }

    // Update is called once per frame
    public virtual void Update()
    {
        stateMachine.currentState.FrameUpdate();
    }

    public virtual void FixedUpdate() {
        stateMachine.currentState.PhysicsUpdate();
    }
}
