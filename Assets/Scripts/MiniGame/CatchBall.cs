using System.Collections;
using TMPro;
using UnityEngine;

public class CatchBall : MonoBehaviour
{
    [SerializeField] private int _points;
    
    [SerializeField] private float _timeForHitText;

    [SerializeField] private string _additionText1;
    [SerializeField] private TextMeshProUGUI _textPoints;
    [SerializeField] private string _additionText2;

    [SerializeField] private BottomTrigger _bottomTrigger;

    [SerializeField] private GameObject _playWindow;
    [SerializeField] private GameObject _endWindow;
    
    [SerializeField] private Ball _ball;
    
    [SerializeField] private TextMeshProUGUI _textHit;

    [SerializeField] private Timer _timer;

    private CanvasGroup _textHitCanvasGroup;

    private float _timeForHitTextNow = 0;
    private bool _coroutineRunning = false;


    private void Awake()
    {
        _timer.timerEndEvent += (() =>
        {
            _playWindow.SetActive(false);
            _endWindow.SetActive(true);
        });
        _textHitCanvasGroup = _textHit.GetComponent<CanvasGroup>();
        _bottomTrigger.triggerEvent += (() =>
        {
            _playWindow.SetActive(false);
            _endWindow.SetActive(true);
        });

        _ball.catchBallEvent += (() => _points++);
        _ball.catchBallEvent += (() =>
        {
            _textPoints.text = _additionText1 + _points + _additionText2;
        });

        _ball.catchBallEvent += UpdateRecord;

        _ball.catchBallEvent += (() =>
        {
            if (_coroutineRunning)
                StopCoroutine("ShowHitCoroutine");
            StartCoroutine("ShowHitCoroutine");
        });
    }

    private void UpdateRecord()
    {
        PlayerPrefs.SetInt("Highscore", (_points > PlayerPrefs.GetInt("Highscore", _points) ? _points : PlayerPrefs.GetInt("Highscore", _points)));
    }


    private void ShowHit()
    {
        StartCoroutine("ShowHitCoroutine");
    }

    private IEnumerator ShowHitCoroutine()
    {
        _coroutineRunning = true;
        _timeForHitTextNow = _timeForHitText;
        _textHitCanvasGroup.alpha = 1f;

        _textHit.gameObject.SetActive(true);

        while (true)
        {
            if (_timeForHitTextNow > 0)
            {
                _timeForHitTextNow -= 0.1f;
                _textHitCanvasGroup.alpha = _timeForHitTextNow / _timeForHitText; 
                yield return new WaitForSeconds(0.1f);
            }
            else
                break;
        }

        _textHit.gameObject.SetActive(false);
        
        _coroutineRunning = false;
    }
}
