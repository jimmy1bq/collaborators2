using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    int score = 0;
    bool gameOver = false;
    public static GameManager instnace;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI ScoreDisplay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() {
       instnace = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetKeyDown(KeyCode.R)){
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        ScoreDisplay.text = "Score: " + score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
    }
}
