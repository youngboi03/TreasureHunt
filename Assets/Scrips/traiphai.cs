using UnityEngine;

public class traiphai : MonoBehaviour
{
    public float start, end;
    public float speed = 1f; // Điều chỉnh tốc độ di chuyển
    private bool movingRight = true; // Cờ để xác định hướng di chuyển
    private Rigidbody2D rb; // Thành phần vật lý Rigidbody
    private bool isPlayerOnTop = false; // Cờ để xác định người chơi có đứng bên trên không
    private GameObject player; // Tham chiếu đến người chơi

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        if (isPlayerOnTop)
        {
            // Người chơi đứng bên trên: di chuyển theo input của người chơi
            float moveSpeed = speed * Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            // Di chuyển người chơi theo đối tượng
            player.transform.Translate(new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime);
        }
        else
        {
            // Di chuyển qua lại giữa start và end
            float newPosition = transform.position.x + (speed * (movingRight ? 1 : -1) * Time.deltaTime);

            if (newPosition >= end)
            {
                newPosition = end;
                movingRight = false;
            }
            else if (newPosition <= start)
            {
                newPosition = start;
                movingRight = true;
            }

            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("player")) return;

        // Kiểm tra va chạm từ phía trên (GetContact không cấp phát mảng như collision.contacts)
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (collision.GetContact(i).normal.y > 0.8f)
            {
                isPlayerOnTop = true;
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Khi rời va chạm Unity không còn contact point, nên chỉ cần kiểm tra tag
        if (collision.gameObject.CompareTag("player"))
        {
            isPlayerOnTop = false;
        }
    }
}
