using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private float _forceValue;
    [SerializeField] private AudioClip _hitClip;

    private Collider2D? _ball;
    private AudioService _audioService;


    public void Exploze()
    {
        if (_ball != null)
        {
            if (_audioService == null)
                _audioService = AudioService.Instance;

            _audioService.PlayEffect(_hitClip);

            Vector2 dirrection = _ball.transform.position - gameObject.transform.position;
            dirrection = dirrection.normalized;
            dirrection.y = dirrection.y * dirrection.y;
            _ball.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);

            _ball.GetComponent<Rigidbody2D>().AddForce(dirrection * _forceValue, ForceMode2D.Impulse);
            _score.AddScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _ball = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _ball = null;
    }
}
