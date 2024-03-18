using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform playerTransform;
    public SceneHandler scheneHandler;
    public CourageSystem courageSystem;
    public UIManager uIManager;
    public PrefabManager prefabManager;
    public PlayerMovement playerMovement;
    public LevelLoader levelLoader;
    public VialHandler vialHandler;
    public HPController hPController;


}
