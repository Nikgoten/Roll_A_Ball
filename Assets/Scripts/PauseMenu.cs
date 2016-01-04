using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour {

    private bool pauseGame = false;

    public Canvas Menu;
	
	
    void Start ()
    {
        Menu.enabled = false;
    }

	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if(pauseGame == true)
            {
                Time.timeScale = 0;
                pauseGame = true;
                Menu.enabled = true;
            }
        }

        if(pauseGame == false)
        {
            Time.timeScale = 1;
            pauseGame = false;
            Menu.enabled = false;
        }

	}
}
