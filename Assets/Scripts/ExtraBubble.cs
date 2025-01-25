using UnityEngine;

public class ExtraBubble : MonoBehaviour
{
    public int value = 1;
    public double score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInParent<PlayerBubble>().AddBubble(value);
        ScoreManager.Instance.AddScore(score);
        Destroy(gameObject);
    }
}
