using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDebuffFactory : ObstacleFactory
{
    [SerializeField] private Fence speedDebuffPrefab;
    public override Obstacle SpawnObstacle(Vector3 position)
    {
        return Instantiate(speedDebuffPrefab, position, Quaternion.identity);
    }
}
