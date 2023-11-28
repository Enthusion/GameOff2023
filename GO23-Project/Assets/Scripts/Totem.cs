using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Switch, IInteractable
{
    public string SwitchID;
    public int switchWeight = 1;
    public float EnergyRequisite = 0;
    public int CharacterSpecificID = -1;
    private float currentEnergy;
    public override void Start()
    {
        if (GameManager.Instance.CheckSwitches(SwitchID)) Activated();
        base.Start();
    }

    public virtual void Interact(PlayerController interactingPlayer)
    {
        if (!Active)
        {
            if (CharacterSpecificID != -1 && interactingPlayer.characterId != CharacterSpecificID)
            {
                //Display message about character needed to activate?
                return;
            }

            if (EnergyRequisite != 0)
            {
                float neededEnergy = currentEnergy - EnergyRequisite;
                float energyChange = interactingPlayer.currentEnergy - neededEnergy >= 0 ? neededEnergy : interactingPlayer.currentEnergy;
                currentEnergy += energyChange;
                interactingPlayer.AdjustEnergy(-energyChange);
                if (currentEnergy == EnergyRequisite)
                {
                    Activating();
                    return;
                }
                //Display message about energy needed?
                return;
            }
            Activating();
        }
    }

    public override void Activating()
    {
        base.Activating();
        Reciever.ReciveActivator(switchWeight);
    }

    public override void Activated()
    {
        base.Activated();
    }
}
