using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BackToMainMenu : MonoBehaviour {

    public Button continueButton;
    public AudioClip congratulations;
    public AudioClip cheering;

    public static AudioSource endSound;

    void Start () {

        continueButton = continueButton.GetComponent<Button>();
        endSound = GetComponent<AudioSource>();
        endSound.PlayOneShot(congratulations);
        endSound.PlayOneShot(cheering);
    }


    public void MainMenu()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(0);
    }
}
