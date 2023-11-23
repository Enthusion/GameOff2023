using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject AllowedCharacter;
    private BoxCollider2D barrierCollider;

    public void Start(){
        barrierCollider = GetComponent<BoxCollider2D>();
        CapsuleCollider2D playerCollider = AllowedCharacter.GetComponent<CapsuleCollider2D>();
        Physics2D.IgnoreCollision(barrierCollider, playerCollider, true);
    }
}
