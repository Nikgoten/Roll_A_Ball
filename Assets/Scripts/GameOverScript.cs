using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {

    public Button startButton;
    public Button exitButton;
    public static int lastScene;

    void Start()
    {

        startButton = startButton.GetComponent<Button>();

        exitButton = exitButton.GetComponent<Button>();

    }

    public void StartLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(lastScene);
    }

    public void ExitLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(0);
    }


}
