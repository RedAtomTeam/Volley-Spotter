using UnityEngine;

[CreateAssetMenu(fileName = "QuizAnswer", menuName = "Scriptable Objects/QuizAnswer")]
public class QuizAnswer : ScriptableObject
{
    [SerializeField] private string _text;

    public string Text
    {
        get { return _text; }
    }

}

