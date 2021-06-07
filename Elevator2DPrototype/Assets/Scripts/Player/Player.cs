using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pushable
{
    private bool isGrabbing;
    private Directions lookingDirection;

    private void Start()
    {
        currentSpeed = maxSpeed;
        isGrabbing = false;
        lookingDirection = Directions.North;
    }

    public void MovePlayer(Directions moveDirection)
    {
        MoveToDirection(moveDirection);
    }

    public void SetIsGrabbing(bool pGrabbing)
    {
        isGrabbing = pGrabbing;
    }

    public bool GetIsGrabbing()
    {
        return isGrabbing;
    }

    public void SetLookingDirection(Directions pDirection)
    {
        lookingDirection = pDirection;
    }

    public Directions GetLookingDirection()
    {
        return lookingDirection;
    }
}
