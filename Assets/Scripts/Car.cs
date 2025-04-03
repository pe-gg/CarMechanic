using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Vector3 centerOfGravity;

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfGravity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(centerOfGravity, 0.5f);
    }
}
