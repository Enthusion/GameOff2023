using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPont : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col){
        if(TryGetComponent<PlayerController>(out PlayerController player)){
            GameManager.Instance.SetRespawnPoint(player.characterId, transform.position);
        }
    }
}
