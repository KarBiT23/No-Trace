using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public bool isDead { get; private set; }
    public float despawnTime = 8f;

    private int currentHealth;
    private Rigidbody rb;
    private Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
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

        // Rigidbody ile fizik etkileþimi açýlabilir (isteðe göre)
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        // Despawn süresi sonra objeyi yok et
        Invoke(nameof(Despawn), despawnTime);
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
