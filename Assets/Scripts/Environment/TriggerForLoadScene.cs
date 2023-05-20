using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerForLoadScene : MonoBehaviour
{
    [SerializeField] private GameObject _textGo;
    [SerializeField] private int _indexScene;
    [SerializeField] private SpawnPoint _nextSpawnPoints;
    private bool _isActiveTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")                                 // проверка по тэгу
        {
            Debug.Log(other.name + " in Trigger...");              // Проверка нахождения игрока в триггере
            _textGo.SetActive(true);                               // Отображения текста
            _isActiveTrigger = true;
        }
            
    }

    private void Update()
    {
        if (_isActiveTrigger && Input.GetKeyDown(KeyCode.N))
        {
            GameManager.instance.currentSpawnPoint = _nextSpawnPoints;      // Присваивание точки спавна
            SceneManager.LoadScene(_indexScene);                            // Загрузка сцены
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
