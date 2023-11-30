using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleEntity : MonoBehaviour
{
    public virtual void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.TryGetComponent(out PlayerController player)){
            playerContact(player);
        }
    }

    public virtual void playerContact(PlayerController player){ }
    public virtual void Collected(){ }
}
