
using UnityEngine;

public class ForwardChecker : MonoBehaviour
{
    private Villager1Walking villager;

    private void Start()
    {
        villager = GetComponentInParent<Villager1Walking>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Villager 1"))
        {
            villager.Flip();
        }
    }
}
