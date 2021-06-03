using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D objectRB;
    [SerializeField] EnviromentStatus enviromentRef;
    [SerializeField] ObjectStatus objStatus;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        // TODO no se deberia mover si el jugador lo esta agarrando
        if(!objStatus.GetIsBlocked())
        {
            MoveObject(enviromentRef.GetWindDirection());
        }
    }

    public float GetMovementSpeed()
    {
        return objStatus.GetMaxSpeed();
    }

    private void MoveObject(EnviromentStatus.Direction pDirection)
    {
        /**switch(pDirection)
        {
            case EnviromentStatus.Direction.East:
                objectRB.velocity = new Vector2(1,0) * objStatus.GetMaxSpeed();
                break;
            case EnviromentStatus.Direction.West:
                objectRB.velocity = new Vector2(-1, 0) * objStatus.GetMaxSpeed();
                break;
            case EnviromentStatus.Direction.North:
                objectRB.velocity = new Vector2(0, 1) * objStatus.GetMaxSpeed();
                break;
            case EnviromentStatus.Direction.South:
                objectRB.velocity = new Vector2(0, -1) * objStatus.GetMaxSpeed();
                break;
        }*/
    }

    public void StopObject()
    {
        objectRB.velocity = new Vector2(0, 0);
    }
}
