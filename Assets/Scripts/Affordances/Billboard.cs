using System;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private bool clampToY = false;
    private Camera _currentCam;

    private void Start()
    {
        _currentCam = Camera.main;
    }

    private void OnEnable()
    {
        _currentCam = Camera.main;
    }

    private void LateUpdate()
    {
        if (_currentCam)
        {
            transform.LookAt(_currentCam.transform);
            if (clampToY)
            {
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            }
        }
    }
}
