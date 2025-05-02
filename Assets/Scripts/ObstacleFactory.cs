using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FenceFactory : ObstacleFactory
{
    [SerializeField] private Fence fencePrefab;
    public override Obstacle SpawnObstacle(Vector3 position)
    {
        return Instantiate(fencePrefab, position, Quaternion.identity);
    }
}


