using UnityEngine;

public class NutTrigger : MonoBehaviour
{
    private ImpactGunActivator gun;
    private NutTwister attachedTwister;
    private bool _inRadius = false;

    private MeshRenderer _renderer;
    private SphereCollider _collider;

    public bool Attached { get; private set; } = true;
    
    private void Awake()
    {
        gun = FindFirstObjectByType<ImpactGunActivator>();
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("CorrectNut"))
            return;
        Debug.Log("Socket on nut");
        _inRadius = true;
        attachedTwister = other.GetComponent<NutTwister>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.GetComponent<NutTwister>()) return;
        if (!_inRadius || !attachedTwister.isSpinning)
        {
            Debug.Log("this shit aint workin");
            return;
        }
        Debug.Log("Removing Nut");
        if (Attached)
        {
            ToggleNuts(false);
        }
        gun.Lock(true);
        //anim here
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.GetComponent<NutTwister>()) return;
        Debug.Log("socket removed from Nut");
        _inRadius = false;
    }

    private void ToggleNuts(bool state)
    {
        switch (state)
        {
            case true:
                _renderer.enabled = true;
                Attached = true;
                break;
            case false:
                _renderer.enabled = false;
                Attached = false;
                break;
        }
    }
}
