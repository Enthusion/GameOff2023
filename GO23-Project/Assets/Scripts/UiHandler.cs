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

    public void Update(){
        float vitaHealthFill = vHealthLog / maxHealth;
        float mortHealthFill = mHealthLog / maxHealth;
        float vitaEnergyFill = vEnergyLog / 100;
        float mortEnergyFill = mEnergyLog / 100;
        // Update health values
        if(vHealth.fillAmount != vHealthLog/maxHealth){
            float initialFillAmount = vHealth.fillAmount;
            if(vHealth.fillAmount > vHealthLog/maxHealth){
                vHealth.fillAmount -= Time.deltaTime;
                vHealth.fillAmount = Mathf.Clamp(vHealth.fillAmount, vHealthLog/maxHealth, initialFillAmount);
            }
            else
            {
                vHealth.fillAmount += Time.deltaTime;
                vHealth.fillAmount = Mathf.Clamp(vHealth.fillAmount, initialFillAmount, vHealthLog/maxHealth);
            }
        }
        if(mHealth.fillAmount != mHealthLog/maxHealth){
            float initialFillAmount = mHealth.fillAmount;
            if(mHealth.fillAmount > mHealthLog/maxHealth){
                mHealth.fillAmount -= Time.deltaTime;
                mHealth.fillAmount = Mathf.Clamp(mHealth.fillAmount, mHealthLog/maxHealth, initialFillAmount);
            }
            else
            {
                mHealth.fillAmount += Time.deltaTime;
                mHealth.fillAmount = Mathf.Clamp(mHealth.fillAmount, initialFillAmount, mHealthLog/maxHealth);
            }
        }
        // Update energy values
        if(vEnergy.fillAmount != vitaEnergyFill){
            float initialFillAmount = vEnergy.fillAmount;
            if(initialFillAmount > vitaEnergyFill){
                vEnergy.fillAmount -= Time.deltaTime;
                vEnergy.fillAmount = Mathf.Clamp(vEnergy.fillAmount, vitaEnergyFill, initialFillAmount);
            }
            else{
                vEnergy.fillAmount += Time.deltaTime;
                vEnergy.fillAmount = Mathf.Clamp(vEnergy.fillAmount, initialFillAmount, vitaEnergyFill);
            }
        }
        if(mEnergy.fillAmount != mortEnergyFill){
            float initialFillAmount = mEnergy.fillAmount;
            if(initialFillAmount > mortEnergyFill){
                mEnergy.fillAmount -= Time.deltaTime;
                mEnergy.fillAmount = Mathf.Clamp(mEnergy.fillAmount, mortEnergyFill, initialFillAmount);
            }
            else{
                mEnergy.fillAmount += Time.deltaTime;
                mEnergy.fillAmount = Mathf.Clamp(mEnergy.fillAmount, initialFillAmount, mortEnergyFill);
            }
        }
    }

    public void LogStats(){
        vHealthLog = GameManager.Instance.GetHealth(0);
        vEnergyLog = GameManager.Instance.GetEnergy(0);
        balanceLog = GameManager.Instance.GetBalance();
        mHealthLog = GameManager.Instance.GetHealth(1);
        mEnergyLog = GameManager.Instance.GetEnergy(1);
    }
}
