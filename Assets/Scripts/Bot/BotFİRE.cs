using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    public Transform target;
    public float attackRange = 2f; // vurma mesafesi
    public float attackDamage = 10f;
    public float attackCooldown = 1.5f;

    private float lastAttackTime;
    private Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Hedefe dön
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPos);

        float mesafe = Vector3.Distance(transform.position, target.position);

        if (mesafe < attackRange)
        {
            if (Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            // saldırı dışında idle/koşma animasyonu
            enemyAnimator.SetBool("combotmode", false);
        }
    }

    void Attack()
    {
        enemyAnimator.SetTrigger("Attack");

        CHealth playerHealth = target.GetComponentInChildren<CHealth>();
        if (playerHealth != null)
        {
            playerHealth.hesaplananHealth(attackDamage);
            Debug.Log("Bot vurdu, Player canı: " + playerHealth.Playerhealth);
        }
        else
        {
            Debug.LogError("Target üzerinde CHealth bulunamadı!");
        }
    }

}