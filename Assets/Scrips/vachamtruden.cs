using UnityEngine;

public class vachamtruden : MonoBehaviour
{
    public GameObject door1; // Tham chiếu tới GameObject của cánh cửa số 1
    public GameObject door2; // Tham chiếu tới GameObject của cánh cửa số 2
    public GameObject door3; // Tham chiếu tới GameObject của cánh cửa số 3

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Va chạm với trụ đèn nào thì hủy cánh cửa tương ứng
        if (collision.CompareTag("truden1")) Destroy(door1);
        else if (collision.CompareTag("truden2")) Destroy(door2);
        else if (collision.CompareTag("truden3")) Destroy(door3);
    }
}
