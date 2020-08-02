﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parent;

    //Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }
 
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable == true)
            {
                    var towerSpawn = Instantiate(towerPrefab, transform.position, Quaternion.identity);
                    towerSpawn.transform.parent = parent;
                    isPlaceable = false;
            }
            else
            {
                print("Can't place here");
            }
        }
    }

}
