using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ToScore : MonoBehaviour {

    public Button toTheScore;

	
	void Start()
    {

        toTheScore = toTheScore.GetComponent<Button>();

    }


    public void ToHighScore()
    {
        
        SceneManager.LoadScene(2);
    }
}
