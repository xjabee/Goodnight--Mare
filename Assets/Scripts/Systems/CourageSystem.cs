using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourageSystem : MonoBehaviour
{
    public int courageCount = 3;
    public int currentCourage;
    UIManager uIManager;

    private void Start() {
        uIManager = GameManager.instance.uIManager;
        currentCourage = courageCount;
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




}
