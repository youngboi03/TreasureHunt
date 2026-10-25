using UnityEngine;

public class toe : MonoBehaviour
{
    static readonly int ToeHash = Animator.StringToHash("toe");
    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.CompareTag("player")) ani.SetBool(ToeHash, true);
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.CompareTag("player")) ani.SetBool(ToeHash, false);
    }
}
