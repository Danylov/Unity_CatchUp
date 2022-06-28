using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] [Tooltip("Панель начала новой игры")] private GameObject panelPlay;
    [SerializeField] [Tooltip("Панель рестарта игры после проигрыша")] private GameObject panelLost;
    [SerializeField] [Tooltip("Панель начала следующего уровня игры после выигрыша")] private GameObject panelWin;
    private SpawnManager spawnManager;
    private Vector3 CameraInitPos = new Vector3(0.9f, 19.1f, -14.1f);
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Start()
    {
        Debug.Log("MenuController.Start()"); // Отладка
        spawnManager = FindObjectOfType<SpawnManager>();
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        panelPlay.SetActive(true);
    }

    public void buttonPlayClick()
    {
        panelPlay.SetActive(false);
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
        panelPlay.SetActive(true);
    }

    public void ShowPanelLost()
    {
        DestroySpawnedObjects();
        SetCameraInitPos();
        panelLost.SetActive(true);
    }

    private void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    
    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) nextSceneIndex = 0;
        var numLevel = nextSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    public void KillEnemy()
    {
        spawnManager.EnemiesToDestroy--;
        if (spawnManager.EnemiesToDestroy == 0)  ShowPanelWin();
    }
    
    private void DestroySpawnedObjects()
    {
        spawnManager.StopSpawnEnemies();
        foreach (Transform child in spawnManager.transform) Destroy(child.gameObject);
    }

    private void SetCameraInitPos()
    {
        cinemachineVirtualCamera.transform.position = CameraInitPos;
    } 
}