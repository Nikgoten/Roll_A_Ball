using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class ScoreMaster : MonoBehaviour
{
    [SerializeField]
    private InputField input;
    [SerializeField]
    private CanvasGroup highscoreGroup;
    [SerializeField]
    private Button mainMenu;
    [SerializeField]
    private Button nextLevel;
    [SerializeField]
    private CanvasGroup nameEnterGroup;

    [SerializeField]
    private Text[] names;
    [SerializeField]
    private Text[] scores;

    //public GoalEvent goalEvent;

    public static string previousSceneName;
    


    private HighScoreContainer container = new HighScoreContainer();

    [System.Serializable]
    public class HighScoreContainer
    {
        public string[] names = new string[0];
        public float[] scores = new float[0];
    }

    public struct NameScorePair
    {
        public string name;
        public float time;

        public NameScorePair(string name, float time)
        {
            this.name = name;
            this.time = time;
        }
    }

    private void Start()
    {
        highscoreGroup.alpha = 0f;
        highscoreGroup.blocksRaycasts = false;
        highscoreGroup.interactable = false;
        mainMenu.enabled = false;
        nextLevel.enabled = false;
        

    }

    public void SaveHighscore()
    {
        SaveToDisk();
        DisplayHighscore();
    }

    private void DisplayHighscore()
    {
        nameEnterGroup.alpha = 0f;
        nameEnterGroup.blocksRaycasts = false;
        nameEnterGroup.interactable = false;

        highscoreGroup.alpha = 1f;
        highscoreGroup.blocksRaycasts = true;
        highscoreGroup.interactable = true;

        mainMenu.enabled = true;
        nextLevel.enabled = true;


        for (int i = 0; i < names.Length && i < scores.Length; i++)
        {
            names[i].text = "";
            scores[i].text = "";
        }


        //Sort scores according to time
        NameScorePair[] pairs = new NameScorePair[container.names.Length];

        for (int i = 0; i < pairs.Length; i++)
        {
            pairs[i] = new NameScorePair(container.names[i], container.scores[i]);
        }

        Array.Sort(pairs, new PairComparer());

        //Display scores
        for (int i = 0; i < names.Length && i < pairs.Length; i++)
        {
            names[i].text = pairs[i].name;
        }

        for (int i = 0; i < scores.Length && i < container.scores.Length; i++)
        {
            float time = pairs[i].time;

            float minutes = Mathf.Floor(time / 60.0f); //Divide the guiTime by sixty to get the minutes.
            float seconds = time % 60f;  //Use the euclidean division for the seconds.
            float fraction = (time * 100) % 100;

            scores[i].text = string.Format("{0:00} : {1:00} :{2:00}", minutes, seconds, fraction);
        }
    }

    private void SaveToDisk()
    {
        if (!Directory.Exists("Highscores"))
        {
            Directory.CreateDirectory("Highscores");
        }

        if (!File.Exists("Highscores/"+previousSceneName+".txt"))
        {
           

            File.WriteAllLines("Highscores/"+previousSceneName+".txt", new string[] { "" });
        }

        //Highscore already exists
        string[] contentArr = File.ReadAllLines("Highscores/"+previousSceneName+".txt");
        string content = "";

        for (int i = 0; i < contentArr.Length; i++)
        {
            content += contentArr[i];
        }

        HighScoreContainer tempCont = JsonUtility.FromJson<HighScoreContainer>(content);
        if (tempCont != null)
        {
            container = tempCont;
        }

        //Add one null place to arrays
        Array.Resize(ref container.names, container.names.Length + 1);
        Array.Resize(ref container.scores, container.scores.Length + 1);

        //Add new value to existing container
        container.names[container.names.Length - 1] = input.textComponent.text;
        container.scores[container.scores.Length - 1] = TimeCounter.time;

        string[] newContent = new string[] { JsonUtility.ToJson(container, true) };

        File.WriteAllLines("Highscores/"+previousSceneName+".txt", newContent);
    }

    public class PairComparer : IComparer<NameScorePair>
    {
        public int Compare(NameScorePair x, NameScorePair y)
        {
            if (x.time > y.time)
            {
                return 1;
            }
            else if (x.time == y.time)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
