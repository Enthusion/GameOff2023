using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    // private TypeController typeController;
    // private TypeStateMachine tsm;
    // this.typeController = (TypeController)controller;
    // this.tsm = (TypeStateMachine)stateMachine;
    protected Controller controller;
    protected StateMachine stateMachine;
    protected float runtime;
    protected float physicsRuntime;

    public State(Controller controller, StateMachine stateMachine)
    {
        this.controller = controller;
        this.stateMachine = stateMachine;
    }
    public virtual void Ready() { }
    public virtual void Enter()
    {
        runtime = 0.0f;
        physicsRuntime = 0.0f;
    }
    public virtual void FrameUpdate()
    {
        runtime += Time.deltaTime;
    }
    public virtual void PhysicsUpdate() {
        physicsRuntime += Time.fixedDeltaTime;
    }
    public virtual void Exit() { }
}
