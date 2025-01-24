using UnityEngine;

public class ExtraBubble : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInParent<PlayerBubble>().AddBubble();
        Destroy(gameObject);
    }
}
