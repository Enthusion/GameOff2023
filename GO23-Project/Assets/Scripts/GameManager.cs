using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private UiHandler uiHandler;
    private PlayerController vita;
    private PlayerController mort;
    private int activeID;
    private float vitaEnergy;
    private float mortEnergy;
    private string switchString = "";
    private Vector2 respawnPoint;
    private Dictionary<string, Vector2> checkpoints;
    private string currentCheckpoint;
    private float vitaHealth;
    private float mortHealth;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void SetUI(UiHandler UiObject)
    {
        uiHandler = UiObject;
    }

    public void SetPlayers(PlayerController player1, PlayerController player2)
    {
        if (player1.characterId == 0)
        {
            vita = player1;
            mort = player2;
        }
        else
        {
            mort = player1;
            vita = player2;
        }
        if(activeID == 0){
            // IF SCENE IS NOT ZERO
            mort.ForceToFollow();
            mort.Following = true;
            vita.ForceToActive();
            vita.Active = true;
        }
        else if(activeID == 1){
            vita.ForceToFollow();
            vita.Following = true;
            mort.ForceToActive();
            mort.Active = true;
        }
    }

    public void UpdateActiveCharacter(){
        if(vita.Active){
            activeID = 0;
        }
        else if(mort.Active){
            activeID = 1;
        }
        else{
            Debug.Log("No active characters");
            return;
        }
    }

    public int GetActiveCharacter(){
        return activeID;
    }

    public float UpdateEnergy(float newValue, int playerId)
    {
        float characterBalance = 0;
        if (playerId == 0)
        {
            vitaEnergy = newValue;
            characterBalance = 1;
        }
        else if (playerId == 1)
        {
            mortEnergy = newValue;
            characterBalance = -1;
        }
        uiHandler?.LogStats();
        return characterBalance * GetBalance();
    }
    public float GetEnergy(int characterId)
    {
        if (characterId == 0) return vitaEnergy;
        else if (characterId == 1) return mortEnergy;
        else return -1;
    }
    public float GetBalance()
    {
        float greaterEnergy = vitaEnergy > mortEnergy ? vitaEnergy : mortEnergy;
        if (greaterEnergy == 0) return 0;
        return (vitaEnergy - mortEnergy) / greaterEnergy;
    }
    public void UpdateHealth(float newValue, int playerId)
    {
        if (newValue > 15) newValue = 15;
        if (playerId == 0)
        {
            vitaHealth = newValue;
        }
        else if (playerId == 1)
        {
            mortHealth = newValue;
        }
        uiHandler?.LogStats();
    }
    public float GetHealth(int characterId)
    {
        if (characterId == 0) return vitaHealth;
        else if (characterId == 1) return mortHealth;
        else return -1;
    }
    public void UpdateSwitches(string ID, bool status)
    {
        if (status)
        {
            if (switchString.Contains(ID)) return;
            switchString += ID;
        }
        else
        {
            if (!switchString.Contains(ID)) return;
            switchString = switchString.Replace(ID, "");
        }
    }
    public bool CheckSwitches(string ID) => switchString.Contains(ID);
    public void RegisterCheckpoint(string ID, Vector2 position)
    {
        if (checkpoints.ContainsKey(ID)) return;
        checkpoints.Add(ID, position);
        Debug.Log("Checkpoint " + ID + " rigistered");
    }
    public void SetCheckpoint(string ID)
    {
        if (!checkpoints.ContainsKey(ID))
        {
            Debug.Log("Checkpoint " + ID + " not found!");
            return;
        }
        currentCheckpoint = ID;
    }
    public Vector2 GetCheckpoint() => checkpoints[currentCheckpoint];
    public void SetRespawnPoint(Vector2 position) => respawnPoint = position;
    public Vector2 GetRespawnPoint() => (respawnPoint != null || respawnPoint != Vector2.zero) ? respawnPoint : checkpoints[currentCheckpoint];
}
