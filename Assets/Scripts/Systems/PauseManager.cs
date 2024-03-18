using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    [SerializeField] GameObject panel;
    public static bool isGamePaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            isGamePaused = true;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        isGamePaused = false;
    }

}
