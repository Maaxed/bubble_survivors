using UnityEngine;

public class HitArea : MonoBehaviour
{
    public int damage = 1;
    public double scorePenalty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBubble player = collision.GetComponentInParent<PlayerBubble>();
        if (player != null)
        {
            player.Hit(damage, scorePenalty);
            enabled = false;
        }
    }
}
