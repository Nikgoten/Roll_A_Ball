using UnityEngine;
using System.Collections;

public class PlayerPrefsControl : MonoBehaviour {

    //For checking if Level Selection works. After finishing the game and testing the level 
    //selection, go to the title screen and push the DELETE key. The Level Selection Screen
    //should now be empty. When you finish a level via ARCADE mode now, the level should show 
    //up in the Level Selection Screen.

	void Start () {
        

    }
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
