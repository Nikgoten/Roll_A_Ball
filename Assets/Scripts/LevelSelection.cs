﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelection : MonoBehaviour {

    public Button backButton;

    public GameObject Level01Button;
    public GameObject Level02Button;
    public GameObject Level03Button;

    public Image Level01;
    public Image Level02;
    public Image Level03;


    void Start () {

        Level01.enabled = false;
        Level01Button.SetActive(false);

        Level02.enabled = false;
        Level02Button.SetActive(false);

        Level03.enabled = false;
        Level03Button.SetActive(false);

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

        SceneManager.LoadScene("Level_01");
    }

    public void LevelTwoButton()
    {

        SceneManager.LoadScene("Level_02");
    }

    public void LevelThreeButton()
    {

        SceneManager.LoadScene("Level_03");
    }

    public void LevelCheck()
    {
        if (PlayerPrefs.GetInt("Level_01") == 1)
        {
            Level01.enabled = true;
            Level01Button.SetActive(true);
        }

        if (PlayerPrefs.GetInt("Level_02") == 1)
        {
            Level02.enabled = true;
            Level02Button.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level_03") == 1)
        {
            Level03.enabled = true;
            Level03Button.SetActive(true);
        }
    }
}
