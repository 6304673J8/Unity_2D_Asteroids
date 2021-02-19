using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private Rigidbody2D AsteroidRb;
    public float speed = 4;
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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
