using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardinalCollider : MonoBehaviour
{
    [SerializeField] private Directions colliderDir;
    [SerializeField] private Pushable pushableObjectRef;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Pushable>() != null)
        {
            pushableObjectRef = collision.gameObject.GetComponent<Pushable>();
            pushableObjectRef.SetCollingObject(colliderDir, collision.gameObject);
        }
    }
}
