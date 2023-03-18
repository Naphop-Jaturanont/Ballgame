using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTextMeshPro;
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameObject gameOverObject;
    private BallController bc;
    public float timeRemaining = 180f; // 3 minutes in seconds
    private bool gameover = false;
    private int score = 0;

    private void Start()
    {
        UpdateScore(0);
        gameOverObject.SetActive(false); // hide the game over object at the start
        bc = FindObjectOfType<BallController>(); // find the BallController component and assign it to bc
    }

    private void Update()
    {
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
            Gameover(); // check if game over
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
    }

    private void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void Gameover()
    {
        bc.canControl = false; // disable player control
        bc.GetComponent<Rigidbody>().velocity = Vector3.zero; // delete all forces on the ball
        bc.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameOverObject.SetActive(true); // show the game over object  
    }
}
