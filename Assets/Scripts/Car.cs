using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField] private float inAirThreshold;
    [SerializeField] private JackPoint[] jackPoints;
    [SerializeField] private WheelHub[] wheelHubs;
    [SerializeField] private Wheel[] wheels;

    private LayerMask _floorLayer;
    public bool Destroyed { get; private set; }

    [SerializeField] private TaskData jackPadsInPlaceData;
    [SerializeField] private TaskData carInAirData;
    [SerializeField] private TaskData allNutsRemovedData;
    [SerializeField] private TaskData allWheelsRemovedData;

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfGravity;

        Destroyed = false;
        
        _floorLayer = LayerMask.NameToLayer("Floor");
    }

    private void Update()
    {
        AdjustWheelVisuals();

        CheckTaskStates();
    }

    private void CheckTaskStates()
    {
        if(Destroyed) return;
        
        if (!carInAirData.completed)
        {
            CheckInAir();
        }

        if (!jackPadsInPlaceData.completed)
        {
            CheckJackPads();
        }

        if (!allNutsRemovedData.completed)
        {
            CheckNutsRemoved();
        }

        if (!allWheelsRemovedData.completed)
        {
            CheckAllWheelsRemoved();
        }
    }

    private void CheckInAir()
    {
        if (!(transform.position.y >= inAirThreshold))
        {
            carInAirData.completed = false;
            return;
        }
        carInAirData.completed = true;
        carInAirData.onCompleted?.Invoke();
    }

    private void CheckJackPads()
    {
        if (!jackPoints.All(point => point.TouchingJackPad))
        {
            jackPadsInPlaceData.completed = false;
            return;
        }
        jackPadsInPlaceData.completed = true;
        jackPadsInPlaceData.onCompleted?.Invoke();
    }

    private void CheckNutsRemoved()
    {
        if (!wheelHubs.All(hub => hub.NutsData.completed))
        {
            allNutsRemovedData.completed = false;
            return;
        }

        allNutsRemovedData.completed = true;
        allNutsRemovedData.onCompleted?.Invoke();
    }

    private void CheckAllWheelsRemoved()
    {
        if (!wheels.All(wheel => wheel.WheelRemovedData.completed))
        {
            allWheelsRemovedData.completed = false;
            return;
        }

        allWheelsRemovedData.completed = true;
        allWheelsRemovedData?.onCompleted.Invoke();
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
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer != _floorLayer) return;
        Destroyed = true;
        Debug.Log("Why have you dropped me...");
    }
}
