using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Switch
{
    public string SwitchID;
    public float EnergyRequisite = 0;
    public int CharacterSpecificID = -1;
    private float currentEnergy;
    public override void Start()
    {
        if(GameManager.Instance.CheckSwitches(SwitchID)) Activated();
        base.Start();
    }
}
