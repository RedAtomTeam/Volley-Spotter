using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _force;    
    private Rigidbody2D _rb;

    public event Action catchBallEvent;

    [SerializeField] private AudioClip _hitClip;
    private AudioService _audioService;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_audioService == null)
            _audioService = AudioService.Instance;
        _audioService.PlayEffect(_hitClip);

        _rb.velocity = Vector3.zero;

        Vector2 dirrection = new Vector2(gameObject.transform.position.x - eventData.position.x, 1 * _force);

        _rb.AddForce(dirrection, ForceMode2D.Impulse);
        catchBallEvent?.Invoke();
    }
}
