using UnityEngine;

public class NutTrigger : MonoBehaviour
{
    private ImpactGunActivator gun;
    private NutTwister attachedTwister;
    private bool _inRadius = false;
    
    private void Awake()
    {
        gun = FindFirstObjectByType<ImpactGunActivator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("CorrectNut"))
            return;
        _inRadius = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_inRadius || !attachedTwister.isSpinning)
            return;
        gun.Lock(true);
        gameObject.SetActive(false);
        //anim here
    }

    private void OnTriggerExit(Collider other)
    {
        _inRadius = false;
    }
}
