using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private Player player;
    [Header("Настройки противника")] 
    [SerializeField] [Tooltip("Скорость противника")] private float enemySpeed = 3.0f;
    
    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Vector3  lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed);
    }
}
