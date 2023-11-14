using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventCollider : MonoBehaviour
{
    public UnityEvent onObstacleDodged; // UnityEvent to be triggered

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TiggerEvent();
        }
    }

    private void TiggerEvent()
    {
        // Invoke the UnityEvent
        if (onObstacleDodged != null)
        {
            onObstacleDodged.Invoke();
        }
    }
}
