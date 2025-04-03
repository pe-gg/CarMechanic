using System;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Rigidbody[] hoistArms;
    [SerializeField] private Rigidbody[] armJoints;

    [SerializeField] private float liftSpeed;
    [SerializeField] private float lowerSpeed;
    [SerializeField] private float maximumHeight;
    [SerializeField] private float minimumHeight;

    [SerializeField] bool _raiseLift;
    [SerializeField] bool _lowerLift;

    private void Start()
    {
        
    }

    public void FixedUpdate()
    {
        if (_raiseLift)
        {
            _lowerLift = false;
            RaiseLift();
        }
        if(_lowerLift)
        {
            _raiseLift = false;
            LowerLift();
        }
        
        if (hoistArms[0].position.y >= 1f)
        {
            LockArms(true);
        }
        else
        {
            LockArms(false);
        }
    }

    public void RaiseLift()
    {
        foreach(var arm in hoistArms)
        {
            var newPosition = new Vector3(arm.position.x, Mathf.Clamp(arm.position.y + (liftSpeed * Time.fixedDeltaTime), minimumHeight, maximumHeight), arm.position.z);
            arm.position = newPosition;
        }
    }

    public void LowerLift()
    {
        foreach(var arm in hoistArms)
        {
            var newPosition = new Vector3(arm.position.x, Mathf.Clamp(arm.position.y - (lowerSpeed * Time.fixedDeltaTime), minimumHeight, maximumHeight), arm.position.z);
            arm.position = newPosition;
        }
    }

    private void LockArms(bool state)
    {
        foreach (var joint in armJoints)
        {
            joint.isKinematic = state;
            Debug.Log("Locked");
        }
    }

    public void ToggleRaise(bool state)
    {
        _raiseLift = state;
    }
}
