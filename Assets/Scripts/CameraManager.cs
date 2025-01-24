using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Bubble mainCharacter;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidBody.linearVelocity = Vector3.up * mainCharacter.baseUpwardSpeed;
    }
}
