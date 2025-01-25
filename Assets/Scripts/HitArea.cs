using UnityEngine;

public class HitArea : MonoBehaviour
{
    public int damage = 1;
    public double scorePenalty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInParent<PlayerBubble>().Hit(damage, scorePenalty);
    }
}
