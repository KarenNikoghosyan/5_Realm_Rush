using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parent;
    List<Waypoint> towers = new List<Waypoint>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            InstanisateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private static void MoveExistingTower()
    {
        print("You have reached the limit");
    }

    private void InstanisateNewTower(Waypoint baseWaypoint)
    {
        var towerSpawn = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        towerSpawn.transform.parent = parent;
        baseWaypoint.isPlaceable = false;
        towers.Add(baseWaypoint);
    }
}
