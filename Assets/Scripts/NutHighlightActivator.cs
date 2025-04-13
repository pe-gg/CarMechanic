using UnityEngine;

public class NutHighlightActivator : MonoBehaviour
{
    [SerializeField] private NutReplaceHighlight[] nuts;

    public void ActivateNutHighlights()
    {
        foreach (NutReplaceHighlight nut in nuts)
        {
            nut.gameObject.SetActive(true);
        }
    }
}
