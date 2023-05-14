using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListInfo : MonoBehaviour
{
    private TriggerForInfo trigg;
    [SerializeField] private GameObject _Info;

    public string[] lines;
    public float speed;
    public Text infoText;
    public int index;

    void Start()
    {
        infoText.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && _Info == true)
        {
            SkipText();
        }
    }

    public void StartDialogue()
    {
        index = 0;
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            infoText.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    public void SkipText()
    {
        if (infoText.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            infoText.text = lines[index];
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            infoText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _Info.SetActive(false);
        }
    }
}
