using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

    public Button nextLevelButton;

	// Use this for initialization
	void Start () {

        nextLevelButton = nextLevelButton.GetComponent<Button>();

    }

    // Update is called once per frame
    public void NextStage()
    {
        TimeCounter.time = 0f;
        SceneManager.LoadScene(0);
    }
}
