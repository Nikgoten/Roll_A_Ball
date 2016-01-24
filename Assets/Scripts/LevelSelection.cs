using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelection : MonoBehaviour {

    public Button backButton;

    public GameObject Level01Button;
    //public GameObject Level02Button;

    public Image Level01;
    //public Image Level02;

    void Start () {

        Level01.enabled = false;
        Level01Button.SetActive(false);

        //Level02.enabled = false;
        //Level02Button.SetActive(false);

        backButton = backButton.GetComponent<Button>();


    }

    void Update ()
    {
        LevelCheck();
    }

    public void BackButton()
    {

        SceneManager.LoadScene(0);
    }

    public void LevelOneButton()
    {

        SceneManager.LoadScene(2);
    }

    public void LevelCheck()
    {
        if (PlayerPrefs.GetInt("Lvl_01_finished") == 1)
        {
            Level01.enabled = true;
            Level01Button.SetActive(true);
        }
    }
}
