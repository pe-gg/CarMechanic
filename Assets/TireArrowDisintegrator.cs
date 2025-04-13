using UnityEngine;

public class TireArrowDisintegrator : MonoBehaviour //this is very neccessary
{
    [SerializeField] private GameObject ArrowToDisintegrate;
    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Wheel>())
            return;
        ArrowToDisintegrate.SetActive(false);
    }
}
