using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    public Button startButton;
    public Button levelSelectButton;
    public Button escapeButton;
    

    void Start()
    {
        startButton = startButton.GetComponent<Button>();
        levelSelectButton = levelSelectButton.GetComponent<Button>();
        escapeButton = escapeButton.GetComponent<Button>();
    }

    public void StartLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(4);
    }
    
    public void LevelSelection()
    {

        SceneManager.LoadScene(1);
    }

    public void EscapeGame()
    {

        Application.Quit();
    }
}
