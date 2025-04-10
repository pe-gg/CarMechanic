using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRLever : XRGrabInteractable
{
    [SerializeField] private float triggerAngle;
    [SerializeField] private Vector3 leverAxis;

    private bool _currentlyEnabled;

    private void Update()
    {
        if (transform.localRotation.x > triggerAngle && leverAxis.x > 0)
        {
            CheckState(true);
        }
        else if (transform.localRotation.y > triggerAngle && leverAxis.y > 0)
        {
            CheckState(true);
        }
        else if (transform.localRotation.z > triggerAngle && leverAxis.z > 0)
        {
            CheckState(true);
        }
        else
        {
            CheckState(false);
        }
    }

    private void CheckState(bool newState)
    {
        switch (newState)
        {
            case true when !_currentlyEnabled:
                selectEntered.Invoke(new SelectEnterEventArgs());
                break;
            case false when _currentlyEnabled:
                selectExited.Invoke(new SelectExitEventArgs());
                break;
        }

        _currentlyEnabled = newState;
    }
}
