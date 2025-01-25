using UnityEngine;

public class Surface : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBubble player = collision.GetComponentInParent<PlayerBubble>();
        if (player != null)
        {
            player.Win();
        }
    }
}
