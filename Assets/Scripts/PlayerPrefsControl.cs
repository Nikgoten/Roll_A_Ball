using UnityEngine;
using System.Collections;

public class PlayerPrefsControl : MonoBehaviour {

    //For checking if Level Selection works.

	void Start () {
        

    }
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
