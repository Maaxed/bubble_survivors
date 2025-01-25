using UnityEngine;

public class KillArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBubble player = collision.GetComponentInParent<PlayerBubble>();
        if (player != null)
        {
            player.Kill();
        }
    }
}
