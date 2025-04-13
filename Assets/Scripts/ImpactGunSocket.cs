using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ImpactGunSocket : XRSocketInteractor
{

    protected override void OnHoverEntering(HoverEnterEventArgs args)
    {
        if (!args.interactableObject.transform.gameObject.GetComponent<NutTwister>())
            return;
        base.OnHoverEntering(args);
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        
    }
    
}