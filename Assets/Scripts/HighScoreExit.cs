using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HighScoreExit : MonoBehaviour {
    
    // Update is called once per frame
    public void StartLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(0);
    }
}
