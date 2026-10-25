using UnityEngine;

public class pauseG : MonoBehaviour
{
    private bool isPaused = false;
    private audio music;

    private void Awake()
    {
        music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();
    }

    void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím P
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused) ResumeGame();
            else PauseTheGame();
        }
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
}
