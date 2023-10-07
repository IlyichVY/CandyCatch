using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public GameObject livesHolder;
    public GameObject gameOverPanel;
    private int _score = 0;
    private int _lives = 3;
    private bool _gameOver = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementScore()
    {
       if (!_gameOver)
        {
            _score++;
            scoreText.text = _score.ToString();
            print(_score);
        }
    }

    public void DecrementLives() 
    {
        if (_lives > 0)
        {
            _lives--;
            livesHolder.transform.GetChild(_lives).gameObject.SetActive(false);
            print(_lives);
        }
        if (_lives <= 0)
        {
            _gameOver = true;
            GameOver();
        }
    }
    public void GameOver()
    {
        print("GameOver");
        CandySpawner.instance.StopSpawningCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}
