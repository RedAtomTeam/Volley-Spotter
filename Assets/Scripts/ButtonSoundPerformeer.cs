using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundPerformeer : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private AudioService _audioService;


    private void Start()
    {
        if (_audioService == null)
            _audioService = AudioService.Instance;

        GetComponent<Button>().onClick.AddListener(() => _audioService.PlayEffect(_clip));
    }

}
