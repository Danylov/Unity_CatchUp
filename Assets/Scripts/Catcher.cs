using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class Catcher : MonoBehaviour
{
    private MenuController menuController;

    private void Start()
    {
        menuController = FindObjectOfType<MenuController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            menuController.KillEnemy();
        }
    }
}