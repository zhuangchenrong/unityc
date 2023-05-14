using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;

    Rigidbody2D bullerRb;

    private void Awake()
    {
        bullerRb = GetComponent<Rigidbody2D>();
    }
    
    public void SetSpeed(Vector2 look_at)// Set rigidbody speed and activate collaborative timed destruction
    {
        bullerRb.velocity = look_at * speed;
        StartCoroutine(DestroyBollet(1f));
    }

    IEnumerator DestroyBollet(float time)// Scheduled Destruction Procedure
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)// Check for no player collisions and destroy them
    {
        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
