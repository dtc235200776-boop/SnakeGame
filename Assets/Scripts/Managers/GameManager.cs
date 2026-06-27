using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;

    public TMP_Text scoreText;
    
    public PlayerController playerController;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore()
    {
        score++;

        scoreText.text = "Score: " + score;
        if (score >= 20)
        {
            playerController.speed = 9f;
        }
        else if (score >= 15)
        {
            playerController.speed = 8f;
        }
        else if (score >= 10)
        {
            playerController.speed = 7f;
        }
        else if (score >= 5)
        {
            playerController.speed = 6f;
        }
        else
        {
            playerController.speed = 5f;
        }
    }
}