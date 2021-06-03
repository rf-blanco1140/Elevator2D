using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabContorller : MonoBehaviour
{
    /**public Transform grabbingPivot;
    private bool canGrab;
    private bool isGrabbing;
    private GameObject objToGrab;
    [SerializeField] PlayerMovement playerMovementRef;

    private void Start()
    {
        canGrab = false;
        isGrabbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        GrabObject(objToGrab);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grabbable")
        {
            canGrab = true;
            objToGrab = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        canGrab = false;
        objToGrab = null;
    }

    private void GrabObject(GameObject pGrabbedObj)
    {
        if(canGrab)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrabbing = true;
                pGrabbedObj.GetComponent<ObjectStatus>().SetIsGrabbed(true);
                pGrabbedObj.GetComponent<ObjectStatus>().SetIsBlocked(true);
                pGrabbedObj.GetComponent<ObjectsMovement>().StopObject();
                objToGrab.transform.parent = grabbingPivot;
                objToGrab.transform.position = grabbingPivot.position;
                playerMovementRef.ChangeMovementSpeed(2);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                isGrabbing = false;
                objToGrab.transform.parent = null;
                playerMovementRef.ChangeMovementSpeed(5);
                pGrabbedObj.GetComponent<ObjectStatus>().SetIsGrabbed(false);
                pGrabbedObj.GetComponent<ObjectStatus>().SetIsBlocked(false);
            }
        }
        
    }

    public bool getIsGrabbing()
    {
        return isGrabbing;
    }*/
}
