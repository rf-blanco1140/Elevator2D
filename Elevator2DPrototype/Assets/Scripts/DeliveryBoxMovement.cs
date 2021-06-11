using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBoxMovement : MonoBehaviour
{
    [SerializeField] private DeliveryBox deliveryBoxRef;
    private Directions windDirection;

    private void FixedUpdate()
    {
        MoveDeliveryBox();
    }

    private void MoveDeliveryBox()
    {
        bool canMove = false;
        windDirection = deliveryBoxRef.GetWindReference().GetWindDirection();
        canMove = CheckIfCanMove(windDirection);
        if(canMove)
        {
            deliveryBoxRef.MoveToDirection(windDirection);
        }
        //TODO la velocidad cambia a la velocidad del objeto colisionando en la Dir de la fuerza con menor velocidad
    }

    public bool CheckIfCanMove(Directions movementDir)
    {
        bool canMove = true;
        if(deliveryBoxRef.GetIsGrabbed())
        {
            canMove = false;
            return canMove;
        }

        Pushable collidingObj = deliveryBoxRef.GetCollidingObjInDirection(movementDir);
        if(collidingObj != null)
        {
            Debug.LogError("Encounterd a Pushable");
            DeliveryBoxMovement collidingDBM = collidingObj.GetComponent<DeliveryBoxMovement>();
            if(collidingDBM != null)
            {
                Debug.LogError("Found a DeliveryBoxMovement");
                canMove = collidingDBM.CheckIfCanMove(movementDir);
            }
        }
        return canMove;
    }
}
