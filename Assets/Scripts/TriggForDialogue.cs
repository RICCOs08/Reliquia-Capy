using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TriggForDialogue : MonoBehaviour
{

    [SerializeField] private DialogueSystem _dialogueSystem;
    private bool _isInTrigg;
    [SerializeField] private GameObject _StartDialogue;
    [SerializeField] private GameObject _DialoguePanel;
    [SerializeField] string[] _lines;
    public bool _isDialogueActive;

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
            _dialogueSystem.StartDialogue(this, _lines);
            _isDialogueActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInTrigg = false;
            _DialoguePanel.SetActive(false);
            _StartDialogue.SetActive(false);
            _isDialogueActive = false;
        }
    }
}
