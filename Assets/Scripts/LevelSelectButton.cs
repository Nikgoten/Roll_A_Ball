using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelectButton : MonoBehaviour {

    public Button levelSelectButton;

	// Use this for initialization
	void Start () {

        levelSelectButton = levelSelectButton.GetComponent<Button>();

    }

    // Update is called once per frame
    public void LevelSelection()
    {
        
        SceneManager.LoadScene(1);
    }
}
