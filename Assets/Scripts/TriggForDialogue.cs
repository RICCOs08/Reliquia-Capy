using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TriggForDialogue : MonoBehaviour
{
    DialogueSystem dialogueSystem;
    private bool _isInTrigg;
    [SerializeField] private GameObject _StartDialogue;
    [SerializeField] private GameObject _DialoguePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInTrigg = true;
            _StartDialogue.SetActive(true);
        }
    }

    private void Update()
    {
        if (_isInTrigg && Input.GetKeyDown(KeyCode.M))
        {
            _StartDialogue.SetActive(false);
            _DialoguePanel.SetActive(true);
            dialogueSystem.StartDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInTrigg = false;
            _DialoguePanel.SetActive(false);
            _StartDialogue.SetActive(false);
        }
    }
}
