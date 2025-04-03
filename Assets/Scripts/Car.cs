using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Vector3 centerOfGravity;

    [SerializeField] private WheelCollider colliderFL;
    [SerializeField] private WheelCollider colliderFR;
    [SerializeField] private WheelCollider colliderRL;
    [SerializeField] private WheelCollider colliderRR;

    [SerializeField] private Transform visualFL;
    [SerializeField] private Transform visualFR;
    [SerializeField] private Transform visualRL;
    [SerializeField] private Transform visualRR;

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfGravity;
    }

    private void Update()
    {
        AdjustWheelVisuals();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(centerOfGravity, 0.5f);
    }

    private void AdjustWheelVisuals()
    {
        colliderFL.GetWorldPose(out var flPos, out var flRot);
        colliderFR.GetWorldPose(out var frPos, out var frRot);
        colliderRL.GetWorldPose(out var rlPos, out var rlRot);
        colliderRR.GetWorldPose(out var rrPos, out var rrRot);
        
        visualFL.position = flPos;
        visualFR.position = frPos;
        visualRL.position = rlPos;
        visualRR.position = rrPos;
        //visualFL.rotation = flRot;
        ////visualFR.rotation = frRot;
        //visualRL.rotation = rlRot;
        //visualRR.rotation = rrRot;
    }
}
