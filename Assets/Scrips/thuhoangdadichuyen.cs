using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thuhoangdadichuyen : MonoBehaviour
{


    public float start;
    public float end;
    public float speed = 1f; // Tốc độ di chuyển của vật thể
    private bool movingRight = true; // Cờ để xác định hướng di chuyển
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Tính toán vị trí mới dựa trên vị trí hiện tại, tốc độ và thời gian
        float newPosition = transform.position.x + (speed * (movingRight ? 1 : -1) * Time.deltaTime);

        // Kiểm tra xem đối tượng đã đạt đến các điểm cuối chưa
        if (newPosition >= end)
        {
            newPosition = end;
            movingRight = false;
            spriteRenderer.flipX = true; // Lật ngược hình ảnh khi di chuyển ngược lại
        }
        else if (newPosition <= start)
        {
            newPosition = start;
            movingRight = true;
            spriteRenderer.flipX = false; // Lật ngược hình ảnh khi di chuyển ngược lại
        }

        // Cập nhật vị trí mới cho đối tượng
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}
