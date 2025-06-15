using TMPro;
using UnityEngine;

public class EndWindow : MonoBehaviour
{
    [SerializeField] private QuizQuiestionsChanger _quizQuiestionsChanger;

    [SerializeField] private GameObject endWindow;
    [SerializeField] private GameObject playWindow;

    [SerializeField] private TextMeshProUGUI pointsText;


    private void Awake()
    {
        _quizQuiestionsChanger.endEvent += EndGame;
    }

    public void EndGame(int points, int maxPoints)
    {
        playWindow.SetActive(false);
        endWindow.SetActive(true);

        pointsText.text = $"{points}/{maxPoints}";
    }
}
