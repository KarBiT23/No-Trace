using UnityEngine;
using UnityEngine.SceneManagement;
public class MissionManager : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject successPanel; // G�rev ba�ar�l� paneli
    public GameObject failPanel;    // G�rev ba�ar�s�z paneli

    [Header("Karakterin Sa�l���")]
    public CHealth playerHealth; // CHealth scriptini buradan �ekecek

    private bool isMissionOver = false;

    void Start()
    {
        if (successPanel != null) successPanel.SetActive(false);
        if (failPanel != null) failPanel.SetActive(false);

        if (playerHealth == null)
        {
            // E�er inspector�dan atamazsan otomatik Player tagl� objeden bulur
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                playerHealth = player.GetComponent<CHealth>();
        }
    }

    void Update()
    {
        if (!isMissionOver && playerHealth != null && playerHealth.Playerhealth <= 0)
        {
            if (failPanel != null) failPanel.SetActive(true);
            Debug.Log("G�rev Ba�ar�s�z!");
            isMissionOver = true;
            Time.timeScale = 0f;
        }
        if (isMissionOver && Input.GetMouseButtonDown(0))
        {
            RestartGame();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isMissionOver && other.CompareTag("Player"))
        {
            if (successPanel != null) successPanel.SetActive(true);
            Debug.Log("G�rev Ba�ar�l�!");
            isMissionOver = true;
            Time.timeScale = 0f;
        }
    }
    void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu tekrar h�zland�r
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Sahneyi yeniden y�kle
    }
}
