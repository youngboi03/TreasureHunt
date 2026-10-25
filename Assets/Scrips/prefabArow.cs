using UnityEngine;

public class PrefabBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletTransform;
    public float cooldownFire = 0;
    float Timer = 0;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = bulletTransform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > cooldownFire && Input.GetKeyDown(KeyCode.H))
        {
            Timer = 0;
            InstantiateBullet();
        }
    }

    void InstantiateBullet()
    {
        // Mũi tên xuất hiện phía trước mặt nhân vật theo hướng đang quay
        Vector3 offset = new Vector3(sprite.flipX ? -1f : 1f, -0.9f, 0f);
        Instantiate(bullet, bulletTransform.transform.position + offset, Quaternion.identity);
    }
}
