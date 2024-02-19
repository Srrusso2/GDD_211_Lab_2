using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{
    public float Speed;
    public GameObject mover;
    public float dist;
    public GameObject goal;
    public Vector3 StartPosition;
    public float Value;
    public float Profit;
    public TMP_Text ProfitText;
    public Button ValueUpgrade;
    public Button SpeedUpgrade;
    public float VUcost;
    public float SUcost;
    public TMP_Text VUText;
    public TMP_Text SUText;
    public TMP_Text ValueText;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = new Vector3(-101.9f, -3.342859f, 89.93718f);
        Value = 10f;
        Profit = 0f;
        VUcost = 100f;
        SUcost = 75f;
    }

    // Update is called once per frame
    void Update()
    {
        mover.transform.Translate(-Speed, 0f, 0f);
        dist = Vector3.Distance(mover.transform.position, goal.transform.position);
        
        if (dist < 5)
        {
            mover.transform.position = StartPosition;
            Profit += Value;
        }

        ProfitText.text = "Current Money: " + Profit;
        VUText.text = "Upgrade Value: " + VUcost;
        SUText.text = "Upgrade Speed: " + SUcost;
        ValueText.text = "Current Value: " + Value;



        if (Profit > VUcost)
        {
            ValueUpgrade.interactable = true;
        } 
        else
        {
            ValueUpgrade.interactable = false;
        }

        if (Profit > SUcost)
        {
            SpeedUpgrade.interactable = true;
        }
        else
        {
            SpeedUpgrade.interactable = false;
        }
    }

    public void UpgradeSpeed()
    {
        Speed = Speed + .25f;
        Profit = Profit - SUcost;
        SUcost += SUcost / 2;
    }

    public void UpgradeValue()
    {
        Value = Value + 5f;
        Profit = Profit - VUcost;
        VUcost += VUcost / 2;
    }
}
