using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
    public GameObject VitaHealthMask;
    public GameObject MortHealthMask;
    public GameObject BalanceScale;
    public GameObject VitaEnergyMeter;
    public GameObject MortEnergyMeter;
    private Image vHealth;
    private Image mHealth;
    private RectTransform scaleTilt;
    private Image vEnergy;
    private Image mEnergy;
    private float vHealthLog;
    private float mHealthLog;
    private float vEnergyLog;
    private float mEnergyLog;
    private float balanceLog;
    private float maxTilt = 15;
    private float maxHealth = 15;

    public void Start(){
        vHealth = VitaHealthMask.GetComponent<Image>();
        mHealth = MortHealthMask.GetComponent<Image>();
        scaleTilt = BalanceScale.GetComponent<RectTransform>();
        vEnergy = VitaEnergyMeter.GetComponent<Image>();
        mEnergy = MortEnergyMeter.GetComponent<Image>();
    }
}
