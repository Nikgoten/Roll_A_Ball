using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalEvent : MonoBehaviour
{
    
    public Canvas End;
    private bool EndGame = false;
   

    private HSBColor color;
    private float counter;

    [SerializeField]
    private float speed;
    [SerializeField]
    private MeshRenderer rend;
    [SerializeField]
    private Light dLight;

    private void Start()
    {
        color = new HSBColor(0, 1, 1, 0.5f);
        End.enabled = false;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GoToHighscore();
            EndGame = true;
            PlayerPrefs.SetInt("Lvl_01_finished", 1);

        }

        
    }

    public void GoToHighscore()
    {
        SceneManager.LoadScene(3);
    }

   

    private void Update()
    {
        
        if (EndGame == true)
        {

            Time.timeScale = 0;
            EndGame = true;
            End.enabled = true;
        }

        if (EndGame == false)
        {
            Time.timeScale = 1;
            EndGame = false;
            End.enabled = false;
        }


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
