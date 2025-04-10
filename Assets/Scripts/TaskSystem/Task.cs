using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    [SerializeField, TextArea] private string taskDescription;
    private bool _completed;
    [SerializeField] private bool active;

    [SerializeField] private Color activeColor, inactiveColor, completedColor;

    public UnityEvent onTaskCompleted;

    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text statusText;

    private void Start()
    {
        descriptionText.text = taskDescription;
        
        UpdateTextColors();
    }

    public void OnCompleted()
    {
        if(!active) return;
        onTaskCompleted?.Invoke();
        _completed = true;
        UpdateTextColors();
    }

    public void EnableTask()
    {
        active = true;
        UpdateTextColors();
    }
    
    private void UpdateTextColors()
    {
        statusText.color = activeColor;
        descriptionText.color = activeColor;
        statusText.outlineColor = activeColor;
        descriptionText.outlineColor = activeColor;
        
        switch (_completed)
        {
            case true:
                statusText.text = "Done";
                descriptionText.color = completedColor;
                descriptionText.text = $"<s>{descriptionText.text}";
                break;
            case false:
                statusText.text = "Not Done";
                break;
        }

        switch (active)
        {
            case true:
                break;
            case false:
                statusText.color = inactiveColor;
                descriptionText.color = inactiveColor;
                statusText.outlineColor = inactiveColor;
                descriptionText.outlineColor = inactiveColor;
                break;
        }
    }
}

[Serializable]
public class TaskData
{
    public bool completed;
    public UnityEvent onCompleted;
}
