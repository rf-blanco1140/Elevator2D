using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    [SerializeField] protected float maxSpeed;
    protected float currentSpeed;
    protected GameObject NorthCollidingObj;
    protected GameObject SouthCollidingObj;
    protected GameObject EastCollidingObj;
    protected GameObject WestCollidingObj;
    [SerializeField] protected EnviromentStatus windRef;

    private void Start()
    {
        currentSpeed = maxSpeed;
    }

    public float GetObjSpeed()
    {
        return currentSpeed;
    }

    public void ResetSpeedToMax()
    {
        currentSpeed = maxSpeed;
    }

    public void SubtractSpeed(float decreaseVal)
    {
        currentSpeed = currentSpeed - decreaseVal;
    }

    public void SetCollingObject(Directions collisionDirection, GameObject collisionObj)
    {
        switch(collisionDirection)
        {
            case Directions.North:
                NorthCollidingObj = collisionObj;
                break;
            case Directions.South:
                SouthCollidingObj = collisionObj;
                break;
            case Directions.West:
                WestCollidingObj = collisionObj;
                break;
            case Directions.East:
                EastCollidingObj = collisionObj;
                break;
        }
    }

    public void FreeColligingObj(Directions dirToFree)
    {
        switch(dirToFree)
        {
            case Directions.East:
                EastCollidingObj = null;
                break;
            case Directions.West:
                WestCollidingObj = null;
                break;
            case Directions.South:
                SouthCollidingObj = null;
                break;
            case Directions.North:
                NorthCollidingObj = null;
                break;
        }
    }

    public GameObject GetCollidingObjInDirection(Directions pDirection)
    {
        GameObject requestedGO = null;
        switch(pDirection)
        {
            case Directions.North:
                requestedGO = NorthCollidingObj;
                break;
            case Directions.South:
                requestedGO = SouthCollidingObj;
                break;
            case Directions.West:
                requestedGO = WestCollidingObj;
                break;
            case Directions.East:
                requestedGO = EastCollidingObj;
                break;
        }
        return requestedGO;
    }

    public void MoveToDirection(Directions pDirection)
    {
        Vector3 movingVector = new Vector3();
        switch(pDirection)
        {
            case Directions.East:
                movingVector = Vector3.right * currentSpeed;
                break;
            case Directions.West:
                movingVector = Vector3.left * currentSpeed;
                break;
            case Directions.South:
                movingVector = Vector3.down * currentSpeed;
                break;
            case Directions.North:
                movingVector = Vector3.up * currentSpeed;
                break;
        }
        transform.Translate(movingVector, Space.World);
    }

    public EnviromentStatus GetWindReference()
    {
        return windRef;
    }
}
