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
        Debug.Log("Socket on nut");
        _inRadius = true;
        attachedTwister = other.GetComponent<NutTwister>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_inRadius || !attachedTwister.isSpinning)
        {
            Debug.Log("this shit aint workin");
            return;
        }
        Debug.Log("Removing Nut");
        gun.Lock(true);
        gameObject.SetActive(false);
        //anim here
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("socket removed from Nut");
        _inRadius = false;
    }
}
