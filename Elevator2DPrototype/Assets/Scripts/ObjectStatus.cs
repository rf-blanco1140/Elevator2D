using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{
    private bool isGrabbed;
    private bool isBlocked;
    [SerializeField] float maxSpeed;

    private void Start()
    {
        isGrabbed = false;
        isBlocked = false;
    }

    public void SetIsGrabbed(bool pGrabbed)
    {
        isGrabbed = pGrabbed;
    }

    public bool GetIsGrabbed()
    {
        return isGrabbed;
    }

    public void SetIsBlocked(bool pBlocked)
    {
        isBlocked = pBlocked;
    }

    public bool GetIsBlocked()
    {
        return isBlocked;
    }

    public void SetMaxSpeed(float pSpeed)
    {
        maxSpeed = pSpeed;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
}
