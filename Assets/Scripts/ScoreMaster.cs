using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreMaster : MonoBehaviour {

    public int score;
    public TimeCounter tm;
    public float bestTime;
    
    // Use this for initialization
	void Start ()
    {

        tm.timeCounter();
        


        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }    

    if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetInt("BestTime");
        }
	}
	
	// Update is called once per frame
	
}
