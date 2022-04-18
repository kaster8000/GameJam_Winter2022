using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool CanMove;
    public float MoveSpeed;
    Rigidbody2D Rb;


    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {


        if (CanMove != false)
        {
            float MoveInputX = Input.GetAxis("Horizontal");
            float MoveInputY = Input.GetAxis("Vertical");


            Vector3 PlayerMove = new Vector3(MoveInputX, MoveInputY, 0);
            Rb.velocity = new Vector3(PlayerMove.x, PlayerMove.y, 0) * MoveSpeed;
            
        }
        else
        {
            Rb.velocity = new Vector3(0, 0, 0);
            
        }






    }
}
