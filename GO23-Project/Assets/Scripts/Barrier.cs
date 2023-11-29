using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject AllowedCharacter;
    private PlayerController allowedPlayer;
    private BoxCollider2D barrierCollider;


    public void Start(){
        barrierCollider = GetComponent<BoxCollider2D>();
        allowedPlayer = AllowedCharacter.GetComponent<PlayerController>();
        CapsuleCollider2D playerCollider = AllowedCharacter.GetComponent<CapsuleCollider2D>();
        Physics2D.IgnoreCollision(barrierCollider, playerCollider, true);
    }
    public void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.TryGetComponent(out PlayerController player)){
            if(player.characterId != allowedPlayer.characterId){
                if(player.Following){
                    player.ForceToWaiting();
                }
            }
        }
    }
}
