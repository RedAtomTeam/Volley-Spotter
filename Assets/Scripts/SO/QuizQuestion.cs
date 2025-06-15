using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizQuestion", menuName = "Scriptable Objects/QuizQuestion")]
public class QuizQuestion : ScriptableObject
{
    [SerializeField] private string _text;
    [SerializeField] private List<QuizAnswer> _answers;
    [SerializeField] private QuizAnswer _trueAnswer;

    public string Text
    {
        get { return _text; }
    }

    public List<QuizAnswer> Answers
    {
        get { return _answers; }
    }

    public QuizAnswer TrueAnswer
    {
        get { return _trueAnswer; }
    }

}
