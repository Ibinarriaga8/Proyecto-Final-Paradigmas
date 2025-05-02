using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarFactory : ObstacleFactory
{
    [SerializeField] private PoliceCar policeCarPrefab;

    public static PoliceCarFactory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public  override Obstacle SpawnObstacle(Vector3 position)
    {
        return Instantiate(policeCarPrefab, position, Quaternion.identity);
    }
}
