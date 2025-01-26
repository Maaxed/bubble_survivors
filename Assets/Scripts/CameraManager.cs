using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public PlayerBubble mainCharacter;

    private Rigidbody2D rigidBody;

    public static CameraManager Instance { get; private set; }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    void Update()
    {
        rigidBody.linearVelocity = Vector3.up * mainCharacter.CurrentUpwardSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.GetComponentInParent<Monster>();
        if (monster != null)
        {
            monster.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Monster monster = collision.GetComponentInParent<Monster>();
        if (monster != null)
        {
            monster.enabled = false;
        }
    }
}
