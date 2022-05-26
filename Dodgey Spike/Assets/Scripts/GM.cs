using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static GM instance;

    public GameObject pauseInterface;
    public GameObject endGameInterface;
    public Text scoreText;
    int score;

    public AudioSource[] audioClips;

    public bool isPlaying = false;

    public GameObject playerBall;
    public GameObject explosionPrefab;

    public AudioSource clickSnd;

    [Header("Quit Button")]
    public Image[] quitButtons;
    public Sprite[] quitButtonSprites;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        endGameInterface.SetActive(false);
        setupColorScheme();
        setScore(0);

        pauseGame();

        playAudio(0, true);
    }

    public void startGame()
    {
        isPlaying = true;
        pauseInterface.SetActive(false);
        Time.timeScale = 1;
    }

    public void pauseGame()
    {
        isPlaying = false;
        pauseInterface.SetActive(true);
        Time.timeScale = 0;
    }

    public void endGame()
    {
        isPlaying = false;
        playAudio(3, false);

        //Destroy ball and add effects
        Instantiate(explosionPrefab, playerBall.transform.position, Quaternion.identity);
        Destroy(playerBall);

        //Interface
        endGameInterface.SetActive(true);

        //Make text not translucent
        Color textColor = ColorPallette.instance.getThemeColor(1);
        textColor = new Color(textColor.r, textColor.g, textColor.b, 1);
        scoreText.color = textColor;

        // Save Data
        DataHandler.instance.finalizeResults(score);

        //Ball Spawner
        BallSpawner.instance.stopSpawn();
    }

    public void quitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    #region scoring
    public void setScore(int val) { scoreText.text = val.ToString(); }
    public void incrementScore()
    {
        if (isPlaying)
        {
            score++;
            setScore(score);
        }
        
    }
    #endregion


    void setupColorScheme()
    {
        //Background color
        Camera cam = Camera.main;
        cam.backgroundColor = ColorPallette.instance.getThemeColor(2);

        //Score Text
        Color textColor = ColorPallette.instance.getThemeColor(1);
        textColor = new Color(textColor.r, textColor.g, textColor.b, 0.25f);
        scoreText.color = textColor;

        //Quit button
        for(int i = 0; i < quitButtons.Length; i++)
        {
            quitButtons[i].sprite = quitButtonSprites[ColorPallette.instance.getColorTheme()];
        }
    }

    #region audio
    public void playAudio(int index, bool loop)
    {
        audioClips[index].Play();
        audioClips[index].loop = loop;
    }

    public void pauseAudio(int index)
    {
        audioClips[index].Pause();
    }

    public void resumeAudio(int index)
    {
        audioClips[index].UnPause();
    }

    public void stopAudio(int index)
    {
        audioClips[index].Stop();
    }
    #endregion

    public void playClickSnd() { clickSnd.Play(); }

}
