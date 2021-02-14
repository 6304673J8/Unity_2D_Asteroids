using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    
    //Movement
    public float impulse = 40;
    public float maxImpulse = 120;
    public float drag = 1;
    public float angularSpeed;
    //Bullets
    public float bulletPosition;
    public GameObject bulletPrefab;

    //Gameflow
    public int characterHealth = 10;

    private bool isDead = false;

    private Rigidbody2D shipRb;

    private float horizontal;
    private bool shooting;

    private Animator animator;
    private int moveParamID;
    private int turnLeftParamID;
    private int turnRightParamID;
    private int shootParamID;
    private int dieParamID;

    // Start is called before the first frame update
    void Start()
    {
        //Gameflow
        shipRb = gameObject.GetComponent<Rigidbody2D>();
        shipRb.drag = drag;
        transform.position = new Vector3(0.0f, -2.0f, 0.0f);

        //Animation Setup
        animator = GetComponent<Animator>();
        moveParamID = Animator.StringToHash("isMovingStraight");
        turnLeftParamID = Animator.StringToHash("isRotatingLeft");
        turnRightParamID = Animator.StringToHash("isRotatingRight");
        shootParamID = Animator.StringToHash("doShoot");
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = false;
        horizontal = InputManager.Horizontal;
        Rotate();
        //bool isRotatingLeft = false;
        //bool isRotatingRight = false;
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
        }
        animator.SetBool(moveParamID, isMoving);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(shootParamID);
        }
        if(characterHealth <= 0 && !isDead)
        {
            isDead = true;
            animator.SetTrigger(dieParamID);
        }
        /*if (Input.GetKey(KeyCode.A))
        {
            isRotatingLeft = true;
        }
        animator.SetBool(moveParamID, isRotatingLeft);
        if (Input.GetKey(KeyCode.D))
        {
            isRotatingRight = true;
        }
        animator.SetBool(moveParamID, isRotatingRight);*/
    }

    private void FixedUpdate()
    {
        //var acceleration = Mathf.Clamp(vertical, 0f, 1f);
        if (Input.GetKey(KeyCode.W))
        {
            shipRb.AddForce(transform.up * impulse, ForceMode2D.Impulse);
            if (shipRb.velocity.magnitude > maxImpulse)
            {
                shipRb.velocity = shipRb.velocity.normalized * maxImpulse;
            }
        }
    }

    private void Rotate () {
        if (horizontal == 0)
        {
            return;
        }
        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);
    }

    private void Shoot () {
        if (shooting)
        {
            var pos = transform.up * bulletPosition + transform.position;
            var bullet = Instantiate(
                    bulletPrefab, pos, transform.rotation
                );
            Destroy(bullet, 5);
        }
    }
}
