using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HubSocket : XRSocketInteractor
{
    private WheelHub _localHub;

    protected override void Start()
    {
        base.Start();
        _localHub = GetComponentInParent<WheelHub>();
    }
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        var wheel = args.interactableObject.transform.GetComponent<Wheel>();
        if(!wheel) return;
        _localHub.AttachWheel(wheel);
        wheel.CheckWheelAttached(false);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        var wheel = args.interactableObject.transform.GetComponent<Wheel>();
        if(!wheel) return;
        _localHub.AttachWheel(null);
        wheel.CheckWheelAttached(true);
    }
}
