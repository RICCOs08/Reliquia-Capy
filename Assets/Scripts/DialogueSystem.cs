using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public TriggForDialogue TriggForDialogue;

    [SerializeField] private GameObject _DialoguePanel;
    [SerializeField] private GameObject _StartDialogue;
    public string[] lines;
    public float speed;
    public Text dialogueText;

    public int index;
    void Start()
    {
        dialogueText.text = string.Empty;
    }

    public void StartDialogue()
    {
        index = 0;
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    public void SkipText()
    {
        if (dialogueText.text == lines[index])
        {
             NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _DialoguePanel.SetActive(false);
        }
    }
}
