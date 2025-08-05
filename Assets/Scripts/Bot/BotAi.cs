using UnityEngine;

public class BotHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public bool isDead { get; private set; }
    public float despawnTime = 8f; // Ölünce kaç saniye sonra yok olacak

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

        // Eðer animasyon varsa ölme animasyonu
        if (anim != null)
        {
            anim.SetTrigger("Die");
        }
        else
        {
            // Animasyon yoksa fizik ile yere düþür
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }
        }

        // AI hareketini kapat
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null) agent.enabled = false;

        Debug.Log(name + " öldü ve Dead tag'i aldý!");

        // Yok olma zamanlayýcýsý
        Invoke(nameof(Despawn), despawnTime);
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
