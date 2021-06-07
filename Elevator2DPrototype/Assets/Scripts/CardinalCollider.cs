using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardinalCollider : MonoBehaviour
{
    [SerializeField] private Directions colliderDir;
    private Pushable pushableObjectRef;

    private void Awake()
    {
        pushableObjectRef = transform.parent.GetComponent<Pushable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CardinalCollider theOther = collision.gameObject.GetComponent<CardinalCollider>();
        if (theOther == null)
            return;

        if(theOther.pushableObjectRef != null && IsOppositeDirection(theOther.colliderDir))
        {
            pushableObjectRef.SetCollingObject(colliderDir, theOther.pushableObjectRef);
        }
    }

    private bool IsOppositeDirection(Directions dir)
    {
        switch (colliderDir)
        {
            case Directions.East:
                return dir == Directions.West;
            case Directions.West:
                return dir == Directions.East;
            case Directions.North:
                return dir == Directions.South;
            case Directions.South:
                return dir == Directions.North;
        }
        return true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CardinalCollider theOther = collision.gameObject.GetComponent<CardinalCollider>();
        if (theOther == null)
            return;

        if (theOther.pushableObjectRef != null && IsOppositeDirection(theOther.colliderDir))
        {
            if(pushableObjectRef.GetCollidingObjInDirection(colliderDir) == theOther.pushableObjectRef)
            {
                pushableObjectRef.FreeColligingObj(colliderDir);
            }
        }
    }
}
