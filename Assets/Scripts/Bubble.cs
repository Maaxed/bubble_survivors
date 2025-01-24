using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float baseUpwardSpeed;
    public float inputSpeed;
    
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 baseUpwardMotion = Vector3.up * baseUpwardSpeed;
        Vector3 inputVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * inputSpeed;
        rigidBody.linearVelocity = baseUpwardMotion + inputVec;

    }
}
