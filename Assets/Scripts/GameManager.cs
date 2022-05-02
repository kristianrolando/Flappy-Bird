using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreTetx;
    [SerializeField] GameObject scoreObject;
    [SerializeField] GameObject gameOver;
    [SerializeField] Text scoreGameOver;
    [SerializeField] Text bestScore;
    [SerializeField] int increaseDifficultByScore = 50;

    public float speedPipes = 2.3f;
    public float timeSpawn = 3f;

    Bird bird;
    SpawnPipes spawn;
    int score;
    bool isDifficult;
    int tempScore = 1;
    

    void Start()
    {
        bird = GameObject.Find("Bird").GetComponent<Bird>();
        spawn = GameObject.Find("PipesGenerator").GetComponent<SpawnPipes>();
        spawn.timeSpawn = timeSpawn;

    }

    void Update()
    {
        Difficult(25,10);
        if(bird.isDie)
        {
            gameOver.SetActive(true);
        }
        CheckHighScore();
        bestScore.text = "" + PlayerPrefs.GetInt("Best Score");
    }

    void Difficult(int timeSpawn, int speedPipes)
    {
        if (score % increaseDifficultByScore == 0 && tempScore != score)
        {
            isDifficult = true;
        }

        if(score > 0 && isDifficult)
        {
            float t = spawn.timeSpawn - (spawn.timeSpawn * timeSpawn / 100);
            float s = (this.speedPipes * speedPipes / 100) + this.speedPipes;

            spawn.timeSpawn = t;
            this.speedPipes = s;

            tempScore = score;
            isDifficult = false;
        }
    }

    public void ScoreIncrement()
    {
        scoreObject.SetActive(true);
        score++;
        PlayerPrefs.SetInt("score", score);
        scoreTetx.text = "" + score;
        scoreGameOver.text = "" + score;
    }
    void CheckHighScore()
    {
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("Best Score"))
        {
            PlayerPrefs.SetInt("Best Score", PlayerPrefs.GetInt("score"));
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
