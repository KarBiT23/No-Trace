using UnityEngine;
using TMPro;  // TextMeshPro için

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public bool isDead { get; private set; }

    private int currentHealth;
    private Animator anim;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();

        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        gameObject.tag = "Dead";

        if (anim != null)
        {
            anim.SetTrigger("Die");
        }
        Destroy(gameObject, 5f);
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"Health: {currentHealth} / {maxHealth}";
        }
    }
}
