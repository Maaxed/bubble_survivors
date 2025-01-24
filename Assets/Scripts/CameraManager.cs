using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Bubble mainCharacter;

    public float cameraSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * mainCharacter.baseUpwardSpeed * Time.deltaTime;
    }
}
