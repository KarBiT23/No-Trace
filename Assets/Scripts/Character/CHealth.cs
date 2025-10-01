using UnityEngine;
using TMPro; // TextMeshPro kullanmak i�in gerekli

public class CHealth : MonoBehaviour
{
    public float Playerhealth = 100f;
    public float maxHealth = 100f;
    private Animator playeranimator;

    // TextMeshPro referans�
    public TextMeshProUGUI healthText;
    

    void Start()
    {
        playeranimator = GetComponent<Animator>();
        // Ba�lang��ta can� g�ster
        UpdateHealthUI();
    }

    public void hesaplananHealth(float hesaplananhealth)
    {
        Playerhealth -= hesaplananhealth;
        Playerhealth = Mathf.Clamp(Playerhealth, 0, maxHealth); // 0 ile max aras�nda tut

        UpdateHealthUI();

        if (Playerhealth <= 0)
        {
            PlayerDead();

        }
    }

    void PlayerDead()
    {
        playeranimator.SetBool("playerDead", true);
        Destroy(gameObject, 10f);
    }

    // UI g�ncelleme metodu
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + Playerhealth.ToString("F0");
        }
    }
}
