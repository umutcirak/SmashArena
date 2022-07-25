using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI health_value;
    [SerializeField] TextMeshProUGUI score_value;

    [SerializeField] float catchSpeed = 10f;

    private float displayScore;
    private float displayHealth;

    PlayerSingleton playerValues;
    private void Awake()
    {
        playerValues = FindObjectOfType<PlayerSingleton>();
    }

    void Start()
    {
        displayScore = playerValues.score;
        displayHealth = playerValues.health;
    }

    void Update()
    {
        DisplayScore();
        DisplayHealth();
    }


    void DisplayScore()
    {
        if (displayScore - playerValues.score > 1f)
        {
            displayScore = Mathf.Lerp(displayScore, playerValues.score, catchSpeed * Time.deltaTime);
        }
        else
        {
            displayScore = playerValues.score;
        }

        score_value.text = displayScore.ToString("0");
    }

    void DisplayHealth()
    {
        if (displayHealth - playerValues.health > 1f)
        {
            displayHealth = Mathf.Lerp(displayScore, playerValues.score, catchSpeed * Time.deltaTime);
        }
        else
        {
            displayHealth = playerValues.health;
        }

        health_value.text = displayHealth.ToString("0");
    }

}
