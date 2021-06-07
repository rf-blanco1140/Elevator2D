using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player playerRef;
    private Directions moveDirection;
    [SerializeField] GrabContorller grabControllerRef;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        //Move();
        playerRef.MovePlayer(moveDirection);
        /**if(!grabRef.getIsGrabbing())
        {
            //RotatePlayer(moveDirection.x, moveDirection.y);
        }*/
    }

    private void ProcessInputs()
    {
        /**float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX,moveY).normalized;*/
        moveDirection = Directions.Nulo;
        switch (Input.GetAxisRaw("Horizontal"))
        {
            case -1:
                moveDirection = Directions.West;
                break;
            case 1:
                moveDirection = Directions.East;
                break;
        }
        switch (Input.GetAxisRaw("Vertical"))
        {
            case -1:
                moveDirection = Directions.South;
                break;
            case 1:
                moveDirection = Directions.North;
                break;
        }
    }

    /**private void Move()
    {
        playerRB.MovePosition(playerRB.position + moveDirection * moveSpeed * Time.deltaTime);
        playerRB.velocity = new Vector2(moveDirection.x*moveSpeed, moveDirection.y*moveSpeed);
    }*/

    /**public void ChangeMovementSpeed(float  pSpeed)
    {
        moveSpeed = pSpeed;
    }*/

    
    /**private void RotatePlayer(float pHorizontal, float pVertical)
    {
        switch(pHorizontal)
        {
            case 1:
                playerRB.rotation = -90;
                break;
            case -1:
                playerRB.rotation = 90;
                break;
        }

        switch(pVertical)
        {
            case 1:
                playerRB.rotation = 0;
                break;
            case -1:
                playerRB.rotation = 180;
                break;
        }
        transform.rotation.s
    }*/
    
}
