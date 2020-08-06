using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) {
            var newEnemy = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}
