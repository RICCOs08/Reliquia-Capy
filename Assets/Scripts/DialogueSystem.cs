using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private GameObject _DialoguePanel;
    [SerializeField] private GameObject _StartDialogue;
    private string[] _lines;
    public float speed;
    public Text dialogueText;

    public int index;
    private TriggForDialogue _trigg;
    private bool _isStartedDialogue;

    private Coroutine _typeLineCoroutine;
    void Start()
    {
        dialogueText.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && _trigg._isDialogueActive == true && _isStartedDialogue == true)
        {
            SkipText();
        }
    }

    public void StartDialogue(TriggForDialogue trigger, string[] lines)
    {
        if(_isStartedDialogue == false)
        {
            _trigg = trigger;
            _lines = lines;
            index = 0;
            StartCoroutine(StartDialogueCoroutine());
        }
    }
    private IEnumerator StartDialogueCoroutine()
    {
        yield return new WaitForEndOfFrame();   
        NextLine();
        _isStartedDialogue = true;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in _lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    public void SkipText()
    {
        if (dialogueText.text == _lines[index - 1])
        {
            NextLine();
        }
        else
        {
            StopCoroutine(_typeLineCoroutine);
            dialogueText.text = _lines[index];
        }
    }

    public void NextLine()
    {
        if (index <= _lines.Length - 1)
        {
            dialogueText.text = string.Empty;
            _typeLineCoroutine = StartCoroutine(TypeLine());
            index++;
        }
        else
        {
            _DialoguePanel.SetActive(false);
            _isStartedDialogue = false;
            _trigg = null;
        }
    }

}
