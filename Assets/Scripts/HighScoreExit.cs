using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HighScoreExit : MonoBehaviour {

    public static int c;

    


     
   
    public void NextStage()
    {

 

       SceneManager.LoadScene(c+1);
            
       TimeCounter.time = 0f;

        
       
    }

    public void ExitLevel()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(0);
    }
}
