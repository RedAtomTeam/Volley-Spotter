using TMPro;
using UnityEngine;

public class SetRecord : MonoBehaviour
{

    [SerializeField] private string _additiveText;
    [SerializeField] private string _playerPrefsName;

    [SerializeField] private TextMeshProUGUI _text;


    private void OnEnable()
    {
        _text.text = _additiveText + PlayerPrefs.GetInt(_playerPrefsName, 0);
    }

}
