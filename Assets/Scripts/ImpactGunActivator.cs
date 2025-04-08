using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ImpactGunActivator : MonoBehaviour
{
    private bool _lock;
    private NutTwister attachedSocket;
    public void ActivateGun()
    {
        //anim
        if (!attachedSocket) return;
        attachedSocket.ToggleSpin(true);
    }

    public void DeactivateGun()
    {
        //anim cancel
        if (!attachedSocket) return;
        attachedSocket.ToggleSpin(false);
    }

    public void Lock(bool onOff)
    {
        _lock = onOff;
    }

    public void SetAttachedSocket(SelectEnterEventArgs args)
    {
        Debug.Log(args.interactableObject.transform.GetComponent<NutTwister>());
        //TODO: Make this shit work :)
        attachedSocket = args.interactableObject.transform.GetComponent<NutTwister>();
    }

    public void RemoveAttachedSocket(SelectExitEventArgs args)
    {
        Debug.Log(args.interactableObject.transform.name);
        attachedSocket = null;
    }
}
