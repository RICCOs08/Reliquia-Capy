using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerForLoadScene : MonoBehaviour
{
    [SerializeField] private GameObject _textGo;
    [SerializeField] private int _indexScene;
    private bool _isActiveTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(other.name + " in Trigger...");
            _textGo.SetActive(true);
            _isActiveTrigger = true;
        }
            
    }

    private void Update()
    {
        if (_isActiveTrigger && Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(_indexScene);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _textGo.SetActive(false);
            _isActiveTrigger = false;   
        }
    }
}
