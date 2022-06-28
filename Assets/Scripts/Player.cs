using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private FixedJoystick joystick;
    private MenuController menuController;
    [Header("Настройки игрока")] 
    [SerializeField] [Tooltip("Скорость игрока")] private float playerSpeed = 5.0f;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<FixedJoystick>();
        menuController = FindObjectOfType<MenuController>();
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = transform;
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector3(joystick.Horizontal * playerSpeed, playerRb.velocity.y,
            joystick.Vertical * playerSpeed);
    }
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            menuController.ShowPanelLost();
        }
    }
}
