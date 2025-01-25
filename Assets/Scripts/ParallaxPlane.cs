using UnityEngine;

public class ParallaxPlane : MonoBehaviour
{
    public CameraManager cameraMgr;
    public float value;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraMgr.transform.position * value;
    }
}
