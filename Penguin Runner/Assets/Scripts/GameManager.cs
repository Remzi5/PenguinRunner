using UnityEngine;
using UnityEngine.SceneManagement; // Səhnəni dəyişmək üçün lazımdır

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void EndGame()
    {
        Debug.Log("GAME OVER!"); // Konsolda bu yazını görməlisən
        gameOverPanel.SetActive(true); // Paneli göstər
        Time.timeScale = 0f; // Oyunu dondur

    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Zamanı bərpa et
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Səhnəni yenidən yüklə
    }
}