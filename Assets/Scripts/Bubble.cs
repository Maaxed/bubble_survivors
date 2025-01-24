using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float baseUpwardSpeed;
    
    private Rigidbody2D rigidBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.linearVelocity = Vector3.up * baseUpwardSpeed;

    }
}
