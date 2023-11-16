using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private float vitaEnergy;
    private float mortEnergy;

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
}
