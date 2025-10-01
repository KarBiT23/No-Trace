using UnityEngine;
using TMPro; // TextMeshPro kullanmak için gerekli

public class CHealth : MonoBehaviour
{
    public float Playerhealth = 100f;
    public float maxHealth = 100f;
    private Animator playeranimator;

    // TextMeshPro referansý
    public TextMeshProUGUI healthText;
    

    void Start()
    {
        playeranimator = GetComponent<Animator>();
        // Baþlangýçta caný göster
        UpdateHealthUI();
    }

    public void hesaplananHealth(float hesaplananhealth)
    {
        Playerhealth -= hesaplananhealth;
        Playerhealth = Mathf.Clamp(Playerhealth, 0, maxHealth); // 0 ile max arasýnda tut

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

    // UI güncelleme metodu
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + Playerhealth.ToString("F0");
        }
    }
}
