using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private CinemachineConfiner2D cm2d;
    private GameObject confiner;
    // Start is called before the first frame update
    void Start()
    {
        cm2d = GetComponent<CinemachineConfiner2D>();
        cm2d.m_BoundingShape2D = GameObject.FindGameObjectWithTag("World Confiner").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
