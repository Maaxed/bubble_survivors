using UnityEngine;

public class SimpleMonster : Monster
{
    public Vector2 velocity;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidBody.linearVelocity = velocity;
    }
}
