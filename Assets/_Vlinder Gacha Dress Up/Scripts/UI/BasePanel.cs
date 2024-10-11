using UnityEngine;

public class BasePanel : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        OpenPanel();
        LoadButtonAndImage();
        SetListener();
    }

    protected void OpenPanel()      
    {
        
    }

    protected virtual void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    protected virtual void LoadButtonAndImage()
    {
        
    }

    protected virtual void SetListener()
    {
        
    }

    protected void Reset()
    {
        LoadButtonAndImage();
    }
}