using UnityEngine;

public class NutTwister : MonoBehaviour
{
    [SerializeField] private GameObject trigger;
    public bool isSpinning { get; private set; }
    public void ToggleSpin(bool spin)
    {
        isSpinning = spin;
        //animator activate
        trigger.SetActive(spin);
    }
}
