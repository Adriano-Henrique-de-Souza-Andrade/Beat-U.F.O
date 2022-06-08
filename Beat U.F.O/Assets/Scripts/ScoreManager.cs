using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highscoreText;

    public GameObject GameOver;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }
    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint()
    {
        score++;
        if (highscore <= score){
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
    public void GameOverAppear()
    {
        GameOver.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("singleplay");
    }
}
