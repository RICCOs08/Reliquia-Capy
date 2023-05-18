using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController instance;
    private SpawnPoint _currentSpawnPoint;
    [SerializeField] private List<SpawnPointData> _spawnPointsData = new List<SpawnPointData>();

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
        }
        #endregion
    }
    void Start()
    {
        SetPlayerPosition();
    }

    void Update()
    {

    }

    private void SetPlayerPosition()
    {
        FirstPersonController.instance.characterController.enabled = false;
        _currentSpawnPoint = GameManager.instance.currentSpawnPoint;
        Vector3 currentSpawnPointPos = _spawnPointsData.First(x => x.spawnPoint == _currentSpawnPoint).position;
        FirstPersonController.instance.transform.position = currentSpawnPointPos;
        FirstPersonController.instance.characterController.enabled = true;
    }
}

public enum SpawnPoint
{
    Point1, Point2, Point3,
}
