using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour {

    private bool pauseGame = false;
    public Canvas End;
    public Canvas Menu;
   


    void Start ()
    {
        Menu.enabled = false;
        
    }

	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if(pauseGame)
            {
                Time.timeScale = 0f;
                pauseGame = true;
                Menu.enabled = true;
                PlayerController.playerSound.Pause();
                
            }
            else
            {
                Time.timeScale = 1f;
                PlayerController.playerSound.Play();
            }
        }
        
        if(pauseGame == false && !End.enabled)
        {
            Time.timeScale = 1;
            pauseGame = false;
            Menu.enabled = false;

}

	}
}
