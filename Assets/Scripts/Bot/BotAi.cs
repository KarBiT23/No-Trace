using UnityEngine;

public class BotHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public bool isDead { get; private set; }
    public float despawnTime = 8f; // �l�nce ka� saniye sonra yok olacak

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

        // E�er animasyon varsa �lme animasyonu
        if (anim != null)
        {
            anim.SetTrigger("Die");
        }
        else
        {
            // Animasyon yoksa fizik ile yere d���r
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }
        }

        // AI hareketini kapat
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null) agent.enabled = false;

        Debug.Log(name + " �ld� ve Dead tag'i ald�!");

        // Yok olma zamanlay�c�s�
        Invoke(nameof(Despawn), despawnTime);
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
