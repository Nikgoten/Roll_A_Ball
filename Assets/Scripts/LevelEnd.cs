using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    public Canvas End;
    
    void Start () {
	
	}
	
	
	void Update () {

        

        if (End.enabled == true)
        {

            Time.timeScale = 0;

        }
    }
}
