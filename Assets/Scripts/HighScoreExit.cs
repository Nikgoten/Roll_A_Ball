using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HighScoreExit : MonoBehaviour {

    public static string continueStage;


    public void Start()
    {
     SceneManager.SetActiveScene(SceneManager.GetSceneByName(ScoreMaster.previousSceneName));
    }

    public void NextStage()
    {



        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        TimeCounter.time = 0f;
    }

    public void ExitLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(0);
    }
}
