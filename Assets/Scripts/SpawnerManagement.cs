using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManagement : MonoBehaviour
{
    #region Exposed

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _spawnRadius = 7;

    #endregion

    #region Unity Lifecycle

    void Start()
    {
        StartCoroutine(SpawnEnemy(_spawnInterval, _enemyPrefab));
    }

    void Update()
    {

    }

    #endregion

    #region Methods

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Vector2 spawnPos = gameObject.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * _spawnRadius;
        GameObject newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }

    #endregion

    #region Private & Protected



    #endregion

}
