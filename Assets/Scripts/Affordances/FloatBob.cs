using UnityEngine;

public class FloatBob : MonoBehaviour
{
    [SerializeField] private float frequency;
    [SerializeField] private float intensity;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, intensity * Mathf.Cos(Time.time * frequency) * Vector3.up.y, transform.position.z);
    }
}
