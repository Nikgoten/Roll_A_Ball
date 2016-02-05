using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    public Button startButton;
    public Button levelSelectButton;

    // Use this for initialization
    void Start()
    {
        startButton = startButton.GetComponent<Button>();
        levelSelectButton = levelSelectButton.GetComponent<Button>();

    }

    public void StartLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(4);
    }
    // Update is called once per frame
    public void LevelSelection()
    {

        SceneManager.LoadScene(1);
    }
}
