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
}
