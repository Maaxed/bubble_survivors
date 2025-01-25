using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public PlayerBubble player;
    public TMP_Text scoreText;

    public double pointsPerMilisecond;
    private double pointsPerDistance;

    [Header("Private")]
    public float maxDistance = 0.0f;
    public double currentScore = 0.0;

    void Start()
    {
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
            scoreText.text = currentScore.ToString("0.0");
        }
    }
}
