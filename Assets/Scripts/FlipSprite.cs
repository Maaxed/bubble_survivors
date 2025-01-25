using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    public Sprite left;
    public Sprite right;

    private SpriteRenderer sprite;
    private Rigidbody2D rigidBody;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (rigidBody.linearVelocity.x > 0.00001)
        {
            sprite.sprite = right;
        }
        else if (rigidBody.linearVelocity.x < -0.00001)
        {
            sprite.sprite = left;
        }
    }
}
