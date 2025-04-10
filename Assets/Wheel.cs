using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Wheel : MonoBehaviour
{
    [field: SerializeField] public TaskData WheelAttachedData { get; private set; }

    private XRGrabInteractable _grabInteractable;

    [SerializeField] private InteractionLayerMask disabledLayers;
    [SerializeField] private InteractionLayerMask enabledLayers;

    private void Start()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void AttachWheel(bool state)
    {
        WheelAttachedData.completed = state;
    }

    public void SetLockedState(bool state)
    {
        _grabInteractable.interactionLayers = state switch
        {
            true => disabledLayers,
            false => enabledLayers
        };
    }
}
