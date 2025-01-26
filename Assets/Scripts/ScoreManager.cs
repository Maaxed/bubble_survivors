using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public PlayerBubble player;
    public TMP_Text scoreText;

    public float baseDelay;

    public double pointsPerMilisecond;
    private double pointsPerDistance;

    [Header("Private")]
    public float maxDistance = 0.0f;
    public double currentScore = 0.0;

    public double displayedScore = 0.0;

    public float timeDelay = 0.0f;

    public static ScoreManager Instance { get; private set; }

    void Start()
    {
        Instance = this;
        pointsPerDistance = pointsPerMilisecond * 1000.0f / player.baseUpwardSpeed;
        maxDistance = Mathf.Abs(player.transform.position.y);
    }

    void FixedUpdate()
    {
        float newDist = Mathf.Abs(player.transform.position.y);
        if (newDist > maxDistance)
        {
            currentScore += pointsPerDistance * (newDist - maxDistance);
            maxDistance = newDist;
        }
    }

    private void Update()
    {
        if (timeDelay <= Time.unscaledDeltaTime)
        {
            displayedScore = currentScore;
            timeDelay = 0;
        }
        else
        {
            displayedScore += (currentScore - displayedScore) * Time.unscaledDeltaTime / timeDelay;
            timeDelay -= Time.unscaledDeltaTime;
        }
        scoreText.text = "<mspace=0.4em>" + displayedScore.ToString("0.0");
    }

    public void AddScore(double score)
    {
        float time = baseDelay;
        float absScore = Mathf.Abs((float)score);
        if (absScore > 10.0f)
        {
            time = Mathf.Log10(absScore) * baseDelay;
        }
        timeDelay = Mathf.Max(timeDelay, baseDelay * time);

        currentScore += score;
        if (currentScore < 0.0)
        {
            currentScore = 0.0;
        }
    }

    public void ApplyPenalty(double penalty)
    {
        AddScore(-currentScore * penalty);
    }
}
