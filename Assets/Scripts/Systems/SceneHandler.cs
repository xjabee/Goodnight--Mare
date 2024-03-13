using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public LevelLoader levelLoader;    // Start is called before the first frame update
    void Start()
    {  
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        levelLoader.LoadNextLevel(1);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        //In the future load scene to a random number if the team decides that is the play.
        levelLoader.LoadNextLevel(2);
    }
    public void ResetLevel()
    {
        if(SceneManager.GetSceneByName("Essentials").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Essentials");
            SceneManager.LoadScene("Essentials", LoadSceneMode.Single);
        }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Additive);
        

    }

}
