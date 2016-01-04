using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    public Button startButton;

   

    public Button exitButton;
   
    
    void Start () {

        startButton = startButton.GetComponent<Button> ();

        exitButton = exitButton.GetComponent<Button>();
        
	}

    public void StartLevel ()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(2);
    }

    public void ExitLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(0);
    }
    

}
