using UnityEngine;
using System.Collections;

public class GoalEvent : MonoBehaviour {

    

	// Use this for initialization
	
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartLevel();
           
        }
    }

    public void StartLevel()
    {
        Application.LoadLevel(2);
    }
}
