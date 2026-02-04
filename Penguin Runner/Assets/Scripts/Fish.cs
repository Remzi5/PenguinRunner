using UnityEngine;

public class Fish : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log yazırıq ki, konsolda nə baş verdiyini görək
        Debug.Log("Bir obyekt balığa dəydi: " + other.name);

        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ScoreManager>().AddCoin(1);
            Destroy(gameObject);
        }
    }
}