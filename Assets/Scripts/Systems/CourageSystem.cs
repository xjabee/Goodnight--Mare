using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourageSystem : MonoBehaviour
{
    public int courageCount = 3;
    public int hP = 5;
    public int currentHP; 
    public int currentCourage;
    UIManager uIManager;

    private void Start() {
        uIManager = GameManager.instance.uIManager;
        currentCourage = courageCount;
        currentHP = hP;
    }

    private void Update() {
        
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
