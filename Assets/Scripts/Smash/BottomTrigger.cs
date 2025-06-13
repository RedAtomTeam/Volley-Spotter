using System;
using UnityEngine;

public class BottomTrigger : MonoBehaviour
{
    public event Action triggerEvent;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEvent?.Invoke();
    }
}
