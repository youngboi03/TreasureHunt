using UnityEngine;

public class BackGrDiChuyen : MonoBehaviour
{
    public Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    // LateUpdate: chạy sau khi camera đã di chuyển, tránh background bị giật
    void LateUpdate()
    {
        Vector3 p = cam.position;
        transform.position = new Vector3(p.x, p.y, 0);
    }
}
