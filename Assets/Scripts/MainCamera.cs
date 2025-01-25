using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float maxCamX = 2;
    public float maxCamY = 1;
    public float maxCamScale = 1.2f;
    public float maxPlayerX = 6;
    public float maxPlayerY = 9;
    public float posInertia;
    public float scaleInertia;

    private float scale = 1.0f;

    private CameraManager camMgr;
    private Camera cam;
    private Matrix4x4 baseMatrix;

    void Start()
    {
        camMgr = GetComponentInParent<CameraManager>();
        cam = GetComponent<Camera>();
        baseMatrix = cam.projectionMatrix;
    }

    // Update is called once per frame
    void Update()
    {
        float posX = PlayerBubble.Instance.transform.position.x;
        float x = 1.0f - Mathf.Abs(posX / maxPlayerX);
        float v = (1.0f - x * x) * Mathf.Sign(posX);

        float posY = PlayerBubble.Instance.transform.position.y - (camMgr.transform.position.y + maxPlayerY / 2.0f);
        float y = 1.0f - Mathf.Abs(posY / maxPlayerY);
        float u = (1.0f - y * y) * Mathf.Sign(posY);

        Vector3 target = new Vector3(v * maxCamX, u * maxCamY, 0.0f);

        float t = 1.0f - Mathf.Exp(-Time.deltaTime * Mathf.Exp(posInertia));
        transform.localPosition = Vector3.Lerp(transform.localPosition, target, t);


        float speed = PlayerBubble.Instance.rigidBody.linearVelocity.magnitude / PlayerBubble.Instance.maxSpeed;
        float targetScale = Mathf.Lerp(1.0f, maxCamScale, speed);

        float t1 = 1.0f - Mathf.Exp(-Time.deltaTime * Mathf.Exp(scaleInertia));
        scale = Mathf.Lerp(scale, targetScale, t1);

        cam.projectionMatrix = baseMatrix * Matrix4x4.Scale(Vector3.one / scale);
    }
}
