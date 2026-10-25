using UnityEngine;
using UnityEngine.UI;

public class Mau : MonoBehaviour
{
    public Sprite[] Heartsprite; // mảng trạng thái ảnh ứng với số mạng
    public VaCham player;
    public Image Heart;

    int lastHealth = -1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<VaCham>();
    }

    void Update()
    {
        // Chỉ đổi sprite khi máu thay đổi
        if (player.heath == lastHealth) return;
        lastHealth = player.heath;
        Heart.sprite = Heartsprite[Mathf.Clamp(lastHealth, 0, Heartsprite.Length - 1)];
    }
}
