using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SpawnPoint currentSpawnPoint;
    private void Awake()
    {
        #region Singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
