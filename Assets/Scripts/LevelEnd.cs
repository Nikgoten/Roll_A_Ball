﻿using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    public Canvas End;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        

        if (End.enabled == true)
        {

            Time.timeScale = 0;

        }
    }
}
