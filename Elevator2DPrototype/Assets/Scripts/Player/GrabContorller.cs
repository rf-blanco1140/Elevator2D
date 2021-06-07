using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabContorller : MonoBehaviour
{
    [SerializeField] private Player playerRef;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(CheckIfHasBoxToGrab())
            {
                GrabObject();
            }
        }
        else if(playerRef.GetIsGrabbing())
        {
            ReleaseGrabbedObject();
        }
    }

    private bool CheckIfHasBoxToGrab()
    {
        Pushable facingBox = playerRef.GetCollidingObjInDirection(playerRef.GetLookingDirection());
        if (facingBox != null) 
        {
            if (facingBox.GetComponent<DeliveryBox>() != null)
            {
                return true;
            }
        }
        
        return false;
    }

    private void GrabObject()
    {
        playerRef.SetIsGrabbing(true);
        Pushable collidedObject = playerRef.GetCollidingObjInDirection(playerRef.GetLookingDirection());
        if (collidedObject != null)
        {
            collidedObject.GetComponent<DeliveryBox>().SetIsGrabbed(true);
        }
        else
        {
            Debug.LogError("D:");
        }
    }

    private void ReleaseGrabbedObject()
    {
        playerRef.SetIsGrabbing(false);
        Pushable collidedObject = playerRef.GetCollidingObjInDirection(playerRef.GetLookingDirection());
        if (collidedObject != null)
        {
            collidedObject.GetComponent<DeliveryBox>().SetIsGrabbed(false);
        }
        else
        {
            Debug.LogError("D:");
        }
    }
}
