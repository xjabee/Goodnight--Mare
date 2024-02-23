using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        //In the future load scene to a random number if the team decides that is the play.
        SceneManager.LoadScene("Stage 2");
    }

}
