using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    public Image anhHD;
    public Image menu;
    public Image back;
    private audio music;

    private void Awake()
    {
        // Scene Menu không có object tag "audio"
        GameObject audioObj = GameObject.FindGameObjectWithTag("audio");
        if (audioObj != null) music = audioObj.GetComponent<audio>();
    }

    void Start()
    {
        if (back != null) back.gameObject.SetActive(false);
    }

    public void chuyenHD()
    {
        anhHD.gameObject.SetActive(true);
    }

    public void backHD()
    {
        anhHD.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }

    public void playman1() { LoadScene(1); }
    public void playman2() { LoadScene(2); }
    public void playman3() { LoadScene(3); }
    public void ChoilaiMan1() { LoadScene(0); }
    public void Menu() { LoadScene(0); }

    public void bt_back()
    {
        back.gameObject.SetActive(true);
        if (music != null)
        {
            music.PlaySfnhac(music.backG);
            music.StopG();
        }
    }

    static void LoadScene(int index)
    {
        Time.timeScale = 1; // tránh scene mới bị đứng nếu đang pause/game over
        SceneManager.LoadScene(index);
    }
}
