using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private bool isGrabbing;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        isGrabbing = false;
    }
}
