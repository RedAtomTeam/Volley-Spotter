using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeInSeconds;

    [SerializeField] private TextMeshProUGUI _timeText;

    public event Action timerEndEvent;


    private void Update()
    {
        if (_timeInSeconds > 0)
        {
            var time = TimeSpan.FromSeconds(_timeInSeconds);
            _timeText.text = string.Format("{0:D2}:{1:D2}",
                    time.Minutes,
                    time.Seconds);
            _timeInSeconds -= Time.deltaTime;
            if ( _timeInSeconds <= 0 )
                timerEndEvent?.Invoke();
        }
    }
}
