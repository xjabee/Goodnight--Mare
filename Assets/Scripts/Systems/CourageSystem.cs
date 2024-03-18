using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourageSystem : MonoBehaviour
{
    public int courageCount = 0;
    public int hP = 5;
    public int currentHP; 
    public int currentCourage;
    UIManager uIManager;
    VialHandler vialHandler;
    HPController hPController;

    private void Start() {
        uIManager = GameManager.instance.uIManager;
        hPController = GameManager.instance.hPController;
        vialHandler = GameManager.instance.vialHandler;
        currentCourage = courageCount;
        currentHP = hP;
    }

    private void Update() 
    {
        hPController.animator.SetInteger("hpCount", currentHP);
        vialHandler.animator.SetInteger("vialMeter", currentCourage);
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentCourage >= 1 && currentHP <= 4)
            {
                RemoveCourage(1);
                AddHP(1);
            }
            
        }
    }

    public void AddCourage(int courageAdded)
    {
        currentCourage += courageAdded;
    }

    public void RemoveCourage(int courageRemoved)
    {
        currentCourage -= courageRemoved;
    }


    public void AddHP(int hpAdded)
    {
        if(currentHP >= hP)
            return;
        else
            currentHP += hpAdded;
    }

    public void RemoveHP(int hpRemoved)
    {
        currentHP -= hpRemoved;
    }



}
