﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalEvent : MonoBehaviour
{
    
    public Canvas End;
    public PauseMenu pauseMenu;
  


    private HSBColor color;
    private float counter;

    [SerializeField]
    private float speed;
    [SerializeField]
    private MeshRenderer rend;
    [SerializeField]
    private Light dLight;

    [SerializeField]
    public string intDatabaseName;

    public AudioClip cheering;
    public AudioClip StageClear;

    private AudioSource source;
    public AudioSource LevelMusic;

    private void Start()
    {
        color = new HSBColor(0, 1, 1, 0.5f);
        End.enabled = false;
        GameOverScript.lastScene = SceneManager.GetActiveScene().buildIndex;
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            source.PlayOneShot(cheering);
            source.PlayOneShot(StageClear);
            LevelMusic.Stop();

            End.enabled = true;
            pauseMenu.enabled = false;

            ScoreMaster.previousSceneName = intDatabaseName;

            HighScoreExit.c = SceneManager.GetActiveScene().buildIndex;
            
            PlayerPrefs.SetInt(intDatabaseName, 1);

            Time.timeScale = 0;
            

        }

        
    }

    public void GoToHighscore()
    {
        SceneManager.LoadScene(2);
    }

   

    private void Update()
    {
        
        counter += Time.deltaTime * speed;

        color.h = counter % 1f;

        Material m = rend.material;
        Color c = color.ToColor();

        dLight.color = c;
        c.a = 0.5f;
        m.color = c;
        m.SetColor("_EmissionColor", c);
        rend.material = m;
    }
}
