using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBubble : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject winScreen;

    public float baseUpwardSpeed;
    public float inputSpeed;
    public float baseScale;
    public int maxHealth;
    public float invulnerabilityTime;
    public float abilityCooldownTime;
    public double abilityPenalty;
    public float sizeSpeed;
    public float speedInertia;

    public int health = 1;
    [Header("Private")]
    public float invulnerabilityTimer = 0.0f;
    public float abilityCooldownTimer = 0.0f;

    public float currentSize = 1.0f;


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
        Vector2 baseUpwardMotion = Vector2.up * baseUpwardSpeed;
        Vector2 inputVec = Vector2.ClampMagnitude(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), 1.0f) * inputSpeed;
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

        if (Input.GetKeyDown(KeyCode.Space) && abilityCooldownTimer <= 0.0f)
        {
            ActivateAbility();
        }
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
        ScoreManager.Instance.ApplyPenalty(abilityPenalty);
    }


    public void Kill()
    {
        health = 0;

        Debug.Log("Dead !");
        Time.timeScale = 0.0f;
        loseScreen.SetActive(true);
    }

    public void Hit(int damage, double scorePenalty)
    {
        if (invulnerabilityTimer > 0.0f)
            return;

        health -= damage;
        invulnerabilityTimer = invulnerabilityTime;

        ScoreManager.Instance.ApplyPenalty(scorePenalty);

        if (health <= 0)
        {
            Kill();
        }
    }

    public void AddBubble(int value)
    {
        health = Mathf.Min(health + value, maxHealth);
    }


    public void Win()
    {
        Debug.Log("You win !");
        winScreen.SetActive(true);
    }
}
