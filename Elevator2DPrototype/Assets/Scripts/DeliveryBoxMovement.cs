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

    //TODO actualmente se esta haciendo asumiendo que solo se va a encontrar con otras cajas y que el jugador es lo unico que puede causar que se detengan
    public bool CheckIfCanMove(Directions movementDir)
    {
        bool canMove = true;
        if(deliveryBoxRef.GetIsGrabbed())
        {
            canMove = false;
            return canMove;
        }
        
        GameObject collidingObj = deliveryBoxRef.GetCollidingObjInDirection(movementDir);
        if(collidingObj != null)
        {
            DeliveryBoxMovement collidingDBM = collidingObj.GetComponent<DeliveryBoxMovement>();
            if(collidingDBM != null)
            {
                canMove = collidingObj.GetComponent<DeliveryBoxMovement>().CheckIfCanMove(movementDir);
            }
        }
        return canMove;
    }
}
