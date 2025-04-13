using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] sources;
    public void PlaySFX(int id)
    {
        sources[id].Play();
    }
    /*
     * 0 = task complete
     * 1 = drill twist
     * 2 = punch sfx
     * 3 = kind of a pop sorta
     * 4 = car crash
     */
}
