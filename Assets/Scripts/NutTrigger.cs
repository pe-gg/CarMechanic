using UnityEngine;

public class NutTrigger : MonoBehaviour
{
    [SerializeField] private GameObject highlight;
    private ImpactGunActivator gun;
    private NutTwister attachedTwister;
    private Outline _outline;
    private bool _inRadius = false;
    private AudioManager _sfx;

    private MeshRenderer _renderer;
    private SphereCollider _collider;

    private bool _interactable = true;

    public bool Attached { get; private set; } = true;
    
    private void Awake()
    {
        gun = FindFirstObjectByType<ImpactGunActivator>();
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<SphereCollider>();
        _outline = GetComponent<Outline>();
        _sfx = FindFirstObjectByType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("CorrectNut"))
            return;
        Debug.Log("Socket on nut");
        _inRadius = true;
        attachedTwister = other.GetComponent<NutTwister>();
        _outline.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.GetComponent<NutTwister>()) return;
        if(!_interactable) return;
        if (!_inRadius || !attachedTwister.isSpinning)
        {
            return;
        }
        if (Attached)
        {
            ToggleNuts(false);
        }
        else
        {
            ToggleNuts(true);
        }
        gun.Lock(true);
        //anim here
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.GetComponent<NutTwister>()) return;
        Debug.Log("socket removed from Nut");
        _inRadius = false;
        _outline.enabled = false;
    }

    public void ToggleNuts(bool state)
    {
        switch (state)
        {
            case true:
                _renderer.enabled = true;
                highlight.SetActive(false);
                Attached = true;
                _interactable = false;
                _sfx.PlaySFX(1);
                break;
            case false:
                _renderer.enabled = false;
                Attached = false;
                _interactable = false;
                _sfx.PlaySFX(1);
                break;
        }
    }

    public void SetInteractable()
    {
        _interactable = true;
    }
}
