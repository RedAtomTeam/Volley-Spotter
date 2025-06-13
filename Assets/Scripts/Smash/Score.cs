using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private BottomTrigger _bottomTrigger;
    [SerializeField] private GameObject _playCanvas;
    [SerializeField] private GameObject _endCanvas;

    private int _scorePoints = 0;

    [SerializeField] private List<TextMeshProUGUI> _texts = new List<TextMeshProUGUI>();
    [SerializeField] private TextMeshProUGUI _maxScoreText;

    private void Start()
    {
        _bottomTrigger.triggerEvent += () => { _playCanvas.SetActive(false); };
        _bottomTrigger.triggerEvent += () => { _endCanvas.SetActive(true); };

        for (int i = 0; i < _texts.Count; i++)
        {
            _texts[i].text = "SCORE:" + _scorePoints;
        }
        _maxScoreText.text = "BEST:" + PlayerPrefs.GetInt("Max Score", _scorePoints);
    }

    public int ScorePoints
    {
        get { return _scorePoints; }
    }

    public void AddScore()
    {
        _scorePoints++;

        for (int i = 0; i < _texts.Count; i++)
        {
            _texts[i].text = "SCORE:" + _scorePoints;
        }

        PlayerPrefs.SetInt("Max Score", _scorePoints > PlayerPrefs.GetInt("Max Score", _scorePoints) ? _scorePoints : PlayerPrefs.GetInt("Max Score", _scorePoints));
        _maxScoreText.text = "BEST:" + PlayerPrefs.GetInt("Max Score", _scorePoints);
    }

}
