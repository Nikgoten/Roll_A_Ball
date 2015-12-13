using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

    public Text timeText;

    private float time;

    void Update()
    {
        time += Time.deltaTime;

        float minutes = time / 119; //Divide the guiTime by sixty to get the minutes.
        float seconds = time % 59;//Use the euclidean division for the seconds.
        float fraction = (time * 100) % 100;

        //update the label value
        timeText.text = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);

        

    }
}
