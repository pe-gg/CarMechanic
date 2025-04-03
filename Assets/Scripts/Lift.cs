using System;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Rigidbody[] hoistArms;
    [SerializeField] private Rigidbody[] armJoints;

    [SerializeField] private Transform[] lockPoints;

    [SerializeField] private float liftSpeed;
    [SerializeField] private float lowerSpeed;
    [SerializeField] private float maximumHeight;
    [SerializeField] private float minimumHeight;
    [SerializeField] private float armLockHeight;
    private float _currentLowestPoint;

    [SerializeField] bool _raiseLift;
    [SerializeField] bool _lowerLift;
    [SerializeField] bool _releaseLock;

    private void Start()
    {
        _currentLowestPoint = minimumHeight;
    }

    public void FixedUpdate()
    {
        if (_releaseLock)
        {
            _currentLowestPoint = minimumHeight;
        }
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
        
        if (hoistArms[0].position.y >= armLockHeight)
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
        CheckLock();
        foreach(var arm in hoistArms)
        {
            var newPosition = new Vector3(arm.position.x, Mathf.Clamp(arm.position.y + (liftSpeed * Time.fixedDeltaTime), _currentLowestPoint, maximumHeight), arm.position.z);
            arm.position = newPosition;
        }
    }

    public void LowerLift()
    {
        foreach(var arm in hoistArms)
        {
            var newPosition = new Vector3(arm.position.x, Mathf.Clamp(arm.position.y - (lowerSpeed * Time.fixedDeltaTime), _currentLowestPoint, maximumHeight), arm.position.z);
            arm.position = newPosition;
        }
    }

    private void LockArms(bool state)
    {
        foreach (var joint in armJoints)
        {
            joint.isKinematic = state;
        }
    }

    public void ToggleRaise(bool state)
    {
        _raiseLift = state;
    }

    public void ReleaseLock(bool state)
    {
        _releaseLock = state;
    }

    private void CheckLock()
    {
        if (_releaseLock) return;
        foreach (var point in lockPoints)
        {
            foreach(var arm in hoistArms)
            {
                if (arm.transform.position.y >= point.position.y)
                {
                    if(_currentLowestPoint == point.position.y) continue;
                    _currentLowestPoint = point.position.y;
                    Debug.Log("lock passed");
                }
            }
        }
    }
}
