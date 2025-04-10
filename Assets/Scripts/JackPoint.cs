using UnityEngine;

public class JackPoint : MonoBehaviour
{
    public bool TouchingJackPad { get; private set; }
    private JackPad pad;

    private void OnTriggerEnter(Collider other)
    {
        pad = other.transform.GetComponent<JackPad>();
        if (!pad) return;
        TouchingJackPad = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        pad = other.transform.GetComponent<JackPad>();
        if (!pad) return;
        TouchingJackPad = false;
    }
}
