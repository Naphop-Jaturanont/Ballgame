using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTextMeshPro;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private TMP_Text scoreTextMeshPro2;
    [SerializeField] private TMP_Text countdownText2;
    [SerializeField] private GameObject gameOverObject;
    [SerializeField] private GameObject pauseObject;
    private BallController bc;
    public float timeRemaining = 180f; // 3 minutes in seconds
    public bool gameover = false;
    public bool paused = false;
    private int score = 0;

    private void Start()
    {
        UpdateScore(0);
        gameOverObject.SetActive(false); // hide the game over object at the start
        pauseObject.SetActive(false); // hide the pause object at the start
        bc = FindObjectOfType<BallController>(); // find the BallController component and assign it to bc
        scoreTextMeshPro2.text = scoreTextMeshPro.text; // copy scoreTextMeshPro to scoreTextMeshPro2
    }

    private void Update()
    {
        if (gameover == true || paused == true)
        {
            return; // freeze timer if game over or paused
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateCountdownText();
        }
        else
        {
            // Time is up
            timeRemaining = 0;
            UpdateCountdownText();
            // TODO: Do something when the timer reaches 0
            gameover = true;
            Gameover();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            if (paused == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void UpdateScore(int change)
    {
        score += change;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreTextMeshPro.text = "Score: " + score;
        scoreTextMeshPro2.text = scoreTextMeshPro.text; // update scoreTextMeshPro2 with new score
    }

    private void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        countdownText2.text = countdownText.text; // update countdownText2 with new countdown
    }

    private void Gameover()
    {
        bc.canControl = false; // disable player control
        bc.GetComponent<Rigidbody>().velocity = Vector3.zero; // delete all forces on the ball
        bc.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameOverObject.SetActive(true); // show the game over object

        // hide the score and countdown text
        scoreTextMeshPro.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
    }
    
    private void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        pauseObject.SetActive(true);
    }
    
     public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1;
        pauseObject.SetActive(false);
    }
}
