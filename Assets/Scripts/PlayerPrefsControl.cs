using UnityEngine;
using System.Collections;

public class PlayerPrefsControl : MonoBehaviour {

    

	void Start () {
        

       

    }
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
