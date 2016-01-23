using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class TimeCounter : MonoBehaviour {

    public Text timeText;
    public static float time;
    

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
