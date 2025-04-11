using System;
using System.Collections.Generic;
using UnityEngine;

public class TireDestination : MonoBehaviour
{
    private List<GameObject> _wheelsInVolume = new();

    [SerializeField] private TaskData allWheelsInVolumeData;

    [SerializeField] private GameObject newTires;
    [SerializeField] private Transform newTiresPosition;

    private void OnTriggerEnter(Collider other)
    {
        var wheel = other.GetComponent<Wheel>().gameObject;
        if(!wheel) return;
        _wheelsInVolume.Add(wheel);
        CheckWheelsInVolume();
    }

    private void OnTriggerExit(Collider other)
    {
        var wheel = other.GetComponent<Wheel>().gameObject;
        if(!wheel) return;
        _wheelsInVolume.Remove(wheel);
    }

    private void CheckWheelsInVolume()
    {
        if (_wheelsInVolume.Count != 4 || allWheelsInVolumeData.completed) return;
        allWheelsInVolumeData.completed = true;
        allWheelsInVolumeData.onCompleted?.Invoke();
    }

    public void SpawnNewTires()
    {
        foreach (var wheel in _wheelsInVolume)
        {
            Destroy(wheel);
            //TODO: Fun effects
        }
        Instantiate(newTires, newTiresPosition.position, Quaternion.identity);
    }
}
