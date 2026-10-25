using UnityEngine;

public class donbay : MonoBehaviour
{
    public float doNay = 13.0f;
    public SpriteRenderer mauSac;

    void Start()
    {
        mauSac = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player") && collision.rigidbody != null)
        {
            // AddForce: tác động một lực lên trên; ForceMode2D.Impulse: tác động ngay tức thì
            collision.rigidbody.AddForce(Vector2.up * doNay, ForceMode2D.Impulse);
            mauSac.color = Color.red;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            mauSac.color = Color.white;
        }
    }
}
