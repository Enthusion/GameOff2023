using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private float vitaEnergy;
    private float mortEnergy;
    private string switchString;
    private Vector2 respawnPoint;
    private Dictionary<string, Vector2> checkpoints;
    private string currentCheckpoint;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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
        return characterBalance * GetBalance();
    }
    public float GetBalance()
    {
        float greaterEnergy = vitaEnergy > mortEnergy ? vitaEnergy : mortEnergy;
        if (greaterEnergy == 0) return 0;
        return (vitaEnergy - mortEnergy) / greaterEnergy;
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
    }
    public void SetCheckpoint(string ID)
    {
        if (!checkpoints.ContainsKey(ID)) return;
        currentCheckpoint = ID;
    }
    public Vector2 GetCheckpoint() => checkpoints[currentCheckpoint];
    public void SetRespawnPoint(Vector2 position) => respawnPoint = position;
    public Vector2 GetRespawnPoint() => (respawnPoint != null || respawnPoint != Vector2.zero) ? respawnPoint : checkpoints[currentCheckpoint];
}
