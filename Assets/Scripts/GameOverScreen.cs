using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

    // Use this for initialization
    public Button exitButton;
   
    
    void Start()
    {

        

        exitButton = exitButton.GetComponent<Button>();

    }

   

    public void ExitLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(0);
    }

}
