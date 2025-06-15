using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuizQuiestionsChanger : MonoBehaviour
{
    [SerializeField] private List<QuizQuestion> _questions;
    [SerializeField] private int _questionIndex = 0;

    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private GameObject _questionsBlock;
    [SerializeField] private List<AnswerButton> _questionAnswerButtons;

    [SerializeField] private Button _nextButton;

    private int _points = 0;

    public event Action<int, int> endEvent;


    private void Start()
    {
        SetCurrentQuestion();
        _nextButton.gameObject.SetActive(false);
        _nextButton.onClick.AddListener(Next);
    }

    private void SetCurrentQuestion()
    {
        _questionText.text = _questions[_questionIndex].Text;
        LoadAnswers(_questions[_questionIndex].Answers);
    }

    private void LoadAnswers(List<QuizAnswer> answers)
    {
        for (int i = 0; i < answers.Count; i++)
            _questionAnswerButtons[i].SetButtonState(answers[i]);
    }

    public bool CheckAnswer(QuizAnswer answer)
    {
        bool res = false;

        print($"Answer: {answer.Text}; True Answer: {_questions[_questionIndex].TrueAnswer.Text};");
        if (answer == _questions[_questionIndex].TrueAnswer)
        {
            _points++;
            res = true;
        }

        _questionIndex++;
        _nextButton.gameObject.SetActive(true);
        
        return res;
    }

    private void Next()
    {
        if (_questionIndex >= _questions.Count)
            endEvent?.Invoke(_points, _questions.Count);
        else
        {
            SetCurrentQuestion();
            _nextButton.gameObject.SetActive(false);
        }
    }

}
