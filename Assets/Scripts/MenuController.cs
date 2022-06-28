using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] [Tooltip("Кнопка начала новой игры")] private GameObject buttonPlay;
    [SerializeField] [Tooltip("Панель рестарта игры после проигрыша")] private GameObject panelLost;
    [SerializeField] [Tooltip("Панель начала следующего уровня игры после выигрыша")] private GameObject panelWin;
    private SpawnManager spawnManager;
    private Vector3 CameraInitPos = new Vector3(0.9f, 19.1f, -14.1f);
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        buttonPlay.SetActive(true);
    }

    public void buttonPlayClick()
    {
        buttonPlay.SetActive(false);
        spawnManager.StartGame();
    }

    public void buttonRestartLevelClick()
    {
        panelLost.SetActive(false);
        RestartLevel();
    }

    public void buttonNextLevelClick()
    {
        panelWin.SetActive(false);
        NextLevel();
    }

    public void ShowPanelWin()
    {
        DestroySpawnedObjects();
        panelWin.SetActive(true);
    }

    public void ShowButtonPlay()
    {
        buttonPlay.SetActive(true);
    }

    public void ShowPanelLost()
    {
        DestroySpawnedObjects();
        SetCameraInitPos();
        panelLost.SetActive(true);
    }

    private void RestartLevel()
    {
        
    }
    
    private void NextLevel()
    {
        
    }
    
    public void KillEnemy()
    {
        spawnManager.EnemiesToDestroy--;
        if (spawnManager.EnemiesToDestroy == 0)  ShowPanelWin();
    }
    
    private void DestroySpawnedObjects()
    {
        Debug.Log("DestroySpawnedObjects()"); // Отладка
        spawnManager.StopSpawnEnemies();
        foreach (Transform child in spawnManager.transform) Destroy(child.gameObject);
    }

    private void SetCameraInitPos()
    {
        cinemachineVirtualCamera.transform.position = CameraInitPos;
    } 
}
