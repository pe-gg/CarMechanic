using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer image;
    private bool _loop = false;
    private bool _faded = true;

    private void Awake()
    {
        image.material.color = new Color(0f, 0f, 0f, 1f);
        Invoke("StartFade", 0.2f);
    }

    private void StartFade()
    {
        _faded = false;
    }
    public void FadeOut()
    {
        _loop = true;
        StartCoroutine("FadingOut");
    }

    private IEnumerator FadingOut()
    {
        while (_loop)
        {
            image.material.color = new Color(0f, 0f, 0f, image.material.color.a + 0.05f);
            Debug.Log("LoopingFadeout");
            if (image.material.color.a >= 254)
            {
                _loop = false;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        _faded = true;
        yield return new WaitForFixedUpdate();
    }
    private void FixedUpdate()
    {
        if (!_faded && !_loop && image.material.color.a >= 0)
        {
            Debug.Log(image.material.color.a);
            image.material.color = new Color(0f, 0f, 0f, image.material.color.a - 0.05f);
        }
    }
}
