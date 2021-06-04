using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBox : Pushable
{
    private bool isGrabbed;
    private bool isBlcoked;

    private void Start()
    {
        currentSpeed = maxSpeed;
        isGrabbed = false;
    }

    public void SetIsGrabbed(bool newGrabbedStatus)
    {
        isGrabbed = newGrabbedStatus;
    }

    public bool GetIsGrabbed()
    {
        return isGrabbed;
    }

    public bool GetIsBlocked()
    {
        return isBlcoked;
    }

    public void SetIsBlocked(bool newBlockedStatus)
    {
        isBlcoked = newBlockedStatus;
    }
}
