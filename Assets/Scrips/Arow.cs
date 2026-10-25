using UnityEngine;

public class Arow : MonoBehaviour
{
    static Score score;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    public float force;
    private audio music;

    private void Awake()
    {
        music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();
    }

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        sprite.flipX = player.GetComponent<SpriteRenderer>().flipX;
        float direc = sprite.flipX ? -1 : 1;
        rb.velocity = new Vector2(direc * force, rb.velocity.y);
        // Hủy object sau 1s
        Destroy(gameObject, 1f);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.CompareTag("thuhoang"))
        {
            // Cache Score, tránh GameObject.Find mỗi lần bắn trúng
            if (score == null) score = GameObject.Find("text_thuhoang").GetComponent<Score>();
            score.UpdateScore(); // Điểm tăng khi va chạm

            Destroy(a.gameObject);
            DestroyGameObject();
            music.PlaySfnhac(music.nhacbanchetthuhoang);
        }
    }
}
