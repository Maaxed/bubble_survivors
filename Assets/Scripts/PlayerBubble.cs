using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBubble : MonoBehaviour
{
    public float baseUpwardSpeed;
    public float inputSpeed;
    public float baseScale;
    public int maxHealth;
    public float invulnerabilityTime;

    public int health = 1;
    public float invulnerabilityTimer = 0.0f;


    private Rigidbody2D rigidBody;

    public static PlayerBubble Instance { get; private set; }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        UpdateSize();

        Instance = this;
    }

    void Update()
    {
        Vector3 baseUpwardMotion = Vector3.up * baseUpwardSpeed;
        Vector3 inputVec = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f), 1.0f) * inputSpeed;
        rigidBody.linearVelocity = baseUpwardMotion + inputVec;

        if (invulnerabilityTimer > 0.0f)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }
    }

    private void UpdateSize()
    {
        transform.localScale = Vector3.one * health * baseScale;
    }


    public void Kill()
    {
        health = 0;

        Debug.Log("Dead !");
        Restartlevel();
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
        else
        {
            UpdateSize();
        }
    }

    public void AddBubble(int value)
    {
        health = Mathf.Min(health + value, maxHealth);
        UpdateSize();
    }


    public void Win()
    {
        Debug.Log("You win !");
        Restartlevel();
    }

    private void Restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
