using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField, TextArea] private string taskDescription;
    private bool completed;

    public void OnCompleted()
    {
        completed = true;
    }
}
