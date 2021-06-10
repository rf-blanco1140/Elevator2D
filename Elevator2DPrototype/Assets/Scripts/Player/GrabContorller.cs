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
        Pushable collidedObject = playerRef.GetCollidingObjInDirection(playerRef.GetLookingDirection());
        if (collidedObject != null)
        {
            playerRef.SetIsGrabbing(true);
            collidedObject.GetComponent<DeliveryBox>().SetIsGrabbed(true);
            playerRef.SetGrabbedObject(collidedObject.GetComponent<DeliveryBox>());
        }
        else
        {
            Debug.LogError("D: al agarrar");
        }
    }

    private void ReleaseGrabbedObject()
    {
        Pushable collidedObject = playerRef.GetCollidingObjInDirection(playerRef.GetLookingDirection());
        if (collidedObject != null)
        {
            playerRef.SetIsGrabbing(false);
            collidedObject.GetComponent<DeliveryBox>().SetIsGrabbed(false);
            playerRef.SetGrabbedObject(null);
        }
        else
        {
            Debug.LogError("D: al soltar");
        }
    }
}
