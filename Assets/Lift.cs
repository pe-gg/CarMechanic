using System;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Rigidbody[] hoistArms;
    [SerializeField] private Rigidbody[] armJoints;

    [SerializeField] private float liftSpeed;
    [SerializeField] private float maximumHeight;
    [SerializeField] private float minimumHeight;

    private bool _raiseLift;

    private void Start()
    {
        ToggleRaise(true);
    }

    public void FixedUpdate()
    {
        if (!_raiseLift) return;
        RaiseLift();
        if (armJoints[0].transform.position.y >= 1f)
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

    private void LockArms(bool state)
    {
        foreach (var joint in armJoints)
        {
            joint.isKinematic = true;
            Debug.Log("Locked");
        }
    }

    public void ToggleRaise(bool state)
    {
        _raiseLift = state;
    }
}
