using UnityEngine;

public class trudenTat : MonoBehaviour
{
    static readonly int ToedenHash = Animator.StringToHash("toeden");
    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.CompareTag("player")) ani.SetBool(ToedenHash, true);
    }
}
