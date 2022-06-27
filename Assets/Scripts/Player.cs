using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float powerUpStrength = 15.0f;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private FixedJoystick joystick;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<FixedJoystick>();
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
            Debug.Log("Game over!!!");
        }
    }
}
