using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {

    public Button startButton;
    public Button exitButton;
    public AudioClip continueGame;
    public static int lastScene;

    public static AudioSource gameOverSound;

    void Start()
    {

        startButton = startButton.GetComponent<Button>();

        exitButton = exitButton.GetComponent<Button>();

        gameOverSound = GetComponent<AudioSource>();

        gameOverSound.PlayOneShot(continueGame);

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
