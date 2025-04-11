using System.Linq;
using UnityEngine;

public class WheelHub : MonoBehaviour
{
    [field: SerializeField] public NutTrigger[] AssignedNuts { get; private set; }
    [field: SerializeField] public TaskData NutsRemovedData { get; private set; }
    [field: SerializeField] public TaskData NutsAttachedData { get; private set; }

    public Wheel AttachedWheel { get; private set; }

    private void Update()
    {
        if (!NutsRemovedData.completed)
        {
            CheckNutsRemoved();
        }

        if (!NutsAttachedData.completed)
        {
            CheckNutsAttached();
        }
    }

    private void CheckNutsRemoved()
    {
        if (AssignedNuts.All(nut => !nut.Attached))
        {
            NutsRemovedData.completed = true;
            NutsRemovedData.onCompleted?.Invoke();
            if(AttachedWheel)
                AttachedWheel.SetLockedState(false);
        }
        else
        {
            NutsRemovedData.completed = false;
            if(AttachedWheel)
                AttachedWheel.SetLockedState(true);
        }
    }
    
    private void CheckNutsAttached()
    {
        if (AssignedNuts.Any(nut => nut.Attached))
        {
            NutsAttachedData.completed = true;
            
            if(AttachedWheel)
                AttachedWheel.SetLockedState(true);
        }
        else if(AssignedNuts.All(nut => nut.Attached))
        {
            NutsAttachedData.completed = true;
            NutsAttachedData.onCompleted?.Invoke();
            if(AttachedWheel)
                AttachedWheel.SetLockedState(true);
        }
        else if (AssignedNuts.All(nut => !nut.Attached))
        {
            NutsAttachedData.completed = false;
            if(AttachedWheel)
                AttachedWheel.SetLockedState(false);
        }
    }

    public void AttachWheel(Wheel newWheel)
    {
        AttachedWheel = newWheel;
    }
}
