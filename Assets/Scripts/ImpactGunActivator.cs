using UnityEngine;
using UnityEngine.Events;

public class ImpactGunActivator : MonoBehaviour
{
    private bool _lock;
    private NutTwister attachedSocket;
    public void ActivateGun()
    {
        attachedSocket = GetComponentInChildren<NutTwister>();
        //anim
        if (attachedSocket = null)
            return;
        attachedSocket.ToggleSpin(true);
    }

    public void DeactivateGun()
    {
        //anim cancel
        attachedSocket.ToggleSpin(false);
        attachedSocket = null;
    }

    public void Lock(bool onOff)
    {
        _lock = onOff;
    }
}
