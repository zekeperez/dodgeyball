using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject[] interfaces;
    public Text highScoreText;

    public AudioSource click;

    private void Start()
    {
        interfaces[0].SetActive(true);
        interfaces[1].SetActive(false);

        displayHighScore();
    }

    void displayHighScore()
    {
        highScoreText.text = "High Score: " + DataHandler.instance.getHighScore().ToString() ;
    }

    public void playGame()
    {
        SceneManager.LoadScene("Play");
    }

    public void instructions(bool val)
    {
        interfaces[0].SetActive(!val);
        interfaces[1].SetActive(val);
    }

    public void playClickSnd()
    {
        click.Play();
    }
}
