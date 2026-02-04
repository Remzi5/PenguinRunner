using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText; // Məsafə yazısı
    public TextMeshProUGUI coinText;  // Balıq yazısı

    private int coinCount = 0; // Toplanan balıq sayı

    void Update()
    {
        // Yalnız oyun davam edərkən xalı artır
        if (Time.timeScale > 0)
        {
            // Məsafəni hesabla (Z oxu)
            int distance = (int)player.position.z;
            scoreText.text = "Score: " + distance;
        }
    }

    // Balıq toplayanda bu funksiya çağırılır
    public void AddCoin(int amount)
    {
        coinCount += amount;
        coinText.text = "Fish: " + coinCount;
    }
}