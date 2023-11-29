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
    private int activatedID = -1;
    private Animator Anima;
    public override void Start()
    {
        Anima = GetComponent<Animator>();
        if (GameManager.Instance.CheckSwitches(SwitchID)) Activated();
        base.Start();
        if(CharacterSpecificID == 1){
            activatedID = -2;
        }
        Anima.SetInteger("CharacterID", activatedID);
        Anima.SetBool("Active", Active);
    }

    public virtual void Interact(PlayerController interactingPlayer)
    {
        if (!Active)
        {
            activatedID = interactingPlayer.characterId;
            if (CharacterSpecificID != -1 && activatedID != CharacterSpecificID)
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
        Anima.SetInteger("CharacterID", activatedID);
        Reciever.ReciveActivator(switchWeight);
        Activated();
    }

    public override void Activated()
    {
        base.Activated();
        Anima.SetBool("Active", Active);
    }
}
