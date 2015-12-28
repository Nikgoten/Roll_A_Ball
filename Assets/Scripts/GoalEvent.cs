using UnityEngine;
using System.Collections;

public class GoalEvent : MonoBehaviour {

    public TimeCounter tm;

    void Start ()
    {
        //tm.timeCounter();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartLevel();
           
        }
    }

    public void StartLevel()
    {
        //SaveScore();
        Application.LoadLevel(2);
    }

    //void SaveScore()
    //{
        //PlayerPrefs.SetInt("Score", tm.timeCounter);
    //}
}
