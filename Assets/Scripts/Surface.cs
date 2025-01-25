using UnityEngine;

public class Surface : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInParent<PlayerBubble>().Win();
    }
}
