using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBubble : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject winScreen;
    public SpriteRenderer hitFeedbackSprite;

    public AudioSource grow;
    public AudioSource shrink;
    public AudioSource pop;
    public AudioSource music;

    public float baseUpwardSpeed;
    public float inputSpeed;
    public float baseScale;
    public int maxHealth;
    public float invulnerabilityTime;
    public float abilityCooldownTime;
    public double abilityPenalty;
    public float sizeSpeed;
    public float speedInertia;
    public float hitFeedbackInertia;
    public float hitFeedbackOpacity = 0.0f;

    public int health = 1;
    [Header("Private")]
    public float invulnerabilityTimer = 0.0f;
    public float abilityCooldownTimer = 0.0f;

    public float currentSize = 1.0f;
    public float currentHitFeedbackOpacity = 0.0f;


    private bool started = false;

    public float CurrentUpwardSpeed => started ? baseUpwardSpeed : 0.0f;

    public Rigidbody2D rigidBody { get; private set; }
    public float maxSpeed { get; private set; }

    public static PlayerBubble Instance { get; private set; }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        Instance = this;

        maxSpeed = new Vector2(baseUpwardSpeed, inputSpeed).magnitude;
    }

    void Update()
    {
        Vector2 inputVec = Vector2.ClampMagnitude(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), 1.0f) * inputSpeed;

        if (!started)
        {
            if (inputVec.sqrMagnitude > 0.01)
            {
                // start moving
                started = true;
            }
            else
            {
                return;
            }
        }

        Vector2 baseUpwardMotion = Vector2.up * baseUpwardSpeed;
        Vector2 targetVelocity = baseUpwardMotion + inputVec;
        float t = 1.0f - Mathf.Exp(-Time.deltaTime * Mathf.Exp(speedInertia));
        rigidBody.linearVelocity = Vector2.Lerp(rigidBody.linearVelocity, targetVelocity, t);

        if (invulnerabilityTimer > 0.0f)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }

        if (abilityCooldownTimer > 0.0f)
        {
            abilityCooldownTimer -= Time.deltaTime;
        }

        if (Input.GetAxis("Jump") > 0.01 && abilityCooldownTimer <= 0.0f)
        {
            ActivateAbility();
        }


        float ta = 1.0f - Mathf.Exp(-Time.unscaledDeltaTime * Mathf.Exp(hitFeedbackInertia));
        currentHitFeedbackOpacity = Mathf.Lerp(currentHitFeedbackOpacity, 0.0f, ta);

        Color c = hitFeedbackSprite.color;
        c.a = currentHitFeedbackOpacity;
        hitFeedbackSprite.color = c;

        UpdateSize();
    }

    private void UpdateSize()
    {
        float targetSize = health * baseScale;

        float t = 1.0f - Mathf.Exp(-Time.unscaledDeltaTime * Mathf.Exp(sizeSpeed));
        currentSize = Mathf.Lerp(currentSize, targetSize, t);

        transform.localScale = Vector3.one * currentSize;
    }

    public void ActivateAbility()
    {
        if (health <= 1)
        {
            return;
        }

        abilityCooldownTimer = abilityCooldownTime;
        health -= health / 2;
        currentHitFeedbackOpacity = hitFeedbackOpacity;
        ScoreManager.Instance.AddScore(-abilityPenalty);
        shrink.Play();
    }


    public void Kill()
    {
        health = 0;
        currentHitFeedbackOpacity = hitFeedbackOpacity;
        pop.Play();

        Debug.Log("Dead !");
        Time.timeScale = 0.0f;
        loseScreen.SetActive(true);
        music.Stop();
    }

    public void Hit(int damage, double scorePenalty)
    {
        if (invulnerabilityTimer > 0.0f)
            return;

        health -= damage;
        invulnerabilityTimer = invulnerabilityTime;

        ScoreManager.Instance.ApplyPenalty(scorePenalty);

        currentHitFeedbackOpacity = hitFeedbackOpacity;

        if (health <= 0)
        {
            Kill();
        }
        else
        {
            shrink.Play();
        }
    }

    public void AddBubble(int value)
    {
        health = Mathf.Min(health + value, maxHealth);
        grow.Play();
    }


    public void Win()
    {
        Debug.Log("You win !");
        Time.timeScale = 0.0f;
        winScreen.SetActive(true);
        music.Stop();
    }
}
