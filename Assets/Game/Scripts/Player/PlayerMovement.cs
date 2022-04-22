using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool CanMove;
    public float MoveSpeed;
    public bool facingRight = true;
    public Animator myAnim;
    Rigidbody2D Rb;


    void Start()
    {
        //CanMove = true;
        Rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {


        if (CanMove != false)
        {
            float MoveInputX = Input.GetAxis("Horizontal");
            float MoveInputY = Input.GetAxis("Vertical");

            if (Rb.velocity.x > 0 && !facingRight) Flip();
            else if (Rb.velocity.x < 0 && facingRight) Flip();

            Vector3 PlayerMove = new Vector3(MoveInputX, MoveInputY, 0);
            Rb.velocity = new Vector3(PlayerMove.x, PlayerMove.y, 0) * MoveSpeed;
            myAnim.SetFloat("moveVelocity", Rb.velocity.magnitude);
            //myAnim.SetFloat("moveVelocity", Mathf.Abs(MoveInputY));

        }
        else
        {
            Rb.velocity = new Vector3(0, 0, 0);
            myAnim.SetFloat("moveVelocity", 0);

        }
    }

    public void TogleCanMove(bool i)
    {
        CanMove = i;
    }
    void Flip()
    {
        facingRight = !facingRight;

        if (facingRight == false)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (facingRight == true)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
