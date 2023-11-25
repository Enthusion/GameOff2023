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

    public void Start()
    {
        vHealth = VitaHealthMask.GetComponent<Image>();
        mHealth = MortHealthMask.GetComponent<Image>();
        scaleTilt = BalanceScale.GetComponent<RectTransform>();
        vEnergy = VitaEnergyMeter.GetComponent<Image>();
        mEnergy = MortEnergyMeter.GetComponent<Image>();
    }

    public void Update()
    {
        float vHealthFill = vHealthLog / maxHealth;
        float mHealthFill = mHealthLog / maxHealth;
        float vEnergyFill = vEnergyLog / 100;
        float mEnergyFill = mEnergyLog / 100;
        // Update health values
        if (vHealth.fillAmount != vHealthFill)
        {
            float initialFillAmount = vHealth.fillAmount;
            if (vHealth.fillAmount > vHealthFill)
            {
                vHealth.fillAmount -= Time.deltaTime;
                vHealth.fillAmount = Mathf.Clamp(vHealth.fillAmount, vHealthFill, initialFillAmount);
            }
            else
            {
                vHealth.fillAmount += Time.deltaTime;
                vHealth.fillAmount = Mathf.Clamp(vHealth.fillAmount, initialFillAmount, vHealthFill);
            }
        }
        if (mHealth.fillAmount != mHealthFill)
        {
            float initialFillAmount = mHealth.fillAmount;
            if (mHealth.fillAmount > mHealthFill)
            {
                mHealth.fillAmount -= Time.deltaTime;
                mHealth.fillAmount = Mathf.Clamp(mHealth.fillAmount, mHealthFill, initialFillAmount);
            }
            else
            {
                mHealth.fillAmount += Time.deltaTime;
                mHealth.fillAmount = Mathf.Clamp(mHealth.fillAmount, initialFillAmount, mHealthFill);
            }
        }
        // Update energy values
        if (vEnergy.fillAmount != vEnergyFill)
        {
            float initialFillAmount = vEnergy.fillAmount;
            if (initialFillAmount > vEnergyFill)
            {
                vEnergy.fillAmount -= Time.deltaTime;
                vEnergy.fillAmount = Mathf.Clamp(vEnergy.fillAmount, vEnergyFill, initialFillAmount);
            }
            else
            {
                vEnergy.fillAmount += Time.deltaTime;
                vEnergy.fillAmount = Mathf.Clamp(vEnergy.fillAmount, initialFillAmount, vEnergyFill);
            }
        }
        if (mEnergy.fillAmount != mEnergyFill)
        {
            float initialFillAmount = mEnergy.fillAmount;
            if (initialFillAmount > mEnergyFill)
            {
                mEnergy.fillAmount -= Time.deltaTime;
                mEnergy.fillAmount = Mathf.Clamp(mEnergy.fillAmount, mEnergyFill, initialFillAmount);
            }
            else
            {
                mEnergy.fillAmount += Time.deltaTime;
                mEnergy.fillAmount = Mathf.Clamp(mEnergy.fillAmount, initialFillAmount, mEnergyFill);
            }
        }
    }

    public void LogStats()
    {
        vHealthLog = GameManager.Instance.GetHealth(0);
        vEnergyLog = GameManager.Instance.GetEnergy(0);
        balanceLog = GameManager.Instance.GetBalance();
        mHealthLog = GameManager.Instance.GetHealth(1);
        mEnergyLog = GameManager.Instance.GetEnergy(1);
    }
}
