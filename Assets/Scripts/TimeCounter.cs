using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

    public Text timeText;
   
    public float time;

    //void Start()
    //{
        //GameObject Goal = GameObject.Find("Goal");
        //GoalEvent goalEvent = Goal.GetComponent<GoalEvent>();
        //goalEvent.timeScore = true;
    //}

    void Update()
    {
        timeCounter();
    }

    public void timeCounter()
    {
        time += Time.deltaTime;

        float minutes = Mathf.Floor(time / 60.0f); //Divide the guiTime by sixty to get the minutes.
        float seconds = time % 60f;  //Use the euclidean division for the seconds.
        float fraction = (time * 100) % 100;

        //update the label value
        timeText.text = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);

    }
}
