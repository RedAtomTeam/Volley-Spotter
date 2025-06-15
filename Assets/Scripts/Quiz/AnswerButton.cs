using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private QuizQuiestionsChanger _quizQuestionsChanger;
    [SerializeField] private QuizAnswer _quizAnswer;

    [SerializeField] private Sprite _defaultAnswerSprite;
    [SerializeField] private Sprite _correctAnswerSprite;
    [SerializeField] private Sprite _wrongAnswerSprite;

    private Button _button;
    private TextMeshProUGUI _text;


    public QuizAnswer QuizAnswer
    {
        get { return _quizAnswer; }
        set { _quizAnswer = value; }
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetButtonState(QuizAnswer answer)
    {
        _quizAnswer = answer;
        _button.image.sprite = _defaultAnswerSprite;
        _text.text = answer.Text;
    }

    public void SendAnswer()
    {
        if (_quizQuestionsChanger.CheckAnswer(_quizAnswer))
            _button.image.sprite = _correctAnswerSprite;
        else
            _button.image.sprite = _wrongAnswerSprite;
    }
}
