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
    
    private void MovePlayer()
    {
        if(CheckIfgrabbing())
        {
            EnterGrabbingRoute();
        }
        else
        {
            EnterNotGrabbingRoute();
        }
    }
    private bool CheckIfgrabbing()
    {
        return playerRef.GetIsGrabbing();
    }
    private void EnterGrabbingRoute()
    {
        playerRef.SetMinSpeed();
        WalkInDirection();
    }
    private void EnterNotGrabbingRoute()
    {
        if(CheckWalkingAgainstObject())
        {
            MovedByWind();
        }
        else
        {
            playerRef.SetNormalSpeed();
            WalkInDirection();
            MovedByWind();
        }
    }
    private void MovedByWind()
    {
        if(playerRef.GetWindReference().GetWindDirection() != Directions.Nulo)
        {
            playerRef.SetMinSpeed();
            playerRef.MovePlayer(playerRef.GetWindReference().GetWindDirection());
        }
    }
    private void WalkInDirection()
    {
        playerRef.MovePlayer(moveDirection);
    }
    private bool CheckWalkingAgainstObject()
    {
        bool isWalkingAgainstObject = false;
        if(playerRef.GetCollidingObjInDirection(moveDirection) != null)
        {
            isWalkingAgainstObject = true;
        }
        return isWalkingAgainstObject;
    }
}
