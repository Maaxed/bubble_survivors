using UnityEngine;

public class PlayerBubble : MonoBehaviour
{
    public float baseUpwardSpeed;
    public float inputSpeed;

    public int health = 1;
    
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


    public void Kill()
    {
        health = 0;

        Debug.Log("Dead !");
    }

    public void Hit()
    {
        health--;
        if (health == 0)
        {
            Kill();
        }
    }

    public void AddBubble()
    {
        health++;
    }
}
