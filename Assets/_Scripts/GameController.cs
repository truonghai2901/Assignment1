using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Scoreboard")]
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _score;

    public Text livesLabel;
    public Text scoreLabel;

    [Header("UI Control")]
    public GameObject startLabel;
    public GameObject startButton;
    public GameObject endLabel;
    public GameObject restartButton;

    //public properties
    public int Lives
    {
        get
        {
            return _lives;
        }
        set
        {
            _lives = value;
            if (_lives <= 0)
            {
                SceneManager.LoadScene("End");
            }
            livesLabel.text = "Lives: " + _lives.ToString();
        }
    }
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreLabel.text = "Score: " + _score.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Start":
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                break;
            case "Main":
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                break;
            case "End":
                startLabel.SetActive(false);
                startButton.SetActive(false);
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                break;
        }
        Lives = 5;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    // Event Handlers
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}