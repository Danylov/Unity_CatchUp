using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject catcherPrefab;
    [SerializeField] [Tooltip("Количество противников")] private int enemiesToSpawn = 5;
    [SerializeField] [Tooltip("Промежуток времени последовательного спавна противников")] private float deltaTimeEnemySpawn = 10f;
    private float spawnRange = 8.0f;
    void Start()
    {
        SpawnPlayer();
        SpawnCatcher();
        StartCoroutine(SpawnEnemies());
    }
    
    void SpawnPlayer()
    {
        GameObject player =Instantiate(playerPrefab, GenerateSpawnPosition(), playerPrefab.transform.rotation);
        player.transform.SetParent(transform);
    }
    
    void SpawnCatcher()
    {
        GameObject catcher = Instantiate(catcherPrefab, GenerateSpawnPosition(), catcherPrefab.transform.rotation);
        catcher.transform.SetParent(transform);
    }
    
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            enemy.transform.SetParent(transform);
            yield return new WaitForSeconds(deltaTimeEnemySpawn);
        } 
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return randomPos;
    }
}