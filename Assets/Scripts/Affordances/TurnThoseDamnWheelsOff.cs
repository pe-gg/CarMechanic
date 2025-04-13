using UnityEngine;

public class TurnThoseDamnWheelsOff : MonoBehaviour
{
    [SerializeField] private Outline[] wheels;
    private GameObject[] NewTires;

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

    public void DieNewTires()
    {
        NewTires = GameObject.FindGameObjectsWithTag("NewWheel");
        Invoke("MakeSureTheyDie", 0.1f);
    }

    private void MakeSureTheyDie()
    {
        foreach (GameObject Wheel in NewTires)
        {
            Wheel.GetComponentInChildren<Outline>().enabled = false;
        }
    }
}
