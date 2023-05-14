using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForInfo : MonoBehaviour
{
    [SerializeField] private GameObject _InfoPanel;
    public GameObject _Info;
    private bool _isInTrigg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _InfoPanel.SetActive(true);
            _isInTrigg = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _InfoPanel.SetActive(false);
            _isInTrigg = false;
        }
    }

    private void Update()
    {
        if(_isInTrigg == true && Input.GetKeyUp(KeyCode.V))
        {
            _Info.SetActive(true);
            _InfoPanel.SetActive(false);
        }
    }
}
