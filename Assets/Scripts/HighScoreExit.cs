using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreExit : MonoBehaviour {

    public Button scoreExit;

    // Use this for initialization
    void Start () {

        scoreExit = scoreExit.GetComponent<Button>();
    }

    // Update is called once per frame
    public void StartLevel()
    {
        Application.LoadLevel(0);
    }
}
