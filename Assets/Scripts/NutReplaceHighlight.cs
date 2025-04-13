using UnityEngine;

public class NutReplaceHighlight : MonoBehaviour
{
    private MeshRenderer _mesh;
    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("CorrectNut"))
            return;
        _mesh.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("CorrectNut"))
            return;
        _mesh.enabled = false;
    }
}
