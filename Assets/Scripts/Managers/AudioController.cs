using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private AudioSource _sfxSource;

    [SerializeField] private SerializableDictionary<string, AudioClip> _sfxClips;

    [SerializeField] private SerializableDictionary<string, AudioClip> _musicClips;

    public static AudioController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AudioManager.Instance.Initialize(_musicSource, _sfxSource, _musicClips, _sfxClips);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
