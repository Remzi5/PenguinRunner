using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Bərk cisimlərə dəyəndə (Maneə)
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Maneəyə dəydim!");
            TriggerEndGame();
        }
    }

    // Əgər maneə səhvən Trigger edilibsə
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Maneəyə dəydim (Trigger olaraq)!");
            TriggerEndGame();
        }
    }

    void TriggerEndGame()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.EndGame();
        }
    }
}