using UnityEngine;
using UnityEngine.UI;

public class VaCham : MonoBehaviour
{
    public int heath = 5;
    public Image anhOver;
    public Image anhWin;
    private audio music;
    private bool isEnded = false;

    private void Awake()
    {
        music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();
    }

    void Start()
    {
        Time.timeScale = 1;
        anhOver.gameObject.SetActive(false);
        anhWin.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Đã thắng/thua thì bỏ qua va chạm tiếp theo
        if (isEnded) return;

        if (other.CompareTag("thuhoang") || other.CompareTag("nuoc"))
        {
            heath = Mathf.Max(heath - 1, 0);
            music.PlaySfnhac(music.nhactrudiem);
        }

        if (heath <= 0)
        {
            EndGame(anhOver, music.nhacOver);
        }
        else if (other.CompareTag("win"))
        {
            EndGame(anhWin, music.nhacWin);
        }
    }

    void EndGame(Image screen, AudioClip clip)
    {
        isEnded = true;
        Time.timeScale = 0;
        screen.gameObject.SetActive(true);
        music.StopG();
        music.PlaySfnhac(clip);
    }
}
