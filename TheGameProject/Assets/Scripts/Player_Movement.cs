using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float movementSpeed = 5f; //speed of the player
    [SerializeField] private Rigidbody2D rb; //the rigidbody of the player
    [SerializeField] private Animator animator;
    private float mousePos;

    [SerializeField] private float hand;
    [SerializeField] private float angleMax;
    [SerializeField] private float angleMin;

    Vector2 movement; //going to be moving the player

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        flipSprite(mousePos);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void flipSprite(float x) //Flipping the Player
    {
        if (x == 0)
        {
            x = 0;
        }
        else if (x > 0)
        {
            x = x + rb.position.x;
        }
        else
        {
            x = x - rb.position.x;
        }
        transform.localScale = new Vector3(Mathf.Sign(x), 1, 1);
    }
}
