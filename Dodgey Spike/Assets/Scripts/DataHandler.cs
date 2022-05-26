using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler instance;

    string highscoreString = "HighScore";

    private void Awake()
    {
        if(instance == null) { instance = this; }
        else if (instance != this) { Destroy(this.gameObject); }

        DontDestroyOnLoad(this.gameObject);
    }

    public void finalizeResults(int score)
    {
        if (PlayerPrefs.HasKey(highscoreString))
        {
            if(getHighScore() < score) { setHighScore(score); }
        }
        else
        {
            setHighScore(score);
        }
    }

    void setHighScore(int val) { PlayerPrefs.SetInt(highscoreString, val); }

    public int getHighScore()
    {
        if (PlayerPrefs.HasKey(highscoreString))
        {
            return PlayerPrefs.GetInt(highscoreString);
        }
        else
        {
            return 0;
        }
    }
}
