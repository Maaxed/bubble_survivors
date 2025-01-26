using UnityEngine;

public class SimpleMonster : Monster
{
    public Vector2 velocity;

    protected Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        rigidBody.linearVelocity = velocity;
    }
}
