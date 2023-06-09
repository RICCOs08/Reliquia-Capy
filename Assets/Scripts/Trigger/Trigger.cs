using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private MainMusiicManager _mainMusiicManager;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _mainMusiicManager.PlayMusic(_audioClip);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _mainMusiicManager.StopMusic();
        }
    }
}
�