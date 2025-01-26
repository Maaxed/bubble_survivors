using UnityEngine;

public class FlipEyes : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (rigidBody.linearVelocity.x > 0.00001)
        {
            left.SetActive(false);
            right.SetActive(true);
        }
        else if (rigidBody.linearVelocity.x < -0.00001)
        {
            right.SetActive(false);
            left.SetActive(true);
        }
    }
}
