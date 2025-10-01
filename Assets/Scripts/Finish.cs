using UnityEngine;
using UnityEngine.SceneManagement;
public class MissionManager : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject successPanel; // Görev baþarýlý paneli
    public GameObject failPanel;    // Görev baþarýsýz paneli

    [Header("Karakterin Saðlýðý")]
    public CHealth playerHealth; // CHealth scriptini buradan çekecek

    private bool isMissionOver = false;

    void Start()
    {
        if (successPanel != null) successPanel.SetActive(false);
        if (failPanel != null) failPanel.SetActive(false);

        if (playerHealth == null)
        {
            // Eðer inspector’dan atamazsan otomatik Player taglý objeden bulur
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
            Debug.Log("Görev Baþarýsýz!");
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
            Debug.Log("Görev Baþarýlý!");
            isMissionOver = true;
            Time.timeScale = 0f;
        }
    }
    void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu tekrar hýzlandýr
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Sahneyi yeniden yükle
    }
}
