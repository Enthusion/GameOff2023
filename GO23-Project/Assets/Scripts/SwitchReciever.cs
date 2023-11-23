using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchReciever : MonoBehaviour
{
    protected int neededActivations;
    protected int currentActivations;
    protected bool activatedAtStart;

    public virtual void Awake(){
        neededActivations = 0;
        currentActivations = 0;
    }
    public virtual void StartUp(bool isActive){
        neededActivations++;
        if(isActive) currentActivations++;
        activatedAtStart = neededActivations == currentActivations;
    }
}
