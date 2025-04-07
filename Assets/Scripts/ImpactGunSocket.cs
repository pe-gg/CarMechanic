using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ImpactGunSocket : XRSocketInteractor
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        //temp
    }
    /*
     *  private bool bodySocketable;
    private bool currentlySocketable;

    void FixedUpdate()
    {
        if (bodySocketable && currentlySocketable)
        {
            // remove socketable interaction layer
            currentlySocketable = false;
            StartCoroutine(SetSocketable());
        }
    }

    IEnumerator SetSocketable()
    {
        // wait for one frame
        yield return null;
        interactionLayers = InteractionLayerMask.GetMask("Interactable");
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (bodySocketable)
        {
            interactionLayers = InteractionLayerMask.GetMask("Interactable", "Interactable Body Socketable");
            currentlySocketable = true;
        }
        base.OnSelectExited(args);
    }
     */
}