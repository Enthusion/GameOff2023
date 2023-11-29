using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IInteractable
{
    void Interact(PlayerController interactingPlayer);
}
