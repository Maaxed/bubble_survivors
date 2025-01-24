using UnityEngine;

public class HitArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInParent<PlayerBubble>().Hit();
    }
}
