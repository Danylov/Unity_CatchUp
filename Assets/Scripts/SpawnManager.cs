using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Префабы")] 
    [SerializeField] [Tooltip("Префаб игрока")] private GameObject playerPrefab;
    [SerializeField] [Tooltip("Префаб противника")] private GameObject enemyPrefab;
    [SerializeField] [Tooltip("Префаб ловушки")] private GameObject catcherPrefab;
    [Header("Другие настройки")] 
    [SerializeField] [Tooltip("Количество противников")] private int enemiesToSpawn = 5;
    [SerializeField] [Tooltip("Промежуток времени последовательного спавна противников")] private float deltaTimeEnemySpawn = 10f;
    private IEnumerator coroutineSpawnEnemies;
    private float spawnRange = 8.0f;
    private int enemiesToDestroy;

    public int EnemiesToDestroy
    {
        get => enemiesToDestroy;
        set => enemiesToDestroy = value;
    }

    public void StartGame()
    {
        Debug.Log("StartGame()"); // Отладка
        SpawnPlayer();
        SpawnCatcher();
        coroutineSpawnEnemies = SpawnEnemies();
        StartCoroutine(coroutineSpawnEnemies);
        EnemiesToDestroy = enemiesToSpawn;
    }
    
    private void SpawnPlayer()
    {
        GameObject player =Instantiate(playerPrefab, GenerateSpawnPosition(), playerPrefab.transform.rotation);
        player.transform.SetParent(transform);
    }
    
    private void SpawnCatcher()
    {
        GameObject catcher = Instantiate(catcherPrefab, GenerateSpawnPosition(), catcherPrefab.transform.rotation);
        catcher.transform.SetParent(transform);
    }
    
    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Debug.Log("SpawnEnemies()"); // Отладка
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

    public void StopSpawnEnemies()
    {
        Debug.Log("StopSpawnEnemies()"); // Отладка
        StopCoroutine(coroutineSpawnEnemies);
    }
}