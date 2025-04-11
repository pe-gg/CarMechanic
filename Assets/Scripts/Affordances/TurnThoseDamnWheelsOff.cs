using UnityEngine;

public class TurnThoseDamnWheelsOff : MonoBehaviour
{
    [SerializeField] private Outline[] wheels;

    private void Awake()
    {
        Invoke("Die", 0.1f);
    }
    private void Die()
    {
        foreach (Outline ol in wheels)
        {
            ol.enabled = false;
        }
    }
}
