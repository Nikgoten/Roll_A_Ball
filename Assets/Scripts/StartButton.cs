using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    public Button startButton;

    //public Button exitButton;
   
    
    void Start () {

        startButton = startButton.GetComponent<Button> ();

        //exitButton = exitButton.GetComponent<startButton>();
        
	}

    public void StartLevel ()
    {
        SceneManager.LoadScene(1);
    }
	
	// Update is called once per frame
	
}
