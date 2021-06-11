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
        MovePlayer();
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
        MoveGrabbedObject();
    }
    private void EnterNotGrabbingRoute()
    {
        if (IsWalking())
        {
            if (CheckWalkingAgainstObject() == false)
            {
                playerRef.SetNormalSpeed();
                ApplyWindModifiers();
                WalkInDirection();
            }
            if(AreInParallelDirections(moveDirection,GetWindDirection()) == false)
            {
                MovedByWind();
            }
        }
        else
        {
            MovedByWind();
        }
    }
    private void MovedByWind()
    {
        if(GetWindDirection() != Directions.Nulo)
        {
            playerRef.SetMinSpeed();
            playerRef.MovePlayer(GetWindDirection());
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
    private Directions GetWindDirection()
    {
        return playerRef.GetWindReference().GetWindDirection();
    }
    private void ApplyWindModifiers()
    {
       if(GetWindDirection() != Directions.Nulo)
        {
            if (GetWindDirection() == moveDirection)
            {
                playerRef.SetMaxSpeed();
            }
            else if (AreInParallelDirections(moveDirection, GetWindDirection()))
            {
                playerRef.SetMinSpeed();
            }
        }
    }
    private bool AreInParallelDirections(Directions pDir1, Directions pDir2)
    {
        bool areParallel = false;
        if(pDir1==Directions.South || pDir1 == Directions.North)
        {
            if(pDir2 == Directions.South || pDir2 == Directions.North)
            {
                areParallel = true;
            }
        }
        else
        {
            if (pDir2 == Directions.East || pDir2 == Directions.West)
            {
                areParallel = true;
            }
        }
        return areParallel;
    }
    private bool IsWalking()
    {
        return (moveDirection != Directions.Nulo);
    }
    private void MoveGrabbedObject()
    {
        playerRef.GetGrabbedObject().SetSpeed(playerRef.GetObjSpeed());
        playerRef.GetGrabbedObject().MoveToDirection(moveDirection);
    }
}
