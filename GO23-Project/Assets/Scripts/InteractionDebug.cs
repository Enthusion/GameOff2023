using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDebug : MonoBehaviour, IInteractable
{
   public void Interact(PlayerController interactingPlayer){
    Debug.Log("Interacting");
   }
}
