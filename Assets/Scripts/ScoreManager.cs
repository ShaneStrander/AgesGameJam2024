using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        InvokeRepeating("IncreaseScore", 1f, 1f); // Call IncreaseScore function every 1 second
    }

    void IncreaseScore()
    {
        score += 10;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }
}