using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchReciever : MonoBehaviour
{
    protected int neededActivations;
    protected int currentActivations;
    protected bool activatedAtStart;
    protected bool initialized;

    public virtual void Awake()
    {
        neededActivations = 0;
        currentActivations = 0;
        initialized = false;
    }
    public virtual void StartUp(bool isActive)
    {
        neededActivations++;
        if (isActive) currentActivations++;
        activatedAtStart = neededActivations == currentActivations;
    }
    public virtual void Start() { }
    public virtual void Update()
    {
        if (!initialized && activatedAtStart) Activated();
    }
    public virtual void FixedUpdate() { }
    public virtual void ReciveActivator(int switchWeight = 1)
    {
        currentActivations += switchWeight;
        if (currentActivations >= neededActivations) Activating();
    }
    public virtual void Activating() { }
    public virtual void Activated() { }
}
