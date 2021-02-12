using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public int characterHealth = 10;
    private bool isDead = false;

    private Animator animator;
    private int moveParamID;
    private int turnLeftParamID;
    private int turnRightParamID;
    private int shootParamID;
    private int dieParamID;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        moveParamID = Animator.StringToHash("isMoving");
        turnLeftParamID = Animator.StringToHash("isRotatingLeft");
        turnRightParamID = Animator.StringToHash("isRotatingRight");
        shootParamID = Animator.StringToHash("doShoot");
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = false;
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
}
