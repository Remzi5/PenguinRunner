using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f; // İrəli getmə sürəti
    public float laneSpeed = 10f;   // Sağa-sola keçid sürəti
    private int lane = 1;           // 0: Sol, 1: Orta, 2: Sağ

    void Update()
    {
        // 1. Həmişə irəli get
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // 2. Düymələri yoxla (Ox işarələri)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lane > 0) lane--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lane < 2) lane++;
        }

        // 3. Zolaqlara görə hədəf yerini müəyyən et
        Vector3 targetPosition = transform.position;
        if (lane == 0) targetPosition.x = -3f; // Sol
        else if (lane == 1) targetPosition.x = 0f; // Orta
        else if (lane == 2) targetPosition.x = 3f; // Sağ

        // 4. Həmin yerə doğru yumşaq hərəkət et
        transform.position = Vector3.Lerp(transform.position, targetPosition, laneSpeed * Time.deltaTime);
    }
}