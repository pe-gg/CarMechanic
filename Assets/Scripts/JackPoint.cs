using UnityEngine;
using UnityEngine.Events;

public class JackPoint : MonoBehaviour
{
    public UnityEvent jackTouching;
    public UnityEvent jackLeft;
    public bool TouchingJackPad { get; private set; }
    private JackPad pad;

    private void OnTriggerEnter(Collider other)
    {
        pad = other.transform.GetComponent<JackPad>();
        if (!pad) return;
        TouchingJackPad = true;
        jackTouching?.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        pad = other.transform.GetComponent<JackPad>();
        if (!pad) return;
        TouchingJackPad = false;
        jackLeft?.Invoke();
    }
}
