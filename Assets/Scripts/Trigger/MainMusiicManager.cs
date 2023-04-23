using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusiicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private float _timeTransition = 1;
    private bool _isPlaying;
    private float _timer;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        _timer += Time.deltaTime;

        if (_isPlaying == true && _audioSource.volume != 1)
        {
            _audioSource.volume = Mathf.Lerp(0, 1, _timer / _timeTransition);
        }

        if (_isPlaying == false && _audioSource.volume != 1)
        {
            _audioSource.volume = Mathf.Lerp(1, 0, _timer / _timeTransition);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        _audioSource.clip = clip;
        _isPlaying = true;
        _timer = 0;
    }

    public void StopMusic()
    {
        _audioSource.Stop();
        _isPlaying = false;
        _timer = 0;
    }
}
