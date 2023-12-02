using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCollectible : CollectibleEntity
{
    [SerializeField]
    private int characterSpecific = -1;
    [SerializeField]
    private bool characterExclusive = false;
    [SerializeField]
    private float energyValue;
    [SerializeField]
    private bool respawning;
    [SerializeField]
    private float respawnTime = 0;
    private float respawnTimer = 0;
    private Animator anima;

    public void Start(){
        anima = GetComponent<Animator>();
    }
    public void Update(){
        if(respawning && respawnTimer <= respawnTime){
            if(respawnTimer > 0) respawnTimer -= Time.deltaTime;
            else Respawn();
        }
    }
    public override void playerContact(PlayerController player)
    {
        base.playerContact(player);
        if(!player.Active) return;
        if(!characterExclusive || characterSpecific == player.characterId) Collected(player);
    }
    public override void Collected(PlayerController collector)
    {
        base.Collected(collector);
        int id = collector.characterId;
        if(characterSpecific != -1 && id != characterSpecific) return;
        collector.AdjustEnergy(energyValue);
        if(respawning) respawnTimer = respawnTime;
        anima.SetBool("Collected", true);
    }
    public void Respawn(){
        anima.SetBool("Collected", false);
        respawnTimer = respawnTime + 1;
    }
}
