using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform parent;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) {
            var enemySpawn = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            enemySpawn.transform.parent = parent;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}
