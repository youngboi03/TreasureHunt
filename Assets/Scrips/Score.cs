using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    int currentScore = 0;

    void Start()
    {
        text = GetComponent<Text>();
        Refresh();
    }

    public void UpdateScore()
    {
        currentScore += 1;
        Refresh();
    }

    // Chỉ cập nhật UI khi điểm thay đổi thay vì mỗi frame
    void Refresh()
    {
        if (text != null) text.text = currentScore.ToString();
    }
}
