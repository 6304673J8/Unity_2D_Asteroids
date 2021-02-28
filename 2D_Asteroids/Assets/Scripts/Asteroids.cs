using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private Rigidbody2D AsteroidRb;
    public float speed = 8;
    public GameObject[] listAsteroids;
    public int sizeListAsteroids;

    private bool isDestroyed = false;
    // Start is called before the first frame update

    void Start()
    {
        AsteroidRb = GetComponent<Rigidbody2D> ();
        AsteroidRb.drag = 0;
        AsteroidRb.angularDrag = 0;

        AsteroidRb.velocity = new Vector3(
                                Random.Range(-1f, 1f), 
                                Random.Range(-1f, 1f), 
                                0
                                ).normalized * speed;
        AsteroidRb.angularVelocity = Random.Range(-50f, 50f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDestroyed)
            return;

        if (collision.CompareTag("Bullet"))
        {
            isDestroyed = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);


            for (var i = 0; i < sizeListAsteroids; i++)
            {
                Instantiate(
                    listAsteroids[Random.Range(0, listAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                );
            }
        }
        else if (collision.CompareTag("playerShip")) {
            Destroy(collision.gameObject);
        }
    }
}
