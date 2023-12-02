using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceChecker : MonoBehaviour
{
    public float MinimumScale;
    public float CrushDistance;
    private Vector2 center;
    public void Start(){
        center = transform.position;
    }
    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.TryGetComponent<PlayerController>(out PlayerController character)){
            if (character.transform.localScale.x > MinimumScale){
                if(character.Following){
                    character.ForceToWaiting();
                }
            }
        }
    }

    public void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.TryGetComponent<PlayerEntity>(out PlayerEntity character)){
            if (character.transform.localScale.x > MinimumScale && Vector2.Distance(character.transform.position, transform.position) <= CrushDistance){
                character.TakeDamage(5, gameObject);
                character.Respawn();
            }
        }
    }
}
