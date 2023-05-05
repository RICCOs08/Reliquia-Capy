using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerForLoadScene : MonoBehaviour
{
    [SerializeField] private GameObject _textGo;
    [SerializeField] private int _indexScene;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " in Trigger...");
        _textGo.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" & Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(_indexScene);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _textGo.SetActive(false);
    }
}
