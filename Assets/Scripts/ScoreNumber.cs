using TMPro;
using UnityEngine;

public class ScoreNumber : MonoBehaviour
{
    public TMP_Text scoreTexts;
    public Color positive;
    public Color negative;

    public float minSpeedX;
    public float maxSpeedX;
    public float minSpeedY;
    public float maxSpeedY;

    public float xInertia;
    public float yInertia;

    public float timeBeforeFade;
    public float fadeInertia;


    private float speedX = 0.0f;
    private float speedY = 0.0f;
    private float alpha = 1.0f;

    private float fadeTimer = 0.0f;


    void Start()
    {
        Renderer renderer = scoreTexts.GetComponent<Renderer>();
        renderer.sortingLayerName = "WorldUi";
    }

    public void Init(bool left, double score)
    {
        speedX = Random.Range(minSpeedX, maxSpeedX);
        speedY = Random.Range(minSpeedY, maxSpeedY);

        if (left)
        {
            speedX = -speedX;
        }

        scoreTexts.color = score >= 0 ? positive : negative;
        scoreTexts.text = "<mspace=0.4em>" + score.ToString("+0;-#");
        fadeTimer = timeBeforeFade;
    }

    void Update()
    {
        float tx = 1.0f - Mathf.Exp(-Time.unscaledDeltaTime * Mathf.Exp(xInertia));
        speedX = Mathf.Lerp(speedX, 0.0f, tx);

        float ty = 1.0f - Mathf.Exp(-Time.unscaledDeltaTime * Mathf.Exp(yInertia));
        speedY = Mathf.Lerp(speedY, 0.0f, ty);

        transform.position += new Vector3(speedX, speedY, 0.0f) * Time.unscaledDeltaTime;

        fadeTimer -= Time.unscaledDeltaTime;

        if (fadeTimer < 0.0)
        {
            float ta = 1.0f - Mathf.Exp(-Time.unscaledDeltaTime * Mathf.Exp(fadeInertia));
            alpha = Mathf.Lerp(alpha, 0.0f, ta);
            if (alpha < 0.001f)
            {
                Destroy(gameObject);
                return;
            }
        }

        Color c = scoreTexts.color;
        c.a = alpha;
        scoreTexts.color = c;
    }
}
