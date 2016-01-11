using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HighScoreExit : MonoBehaviour {

  


    public void NextStage()
    {

        SceneManager.LoadScene(0);
    }

    public void ExitLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(0);
    }
}
