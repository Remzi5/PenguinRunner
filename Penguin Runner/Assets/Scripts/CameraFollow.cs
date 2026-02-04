using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // İzləniləcək obyekt (Kubumuz)
    public Vector3 offset;         // Kamera ilə kub arasındakı məsafə

    void Start()
    {
        // Oyun başlayanda kamera ilə kub arasındakı mövcud məsafəni yadda saxla
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Kameranın yeni yerini hesabla (yalnız irəli və hündürlük hərəkəti üçün)
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);
        transform.position = newPosition;
    }
}