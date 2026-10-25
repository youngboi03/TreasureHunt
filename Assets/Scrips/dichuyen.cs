using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dichuyen : MonoBehaviour
{
    static readonly int ChayHash = Animator.StringToHash("chay");
    static readonly int BanHash = Animator.StringToHash("ban");

    private Animator ani;
    public float jump = 7f;
    private Rigidbody2D body;
    private audio music;
    public Vector3 offset; // Khai báo biến offset
    public Image back;
    public Image gameover;
    private bool isPaused = false;

    SpriteRenderer sprite;
    public float direction = 6f;
    bool checkGround = false;
    private bool isBanAnimationPlaying = false;
    public float speed = 8f;

    private void Awake()
    {
        music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        offset = new Vector3(0f, 1f, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused) ResumeGame();
            else PauseTheGame();
        }
        // Đang pause thì không nhận input di chuyển/bắn
        if (isPaused) return;

        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(h, 0f) * speed * Time.deltaTime);
        if (h < 0f)
        {
            sprite.flipX = true;
            direction = -1f;
        }
        else if (h > 0f)
        {
            sprite.flipX = false;
            direction = 1f;
        }

        if (Input.GetKey(KeyCode.Space) && checkGround)
        {
            body.velocity = new Vector2(body.velocity.x, jump);
            checkGround = false;
        }

        // Kiểm tra nếu animation "ban" không đang phát và người chơi nhấn phím H
        if (Input.GetKeyDown(KeyCode.H) && !isBanAnimationPlaying)
        {
            StartCoroutine(PlayBanAnimation());
        }

        ani.SetBool(ChayHash, h != 0);
    }

    void PauseTheGame()
    {
        Time.timeScale = 0; // Dừng thời gian trong game
        isPaused = true;
        music.StopG();
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Tiếp tục thời gian trong game
        isPaused = false;
        music.Nhacnen();
    }

    IEnumerator PlayBanAnimation()
    {
        // Phát animation "ban"
        ani.SetBool(BanHash, true);
        isBanAnimationPlaying = true;

        // Đợi cho đến khi animation "ban" kết thúc
        yield return new WaitForSeconds(ani.GetCurrentAnimatorStateInfo(0).length);

        ani.SetBool(BanHash, false);
        isBanAnimationPlaying = false;
        music.PlaySfnhac(music.nhacbancung);
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("ground"))
        {
            checkGround = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("back") || other.CompareTag("back1"))
        {
            back.gameObject.SetActive(true);
            music.PlaySfnhac(music.backG);
            music.StopG();
        }
        else if (other.CompareTag("backmenu"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        else if (other.CompareTag("wall"))
        {
            gameover.gameObject.SetActive(true);
            music.PlaySfnhac(music.nhacOver);
            music.StopG();
        }
    }
}
