using UnityEngine;

public class FollowerMonster : Monster
{
    public float speed;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 delta = PlayerBubble.Instance.transform.position - transform.position;
        if (delta.sqrMagnitude > 0.01)
        {
            rigidBody.linearVelocity = delta.normalized * speed;
        }
    }
}
