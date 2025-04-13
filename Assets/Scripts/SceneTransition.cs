using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private string _scene;
    private FadeScript _fade;

    private void Awake()
    {
        _fade = GetComponent<FadeScript>();
    }
    public void FadeToScene(string scene)
    {
        _scene = scene;
        _fade.FadeOut();
        Invoke("ActuallyLoadIt", 1f);
    }

    private void ActuallyLoadIt()
    {
        SceneManager.LoadScene(_scene);
    }
}
