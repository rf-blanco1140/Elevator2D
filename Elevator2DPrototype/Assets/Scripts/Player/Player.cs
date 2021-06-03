using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pushable
{
    private bool isGrabbing;

    public void MovePlayer(Directions moveDirection)
    {
        MoveToDirection(moveDirection);
    }
}
