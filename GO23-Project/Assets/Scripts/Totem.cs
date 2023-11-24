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

    public virtual void Interact(PlayerController interactingPlayer){
        if(CharacterSpecificID != -1 && interactingPlayer.characterId != CharacterSpecificID){
            //Display message about character needed to activate?
            return;
        }

        if(EnergyRequisite != 0){
            float neededEnergy = currentEnergy - EnergyRequisite;
            float energyChange = interactingPlayer.currentEnergy - neededEnergy >= 0?neededEnergy:interactingPlayer.currentEnergy;
            currentEnergy +=  energyChange;
            interactingPlayer.AdjustEnergy(-energyChange);
            if(currentEnergy == EnergyRequisite){
                Activating();
                return;
            }
            //Display message about energy needed?
        }
    }
}
