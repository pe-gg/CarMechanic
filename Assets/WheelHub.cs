using System.Linq;
using UnityEngine;

public class WheelHub : MonoBehaviour
{
    [SerializeField] private NutTrigger[] assignedNuts;
    [field: SerializeField] public TaskData NutsData { get; private set; }

    private Wheel _attachedWheel;

    private void Update()
    {
        if (!NutsData.completed)
        {
            CheckNutsRemoved();
        }
    }

    private void CheckNutsRemoved()
    {
        if (assignedNuts.All(nut => nut.Attached))
        {
            NutsData.completed = false;
            if(_attachedWheel)
                _attachedWheel.SetLockedState(true);
        }
        else
        {
            NutsData.completed = true;
            NutsData.onCompleted?.Invoke();
            if(_attachedWheel)
                _attachedWheel.SetLockedState(false);
        }
    }

    public void AttachWheel(Wheel newWheel)
    {
        _attachedWheel = newWheel;
    }
}
