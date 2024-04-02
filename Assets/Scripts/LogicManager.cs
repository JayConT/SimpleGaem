using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public EnemySpawner spawner;
    public AudioPlayerScript audioPlayer;
    public int score;
    public Text scoreText;
    public Text highScore;
    public GameObject endScreen;
    public bool gameActive;

    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemySpawner>();
        audioPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioPlayerScript>();
        gameActive = true;
        loadScore();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void backToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void gameOver()
    {
        gameActive = false;
        audioPlayer.duckAudio();
        spawner.StopSpawning();

        int highestScore = PlayerPrefs.GetInt("highScore");
        if (score > highestScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScore.text = score.ToString();
        }
        endScreen.SetActive(true);
    }

    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void loadScore()
    {
        int highestScore = PlayerPrefs.GetInt("highScore");
        highScore.text = highestScore.ToString();
    }
}
